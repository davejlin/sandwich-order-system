using System;
using System.Reflection;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class ItemFactory : IItemFactory
    {
        public ItemFactory() { }

        public T CreateItem<T> (string[] properties) where T : class
        {
            T item = null;
            try
            {
                item = Activator.CreateInstance<T>();

                Type type = item.GetType();

                PropertyInfo prop = type.GetProperty(ITEM_NAME);
                if (prop != null)
                    prop.SetValue(item, properties[0]);

                prop = type.GetProperty(ITEM_PRICE);
                if (prop != null)
                    prop.SetValue(item, Convert.ToDecimal(properties[1]));

                prop = type.GetProperty(ITEM_TYPE);
                if (prop != null)
                    prop.SetValue(item, type.ToString());

            } catch (Exception ex)
            {
                Console.WriteLine(ITEM_CREATION_ERROR_MESSAGE, ex.ToString());
            }

            return item;
        }
    }
}
