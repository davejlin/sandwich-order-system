using SandwichOrderSystemShared.DataAccess.Db;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SandwichOrderSystemShared.DataAccess
{
    public class Repository : IRepository
    {
        IContextFactory contextFactory;
        IErrorHandler errorHandler;

        public Repository(IContextFactory contextFactory, IErrorHandler errorHandler)
        {
            this.contextFactory = contextFactory;
            this.errorHandler = errorHandler;
        }

        public IEnumerable<T> GetItem<T>() where T : class, IItem
        {
            string dBSetName = typeof(T).Name + "Set";
            using (Context context = GetContext())
            {
                try
                {
                    var contextDBSet = context.GetType().GetProperty(dBSetName).GetValue(context) as DbSet<T>;
                    return contextDBSet
                        .OrderBy(s => s.Name)
                        .ThenBy(s => s.Price)
                        .ToList();
                } catch (Exception ex)
                {
                    errorHandler.HandleError(string.Format("Exception thrown when trying to get {0}: {1}", dBSetName, ex.Message));
                    return null;
                }

            }
        }

        private Context GetContext()
        {
            var context = contextFactory.createContext();
            //context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }
    }
}
