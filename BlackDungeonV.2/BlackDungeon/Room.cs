using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{
    public class Room
    {
             
        static RoomMachine roomMachine = RoomMachine.GetInstance(); // a reference to RoomMachine
        private string thisRoomName; // the name of this room
        private List<String> itemList = new List<string>(); // a list that stores the items of this room
        private List<String> objectList = new List<string>(); // a list that stores the objects of this room

        public Room(string name) // constructor, ask name's room
        {
            thisRoomName = name;
        }
        public string GetName() // get the name of the room
        {
            return thisRoomName;
        }

        public void OnRoomEntry() // The following evets will occur by entering the room
        {
            Console.WriteLine("You entered room");           
        }
        public void OnRoomExit() // the following events will occur by leaving the room
        {
            Console.WriteLine("You left the room");
        } 

        public void AddItemToRoom(string nameOfItem) // add an item to the room's item list 
        { 
            itemList.Add(nameOfItem);
        }
        public void RemoveItemFromRoom(string nameOfItem) {
            itemList.Remove(nameOfItem);

        }
        public static void ShowItemList()// print the items of the room  
        {         
            if (roomMachine.GetCurrentRoom().itemList.Count == 0)
            {
                Console.WriteLine(" There are no items in this room ");
            }
            else {
                foreach (string item in roomMachine.GetCurrentRoom().itemList)
                { // print each item of the current room on console
                    Console.Write(" Items in room: " + item + ".");
                }
            }
      }
        public static List<string> GetItemFromRoom(string nameOfRoom) // get a list of the room's items
        {            
            return roomMachine.GetCurrentRoom().itemList;
        }
        public void AddObjectToRoom(string nameOfObject) // Add an object to the room
        {
            objectList.Add(nameOfObject);

        }
        public static void ShowObjectList() // print objects in this room 
        {
            if (roomMachine.GetCurrentRoom().objectList.Count == 0)
            {
                Console.WriteLine(" There are no objects in the room ");
            }
            else {
                foreach (string oneObject in roomMachine.GetCurrentRoom().objectList)
                {
                    Console.WriteLine(" Objects in room: " + oneObject + ".");
                }
            }
        }
        public static List<string> GetObjectsInRoom() {
            return roomMachine.GetCurrentRoom().objectList;
        }
    } 
}
