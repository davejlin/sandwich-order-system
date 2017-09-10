using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;
using System.Reflection;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class ItemFactory : IItemFactory
    {
        IErrorHandler errorHandler;

        public ItemFactory(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public T CreateItem<T> (string[] properties) where T : class, IItem
        {
            T item = null;
            try
            {
                item = Activator.CreateInstance<T>();

                Type type = item.GetType();

                PropertyInfo prop = type.GetProperty(ITEM_TYPE);
                if (prop != null)
                    prop.SetValue(item, type.ToString());

                prop = type.GetProperty(ITEM_NAME);
                if (prop != null)
                    prop.SetValue(item, properties[0]);

                prop = type.GetProperty(ITEM_PRICE);
                if (prop != null)
                    prop.SetValue(item, Convert.ToDecimal(properties[1]));

            } catch (Exception ex)
            {
                errorHandler.HandleError(ITEM_CREATION_ERROR_MESSAGE + ex.Message);
            }

            return item;
        }
    }
}
