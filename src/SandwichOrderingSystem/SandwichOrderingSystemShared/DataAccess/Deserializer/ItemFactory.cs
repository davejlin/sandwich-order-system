﻿using System;
using System.Reflection;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
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

                PropertyInfo prop = t.GetProperty("Name");
                if (prop != null)
                    prop.SetValue(item, properties[0]);

                prop = t.GetProperty("Price");
                if (prop != null)
                    prop.SetValue(item, Convert.ToDecimal(properties[1]));

            } catch (Exception ex)
            {
                Console.WriteLine("Error creating item: {0}", ex.ToString());
            }

            return item;
        }
    }
}
