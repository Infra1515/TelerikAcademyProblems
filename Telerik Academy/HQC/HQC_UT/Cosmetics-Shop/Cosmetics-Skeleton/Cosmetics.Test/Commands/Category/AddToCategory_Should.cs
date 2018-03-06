using System;
using System.Collections.Generic;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine.Commands.Category;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cosmetics.Test.Commands.Category
{
    [TestClass]
    public class AddToCategory_Should
    {
        [TestMethod]
        public void ReturnCorrectResult_WhenCategoryDoesNotExit()
        {
            var dataMock = new Mock<IDataStore>();
            var productMock = new Mock<IProduct>();
            var categoryMock = new Mock<ICategory>();

            var categoryName = "ForMale";
            var productName = "Cool";
            var commandParametersMock = new List<string> { categoryName, productName };


            dataMock.Setup(x => x.Categories[categoryName])
                .Returns(categoryMock.Object);
            dataMock.Setup(x => x.Products[productName])
                .Returns(productMock.Object);

            productMock.Setup(x => x.Name).Returns(productName);
            categoryMock.Setup(x => x.Name).Returns(categoryName);

            // act
            var sut = new AddToCategory(dataMock.Object);
            var actualResult = sut.Execute(commandParametersMock);
            var expectedResult = string.Format(Constants.CategoryDoesNotExist,
                categoryName);

            // Assert
            StringAssert.Equals(actualResult, expectedResult);
        }

        [TestMethod]
        public void ReturnCorrectResult_WhenProductDoesNotExist()
        {
            var dataMock = new Mock<IDataStore>();
            var productMock = new Mock<IProduct>();
            var categoryMock = new Mock<ICategory>();

            var categoryName = "ForMale";
            var productName = "Cool";
            var commandParametersMock = new List<string> { categoryName, productName };


            dataMock.Setup(x => x.Categories[categoryName])
                .Returns(categoryMock.Object);
            dataMock.Setup(x => x.Products[productName])
                .Returns(productMock.Object);

            productMock.Setup(x => x.Name).Returns(productName);
            categoryMock.Setup(x => x.Name).Returns(categoryName);

            dataMock.Setup(x => x.Categories.ContainsKey(It.IsAny<string>()))
               .Returns(true);

            // act
            var sut = new AddToCategory(dataMock.Object);
            var actualResult = sut.Execute(commandParametersMock);
            var expectedResult = string.Format(Constants.ProductDoesNotExist,
                productName);

            // Assert
            StringAssert.Equals(actualResult, expectedResult);
        }

        [TestMethod]
        public void SuccessfullyAddProductToCategory_WhenValidValuesArePassed()
        {
            // Arrange
            var dataMock = new Mock<IDataStore>();
            var productMock = new Mock<IProduct>();
            var categoryMock = new Mock<ICategory>();

            var categoryName = "ForMale";
            var productName = "Cool";
            var commandParametersMock = new List<string> { categoryName, productName };


            dataMock.Setup(x => x.Categories[categoryName])
                .Returns(categoryMock.Object);
            dataMock.Setup(x => x.Products[productName])
                .Returns(productMock.Object);

            dataMock.Setup(x => x.Categories.ContainsKey(It.IsAny<string>()))
                .Returns(true);
            dataMock.Setup(x => x.Products.ContainsKey(It.IsAny<string>()))
                .Returns(true);


            productMock.Setup(x => x.Name).Returns(productName);
            categoryMock.Setup(x => x.Name).Returns(categoryName);

            // act
            var sut = new AddToCategory(dataMock.Object);
            var actualResult = sut.Execute(commandParametersMock);
            var expectedResult = string.Format(Constants.ProductAddedToCategory,
                productName, categoryName);

            // Assert
            StringAssert.Equals(actualResult, expectedResult);
        }
    }
}
