using System;
using System.Reflection;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class ItemFactory : IItemFactory
    {
        public T CreateItem<T> (string[] properties) where T : class
        {
            T item = null;
            try
            {
                item = Activator.CreateInstance<T>();

                Type t = item.GetType();

                PropertyInfo prop = t.GetProperty(ITEM_NAME);
                if (prop != null)
                    prop.SetValue(item, properties[0]);

                prop = t.GetProperty(ITEM_PRICE);
                if (prop != null)
                    prop.SetValue(item, Convert.ToDecimal(properties[1]));

            } catch (Exception ex)
            {
                Console.WriteLine(ITEM_CREATION_ERROR_MESSAGE, ex.ToString());
            }

            return item;
        }
    }
}
