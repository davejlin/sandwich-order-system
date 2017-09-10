using SandwichOrderSystemShared.DataAccess.Db;
using static SandwichOrderSystemShared.Constants;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Diagnostics;
using SandwichOrderSystemShared.Services;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class DataInitializer : IDataInitializer
    {
        IFileSystemManager fileSystemManager;
        IDataParser dataParser;
        IItemFactory itemFactory;
        IErrorHandler errorHandler;

        public DataInitializer(IFileSystemManager fileSystemManager, IDataParser dataParser, IItemFactory itemFactory, IErrorHandler errorHandler)
        {
            this.fileSystemManager = fileSystemManager;
            this.dataParser = dataParser;
            this.itemFactory = itemFactory;
            this.errorHandler = errorHandler;
        }
        
        public void InitData(Context context)
        {
            var typeDict = getItemsDict();

            MethodInfo genericCreateItem = itemFactory.GetType().GetMethod(CREATE_ITEM_METHOD);
            MethodInfo genericAddToContextDBSet = GetType().GetMethod(ADD_TO_CONTEXT_DBSET_METHOD);

            foreach (var entry in typeDict)
            {
                var typeName = MODELS_NAMESPACE + entry.Key;
                var type = Type.GetType(typeName);

                if (type != null)
                {
                    MethodInfo createItem = genericCreateItem.MakeGenericMethod(type);
                    MethodInfo addToDBSet = genericAddToContextDBSet.MakeGenericMethod(type);

                    foreach (var properties in entry.Value)
                    {
                        try
                        {
                            var instance = createItem.Invoke(itemFactory, new object[] { properties });
                            addToDBSet.Invoke(this, new object[] { instance, context });
                        }
                        catch (Exception ex)
                        {
                            errorHandler.HandleError(ex.Message);
                        }

                    }

                    context.SaveChanges();
                }
            }
        }

        private Dictionary<string, IEnumerable<string[]>> getItemsDict()
        {
            Dictionary<string, IEnumerable<string[]>> results = new Dictionary<string, IEnumerable<string[]>>();

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
            string dbSetName = typeof(T).Name + DBSET_SUFFIX;
            var contextDBSet = context.GetType().GetProperty(dbSetName).GetValue(context) as DbSet<T>;
            if (contextDBSet != null)
            {
                contextDBSet.Add(instance);
            }
        }
    }
}
