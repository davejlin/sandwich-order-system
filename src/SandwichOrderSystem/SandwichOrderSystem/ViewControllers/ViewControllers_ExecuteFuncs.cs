﻿using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;
using static SandwichOrderSystemShared.Constants;
using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        private Dictionary<ViewContext, Dictionary<string, Func<string, IEnumerable<string>>>> executeFuncs;

        private void initExecuteFuncs()
        {
            executeFuncs = new Dictionary<ViewContext, Dictionary<string, Func<string, IEnumerable<string>>>>();

            var funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();

            // Main
            Func<string, IEnumerable<string>> func = c =>
            {
                return showOrders();
            };

            funcsDict.Add(SHOW_COMMAND, func);
            funcsDict.Add(FINISH_COMMAND, func);
            funcsDict.Add(DELETE_COMMAND, func);

            executeFuncs.Add(ViewContext.Main, funcsDict);

            // Delete
            funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();

            func = c =>
            {
                viewModel.ResetOrders();
                return null;
            };

            funcsDict.Add(DELETE_COMMAND, func);

            executeFuncs.Add(ViewContext.Delete, funcsDict);

            // Review
            funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();

            func = c =>
            {
                viewModel.AddCurrentOrderToOrders();
                return null;
            };

            funcsDict.Add(FINISH_COMMAND, func);

            func = c =>
            {
                viewModel.ResetCurrentOrder();
                return null;
            };

            funcsDict.Add(DELETE_COMMAND, func);

            executeFuncs.Add(ViewContext.Review, funcsDict);

            // Finish
            funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();

            func = c =>
            {
                PaymentMethodType type = PaymentMethodType.Cash;
                if (c == "c")
                {
                    type = PaymentMethodType.CreditCard;
                }
                viewModel.FinishOrders(type);
                return new List<string> { FINISH_COMPLETE_TITLE };
            };

            funcsDict.Add(PAY_CREDIT_CARD_COMMAND, func);
            funcsDict.Add(PAY_CASH_COMMAND, func);
            executeFuncs.Add(ViewContext.Finish, funcsDict);

            // Items
            addItemExecuteFuncDict<SignatureSandwich>(ViewContext.SignatureSandwich);
            addItemExecuteFuncDict<Bread>(ViewContext.Bread);
            addItemExecuteFuncDict<Filling>(ViewContext.Filling);
            addItemExecuteFuncDict<Cheese>(ViewContext.Cheese);
            addItemExecuteFuncDict<Vegetable>(ViewContext.Vegetable);
            addItemExecuteFuncDict<Condiment>(ViewContext.Condiment);
            addItemExecuteFuncDict<Drink>(ViewContext.Drink);
            addItemExecuteFuncDict<Chips>(ViewContext.Chips);
        }

        private IEnumerable<string> showOrders()
        {
            if (viewModel.GetOrdersCount() > 0)
            {
                var orders = viewModel.GetOrders();
                return new List<string>() { orders.ToString(), string.Format(TOTAL_PRICE_FORMAT, TOTAL_PRICE_TITLE, viewModel.GetOrdersPrice()), Constants.EMPTY_STRING };
            }
            else
            {
                return new List<string>() { SHOW_NO_ORDERS_TITLE };
            }
        }

        private IEnumerable<string> showPendingOrder()
        {
            var order = viewModel.GetCurrentOrder();
            if (order.Items.Count > 0)
            {
                return new List<string>() { order.ToString(), Constants.EMPTY_STRING, string.Format(TOTAL_PRICE_FORMAT, TOTAL_PRICE_TITLE, viewModel.GetCurrentOrderPrice()), Constants.EMPTY_STRING };
            }
            else
            {
                return new List<string>() { SHOW_NO_ORDERS_TITLE };
            }
        }

        private void addItemExecuteFuncDict<T>(ViewContext context) where T : class, IItem
        {
            var funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();
            var menuItemCommands = viewModel.GetMenuItemCommands<T>();

            foreach (string command in menuItemCommands)
            {
                funcsDict.Add(command, createItemExecuteFunc<T>());
            }

            funcsDict.Add(NEXT_COMMAND, c => showPendingOrder());
            funcsDict.Add(DELETE_COMMAND, c => { viewModel.ResetCurrentOrder(); return null; });

            executeFuncs.Add(context, funcsDict);
        }

        private Func<string, IEnumerable<string>> createItemExecuteFunc<T>() where T : class, IItem
        {
            Func<string, IEnumerable<string>> func = c =>
            {
                viewModel.AddItem<T>(c);
                return showPendingOrder();
            };

            return func;
        }
    }
}
