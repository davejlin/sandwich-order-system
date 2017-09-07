using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
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
                return new List<string>() { string.Format(" You typed in {0}", c) };
            };

            executeFuncs.Add(ViewContext.Add, func);
            executeFuncs.Add(ViewContext.Show, func);
            executeFuncs.Add(ViewContext.Finish, func);
        }
    }
}
