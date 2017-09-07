using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;
using System.Linq;
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

            Func<string, IEnumerable<string>> func = c =>
            {
                return showOrders();
            };

            funcsDict.Add(SHOW_COMMAND, func);
            funcsDict.Add(FINISH_COMMAND, func);

            executeFuncs.Add(ViewContext.Main, funcsDict);

            // Review

            funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();

            func = c =>
            {
                viewModel.AddOrder();
                return null;
            };

            funcsDict.Add(FINISH_COMMAND, func);

            func = c =>
            {
                viewModel.ResetOrder();
                return null;
            };

            funcsDict.Add(DELETE_COMMAND, func);

            executeFuncs.Add(ViewContext.Review, funcsDict);

            // Items

            funcsDict = createItemExecuteFuncDict<SignatureSandwich>();
            executeFuncs.Add(ViewContext.SignatureSandwich, funcsDict);

            funcsDict = createItemExecuteFuncDict<Bread>();
            executeFuncs.Add(ViewContext.Bread, funcsDict);

            funcsDict = createItemExecuteFuncDict<Filling>();
            executeFuncs.Add(ViewContext.Filling, funcsDict);

            funcsDict = createItemExecuteFuncDict<Cheese>();
            executeFuncs.Add(ViewContext.Cheese, funcsDict);

            funcsDict = createItemExecuteFuncDict<Vegetable>();
            executeFuncs.Add(ViewContext.Vegetable, funcsDict);

            funcsDict = createItemExecuteFuncDict<Condiment>();
            executeFuncs.Add(ViewContext.Condiment, funcsDict);

            funcsDict = createItemExecuteFuncDict<Drink>();
            executeFuncs.Add(ViewContext.Drink, funcsDict);

            funcsDict = createItemExecuteFuncDict<Chips>();
            executeFuncs.Add(ViewContext.Chips, funcsDict);
        }

        private IEnumerable<string> showOrders()
        {
            if (viewModel.GetOrdersCount() > 0)
            {
                var orders = viewModel.GetOrders();
                return new List<string>() { orders.ToString() };
            }
            else
            {
                return new List<string>() { SHOW_NO_ORDERS_TITLE };
            }
        }

        private Dictionary<string, Func<string, IEnumerable<string>>> createItemExecuteFuncDict<T>() where T : class, IItem
        {
            var funcsDict = new Dictionary<string, Func<string, IEnumerable<string>>>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                funcsDict.Add(command, createItemExecuteFunc<T>());
            }

            return funcsDict;
        }

        private Func<string, IEnumerable<string>> createItemExecuteFunc<T>() where T : class, IItem
        {
            Func<string, IEnumerable<string>> func = c =>
            {
                viewModel.AddItem<T>(c);
                return null;
            };

            return func;
        }
    }
}
