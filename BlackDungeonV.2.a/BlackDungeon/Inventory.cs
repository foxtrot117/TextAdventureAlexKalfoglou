using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{
    class Inventory
    {
        private static Inventory instanceOfClass = null;

        private  List<string> itemsContained = new List<string>();
        private Inventory () { }

        public static Inventory GetInstance() {
            if (instanceOfClass == null)
            {
                instanceOfClass = new Inventory();
                return instanceOfClass;
            }
            else {
                return instanceOfClass;
            }
        }

        public void AddItem(string nameOfItem) {
            itemsContained.Add(nameOfItem);
        }
        public void RemoveItem(string nameOfItem) {
            if (itemsContained.Contains(nameOfItem))
                itemsContained.Remove(nameOfItem);
        }

        public string GetItemByName(string name) {
            string itemFound = null;
            foreach (string item in itemsContained) {
                if (item == name)
                {
                    itemFound = item;
                }
                else {
                    itemFound = null;
                }
            }
            return itemFound;

        }

        public List<string> GetInventory() {
            List<string> itemsList = null;
            itemsList = itemsContained;
            return itemsList;
        }
    
        
    }
}
