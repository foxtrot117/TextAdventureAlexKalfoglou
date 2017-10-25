using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{
    class Program
    {


        public static bool isGameReady = false;


        static void Main(string[] args)
        {

            RoomMachine roomMachine = RoomMachine.GetInstance();   
            
            // Creating the rooms of the game
            Room center0_0 = new Room("CENTER");
            Room east1_0 = new Room("EAST");                     
            Room south0_1 = new Room("SOUTH");
            Room north0_1 = new Room("NORTH");
            Room west1_0 = new Room("WEST");

            // adding these rooms to RoomMachine
            roomMachine.AddRoom(center0_0);
            roomMachine.AddRoom(east1_0);
            roomMachine.AddRoom(west1_0);
            roomMachine.AddRoom(north0_1);
            roomMachine.AddRoom(south0_1);

            // Creating the valid transitions between rooms           
            roomMachine.AddTransition(south0_1, center0_0);          
            roomMachine.AddTransition(north0_1, center0_0);           
            roomMachine.AddTransition(center0_0, south0_1);           
            roomMachine.AddTransition(center0_0, north0_1);            
            roomMachine.AddTransition(center0_0, west1_0);          
            roomMachine.AddTransition(center0_0, east1_0);       
            roomMachine.AddTransition(west1_0, center0_0);        
            roomMachine.AddTransition(east1_0, center0_0);

            //Adding items to rooms
            north0_1.AddObjectToRoom("DOOR");
            center0_0.AddObjectToRoom("ROCK");
            south0_1.AddItemToRoom("KEY");
            center0_0.AddItemToRoom("FLASHLIGHT");
            west1_0.AddItemToRoom("FOOD");

            
            isGameReady = true; // The game is set and ready to be played

            Actions.GetInstance().MakeChoice(); // Make the first action
            

            





        }
    }    
     
}
