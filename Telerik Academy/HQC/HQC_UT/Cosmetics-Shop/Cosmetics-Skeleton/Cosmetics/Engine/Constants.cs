using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Common
{
    public class Constants
    {
        public const string InvalidCommand = "Invalid command name: {0}!";
        public const string CategoryExists = "Category with name {0} already exists!";
        public const string CategoryCreated = "Category with name {0} was created!";
        public const string CategoryDoesNotExist = "Category {0} does not exist!";
        public const string ProductDoesNotExist = "Product {0} does not exist!";
        public const string ProductAddedToCategory = "Product {0} added to category {1}!";
        public const string ProductRemovedCategory = "Product {0} removed from category {1}!";
        public const string ShampooAlreadyExist = "Shampoo with name {0} already exists!";
        public const string ShampooCreated = "Shampoo with name {0} was created!";
        public const string ToothpasteAlreadyExist = "Toothpaste with name {0} already exists!";
        public const string ToothpasteCreated = "Toothpaste with name {0} was created!";
        public const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";
        public const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        public const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";
        public const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";
        public const string InvalidGenderType = "Invalid gender type!";
        public const string InvalidUsageType = "Invalid usage type!";
    }
}
