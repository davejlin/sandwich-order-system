using SandwichOrderSystemShared.DataAccess.Db;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SandwichOrderSystemShared.DataAccess
{
    public class Repository : IRepository
    {
        IContextFactory contextFactory;

        public Repository(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public IEnumerable<T> GetItem<T>() where T : class, IItem
        {
            string dBSetName = typeof(T).Name + "Set";
            using (Context context = GetContext())
            {
                var contextDBSet = context.GetType().GetProperty(dBSetName).GetValue(context) as DbSet<T>;
                return contextDBSet
                    .OrderBy(s => s.Name)
                    .ThenBy(s => s.Price)
                    .ToList();
            }
        }

        public void DisplayAllItems()
        {
            displayItems<Bread>();
            displayItems<Cheese>();
            displayItems<Condiment>();
            displayItems<Drink>();
            displayItems<Filling>();
            displayItems<SignatureSandwich>();
            displayItems<Vegetable>();
        }

        private Context GetContext()
        {
            var context = contextFactory.createContext();
            //context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }

        private void displayItems<T>() where T : class, IItem
        {
            string typeName = typeof(T).Name;

            Console.WriteLine("\n{0}",typeName);
            Console.WriteLine("=================");

            foreach (var item in GetItem<T>())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
