using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAndTravel.Extended.Items;
using TradeAndTravel.Extended.Locations;
using TradeAndTravel.Extended.Roles;

namespace TradeAndTravel.Extended
{
    public class InteractionManagerExtended : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }
        protected override Person CreatePerson(string personTypeString, string personNameString, 
            Location personLocation)
        {
            Person person = null;
            switch(personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInterraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }
        protected void HandleCraftInterraction(string[] commandWords, Person actor)
        {
            if(actor.ListInventory().Count != 0)
            {
                // How Do I check if inventory contains both Weapon and wood with one LINQ Query?
                //actor.ListInventory().Any(item => item.ItemType == ItemType.Iron &&
                //item.ItemType == ItemType.Wood))
                if (commandWords[2] == "weapon" && 
                    actor.ListInventory().Any(item => item.ItemType == ItemType.Iron) &&
                    actor.ListInventory().Any(item => item.ItemType == ItemType.Wood))
                {
                    Item item = new Iron(commandWords[3], actor.Location);
                    this.AddToPerson(actor, item);
                    item.UpdateWithInteraction("crafted");
                }
                else if(commandWords[2] == "armor" &&
                    actor.ListInventory().Any(item => item.ItemType == ItemType.Iron))
                {
                    Item item = new Armor(commandWords[3], actor.Location);
                    this.AddToPerson(actor, item);
                    item.UpdateWithInteraction("crafted");
                }
            }
        }

        protected  void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if(actor.Location.LocationType != LocationType.Town)
            {

                if (actor.Location.LocationType == LocationType.Forest &&
                        actor.ListInventory().Any(item => item.ItemType == ItemType.Weapon))
                {
                    Item item = new Wood(commandWords[2], actor.Location);
                    this.AddToPerson(actor, item);
                    item.UpdateWithInteraction("gather");
                    strayItemsByLocation[actor.Location].Clear();
                }
                else if (actor.Location.LocationType == LocationType.Mine &&
                            actor.ListInventory().Any(item => item.ItemType == ItemType.Armor))
                {
                    Item item = new Iron(commandWords[2], actor.Location);
                    this.AddToPerson(actor, item);
                    item.UpdateWithInteraction("gather");
                    strayItemsByLocation[actor.Location].Clear();
                }
            }
        }
    }
}


