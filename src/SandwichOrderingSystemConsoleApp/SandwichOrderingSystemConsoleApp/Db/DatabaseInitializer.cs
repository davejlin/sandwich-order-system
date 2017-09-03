using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SandwichOrderingSystemConsoleApp.Deserializer;
using SandwichOrderingSystemConsoleApp.Models;
using System.Reflection;

namespace SandwichOrderingSystemConsoleApp.Db
{
    internal class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        IDataInitializer dataInitializer;
        IItemFactory itemFactory;

        internal DatabaseInitializer(IDataInitializer dataInitializer, IItemFactory itemFactory)
        {
            this.dataInitializer = dataInitializer;
            this.itemFactory = itemFactory;
        }

        private const string modelsNameSpace = "SandwichOrderingSystemConsoleApp.Models";
        protected override void Seed(Context context)
        {
            Dictionary<string, List<string[]>> typeDict = dataInitializer.GetItemsDict();
            MethodInfo genericCreateItem = itemFactory.GetType().GetMethod("CreateItem");
            MethodInfo genericAddToContext = this.GetType().GetMethod("addToContext");

            foreach (var entry in typeDict)
            {
                var typeName = modelsNameSpace + "." + entry.Key;
                var type = Type.GetType(typeName);

                if (type != null)
                {
                    MethodInfo createItem = genericCreateItem.MakeGenericMethod(type);
                    MethodInfo addToItem = genericAddToContext.MakeGenericMethod(type);

                    foreach (var properties in entry.Value)
                    {
                        var instance = createItem.Invoke(itemFactory, new object[] { properties });
                        addToItem.Invoke(this, new object[] { instance, context });
                    }
                }

                context.SaveChanges();
            }
        }

        public void addToContext<T>(T instance, Context context)
        {
            if (typeof(T) == typeof(Sandwich)) 
            {
                context.Sandwiches.Add(instance as Sandwich);
            }
        }
    }
}
