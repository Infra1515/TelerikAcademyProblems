﻿using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Furnitures;
using System;

namespace FurnitureManufacturer.Engine.Factories
{
    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public IFurniture CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            return new Table(model, GetMaterialType(materialType).ToString(), price, height, length, width);
        }

        public IFurniture CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            return new Chair(model, GetMaterialType(materialType).ToString() , price, height, numberOfLegs);
        }

        public IFurniture CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            return new AdjustableChair(model, GetMaterialType(materialType).ToString() , price, height, numberOfLegs);
        }

        public IFurniture CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            return new ConvertibleChair(model, GetMaterialType(materialType).ToString(), price, height, numberOfLegs);
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }

    }
}
