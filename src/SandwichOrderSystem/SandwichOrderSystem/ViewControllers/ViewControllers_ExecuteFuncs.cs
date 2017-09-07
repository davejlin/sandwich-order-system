using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;
using System.Linq;

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
        }

        private IEnumerable<string> showOrders()
        {
            if (viewModel.GetOrdersCount() > 0)
            {
                var orders = viewModel.GetOrders();
                return orders.Select(i => i?.ToString());
            }
            else
            {
                return new List<string>() { SHOW_NO_ORDERS_TITLE };
            }
        }
    }
}
