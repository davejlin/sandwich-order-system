using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;
using System.Linq;
using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        Dictionary<ViewContext, Func<string, IEnumerable<string>>> executeFuncs;

        private void initExecuteFuncs()
        {
            executeFuncs = new Dictionary<ViewContext, Func<string, IEnumerable<string>>>();

            Func<string, IEnumerable<string>> func = c =>
            {
                return showOrders();
            };

            executeFuncs.Add(ViewContext.Show, func);
            executeFuncs.Add(ViewContext.Finish, func);

            func = c =>
            {
                viewModel.AddItem<SignatureSandwich>(c);
                return null;
            };

            executeFuncs.Add(ViewContext.SignatureSandwich, func);

            func = c =>
            {
                if (c == FINISH_COMMAND)
                {
                    viewModel.AddOrder();
                }
                else
                {
                    viewModel.ResetOrder();
                }

                return null;
            };

            executeFuncs.Add(ViewContext.Review, func);
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
    }
}
