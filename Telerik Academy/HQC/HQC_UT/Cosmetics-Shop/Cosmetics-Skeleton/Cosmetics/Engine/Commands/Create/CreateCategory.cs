using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Create
{
    public class CreateCategory : ICommand
    {
        private readonly ICosmeticsFactory factory;
        private readonly IDataStore dataStore;
        public CreateCategory(ICosmeticsFactory factory, IDataStore dataStore)
        {
            this.factory = factory;
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            var categoryName = commandParameters[0];

            if (this.dataStore.Categories.ContainsKey(categoryName))
            {
                return string.Format(Constants.CategoryExists, categoryName);
            }

            var category = this.factory.CreateCategory(categoryName);
            this.dataStore.AddCategory(category);

            return string.Format(Constants.CategoryCreated, categoryName);
        }
    }
}
