using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Category
{
    public class ShowCategory : ICommand
    {
        private readonly IDataStore dataStore;

        public ShowCategory(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            var categoryToShow = commandParameters[0];
            if (!this.dataStore.Categories.ContainsKey(categoryToShow))
            {
                return string.Format(Constants.CategoryDoesNotExist, categoryToShow);
            }

            var category = this.dataStore.Categories[categoryToShow];

            return category.Print();

        }
    }
}
