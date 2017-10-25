using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{
    /* Describes and impliments interaction between items and objects */
    class InteractionWithObjects
    {
        private static InteractionWithObjects instanceOfClass = null;




        private InteractionWithObjects()
        { }
        public static InteractionWithObjects GetInstance() // get the only instance of the class 
        {
            if (instanceOfClass == null)
            {
                instanceOfClass = new InteractionWithObjects();
                return instanceOfClass;
            }
            else {
                return instanceOfClass;
            }

        }


        public void UseItemOnObject(string nameOfItem, string nameOfObject) { // check if this combination is valid
            Console.WriteLine("[trying use " + nameOfItem + " on " + nameOfObject + "]");
            if (nameOfItem == "KEY" && nameOfObject == "DOOR") 
            {
                Console.WriteLine(" YOU WON ");
            }
            else {
                Console.WriteLine(" Nothing happend ");
            }
        }

    }

}   
     
