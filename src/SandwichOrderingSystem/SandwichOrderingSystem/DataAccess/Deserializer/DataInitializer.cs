using SandwichOrderingSystem.DataAccess.Db;
using SandwichOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystem.DataAccess.Deserializer
{
    public class DataInitializer : IDataInitializer
    {
        IFileSystemManager fileSystemManager;
        IDataParser dataParser;
        IItemFactory itemFactory;

        private const string modelsNameSpace = "SandwichOrderingSystem.Models";

        public DataInitializer(IFileSystemManager fileSystemManager, IDataParser dataParser, IItemFactory itemFactory)
        {
            this.fileSystemManager = fileSystemManager;
            this.dataParser = dataParser;
            this.itemFactory = itemFactory;
        }
        
        public void InitData(Context context)
        {
            var typeDict = getItemsDict();

            MethodInfo genericCreateItem = itemFactory.GetType().GetMethod("CreateItem");
            MethodInfo genericAddToContextDBSet = this.GetType().GetMethod("addToContextDBSet");

            foreach (var entry in typeDict)
            {
                var typeName = modelsNameSpace + "." + entry.Key;
                var type = Type.GetType(typeName);

                if (type != null)
                {
                    MethodInfo createItem = genericCreateItem.MakeGenericMethod(type);
                    MethodInfo addToDBSet = genericAddToContextDBSet.MakeGenericMethod(type);

                    foreach (var properties in entry.Value)
                    {
                        var instance = createItem.Invoke(itemFactory, new object[] { properties });
                        addToDBSet.Invoke(this, new object[] { instance, context });
                    }

                    context.SaveChanges();
                }
            }
        }

        private Dictionary<string, List<string[]>> getItemsDict()
        {
            Dictionary<string, List<string[]>> results = new Dictionary<string, List<string[]>>();

            var itemNames = fileSystemManager.GetItemNames();
            foreach (var itemName in itemNames)
            {
                var contents = fileSystemManager.GetContents(itemName);
                var properties = dataParser.ParseData(contents);
                results[itemName] = properties;
            }

            return results;
        }

        public void addToContextDBSet<T>(T instance, Context context) where T : class
        {
            string dbSetName = typeof(T).Name + "Set";
            var contextDBSet = context.GetType().GetProperty(dbSetName).GetValue(context) as DbSet<T>;
            contextDBSet.Add(instance);
        }

    }
}
