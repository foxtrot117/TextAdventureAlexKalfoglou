using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{   /* 
    Player's available actions 
    Reads user's input and then, impliments the corresponding action
    */
    class Actions
    {
        private InteractionWithObjects interaction = InteractionWithObjects.GetInstance();
        private static Actions instanceOfClass = null; // holds the only intance of the class
        RoomMachine roomMachine = RoomMachine.GetInstance(); // a reference to RoomMachine class
        private string choice = null; // stores the input of user
        private Actions() { }

        // Access the only instance of this class
        public static Actions GetInstance()
        {
            if (instanceOfClass == null)
            {
                instanceOfClass = new Actions();
                return instanceOfClass;
            }
            else
            {
                return instanceOfClass;
            }
        }
        // read user's input 
        public void MakeChoice()
        {        
            Console.WriteLine(" What will you do? Available actions: \n \n LOOK \n INSPECT \n MOVE \n PICK ITEM \n SEE INV \n USE ITEM \n Choose action by writing it ");
            choice = Console.ReadLine(); // Store user's input
            ReadInputAction(choice); // Process the input and calls the corresponding function 
        }
        // choose which function should run , based on the user's input
        private void ReadInputAction(string input)
        {
            if (choice == "LOOK") 
            {

                roomMachine.TellCurrentNeighboors(); // print on console, the available transitions to other rooms
                MakeChoice(); // next move

            }
            else if (choice == "INSPECT") 
            {                
                Room.ShowItemList(); // print on console the items in the current room 
                Room.ShowObjectList(); // print on console the items in the current room
                MakeChoice(); // next move

            }
            else if (choice == "MOVE")
            {

                MoveAction(); // ask to which room to move and then make the transition
                MakeChoice(); // next move
            }
            else if (choice == "PICK ITEM")
            {
                PickItemAction(); // ask which item to pick. If it is in the current room, put it in the inventory
                MakeChoice(); // next move
            }
            else if (choice == "SEE INV")
            {
                SeeInvAction(); // prints on the console, the items that are in the inventory 
                MakeChoice();  // next move

            }
            else if (choice == "USE ITEM")
            {
                UseItemAction(); // ask which item to use and where, then if its in inventory and the interaction is valid call the proper event 
                MakeChoice(); // next move
            }         
            else
            {
                Console.WriteLine(" Not a valid action. Please choose again: ");
                MakeChoice();
            }
        }
        // SELECT an item from the inventory to use
        private void UseItemAction() {
            Console.WriteLine(" Select the item that you want to use: ");     
            string whichItem = Console.ReadLine(); // store user's input for item
            if (whichItem == Inventory.GetInstance().GetItemByName(whichItem))
            {
                Console.WriteLine(" Select the object that you want to use the item on ");
                string whichObject = Console.ReadLine(); // store user's input for object
                if (Room.GetObjectsInRoom().Contains(whichObject)) // if item is in inventory and the object exists in the current room
                {
                    interaction.UseItemOnObject(whichItem, whichObject); // check if this interaction occurs anything
                }
                else
                {
                    Console.WriteLine(" There is no such object in the room ");
                }
            }
            else {
                Console.WriteLine(" There is no such item in you inventory ");
            }

        }     
        // Choose an item from this room and put it in inventory
        private void PickItemAction() {
            Console.WriteLine(" Which item "); // ask which item from the room
            string whichItem = Console.ReadLine(); // store input
            if (Room.GetItemFromRoom(roomMachine.GetCurrentRoom().GetName()).Contains(whichItem)) // if item exists in the room
            {               
                Inventory.GetInstance().AddItem(whichItem); // add it to inventory
                roomMachine.GetCurrentRoom().RemoveItemFromRoom(whichItem); // remove the item from the room
                Console.WriteLine(" Item added to inventory ");
               
            }
            else
            {

                Console.WriteLine(" There is not such an item in this room ");
              
            }

        }
        // Exit this room and enter an other one
        private void MoveAction() {
            Console.WriteLine(" Choose a direction: NORTH, WEST, EAST, SOUTH");
            string direction = Console.ReadLine();
            List<Room> tempList = new List<Room>();
            if (direction == "SOUTH")
            {
                if (roomMachine.GetNeigboorByPointer(0) != null) // if the room exists
                {
                    roomMachine.MakeTransitionTo(roomMachine.GetNeigboorByPointer(0)); // make the transition

                }
                else
                {
                    Console.WriteLine(" This is not a valid exit ");

                }
            }
            else if (direction == "NORTH")
            {
                if (roomMachine.GetNeigboorByPointer(1) != null)
                {
                    roomMachine.MakeTransitionTo(roomMachine.GetNeigboorByPointer(1));

                }
                else
                {
                    Console.WriteLine(" This is not a valid exit ");

                }
            }
            else if (direction == "WEST")
            {
                if (roomMachine.GetNeigboorByPointer(2) != null)
                {
                    roomMachine.MakeTransitionTo(roomMachine.GetNeigboorByPointer(2));

                }
                else
                {
                    Console.WriteLine(" This is not a valid exit ");

                }
            }
            else if (direction == "EAST")
            {
                if (roomMachine.GetNeigboorByPointer(3) != null)
                {
                    roomMachine.MakeTransitionTo(roomMachine.GetNeigboorByPointer(3));

                }
                else
                {
                    Console.WriteLine(" This is not a valid exit ");

                }
            }
                                  
            else
            {
                Console.WriteLine(" This is not a valid exit ");
                

            }

        }
        // see items in inventory 
        private void SeeInvAction()
        {
            Console.WriteLine(" Items in inventory:  ");
            List<string> tempList = null; // create a temporary list to store the items from the inventory
            tempList = Inventory.GetInstance().GetInventory(); // reference to Inventory class to call function
            tempList.ForEach(item => Console.WriteLine(" Item: " + item)); // print items
        }
    }
}
