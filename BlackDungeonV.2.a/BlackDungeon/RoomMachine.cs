using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDungeon
{
    public class RoomMachine
    {
        private static RoomMachine instance = null;
        /**
	 * The room machine data. Each entry contains a unique room and its adjacency list.
	 * The adjacency list of a room contains all rooms to which a transition can be made
	 * from that room.
	 */
        private Dictionary<Room, List<Room>> Rooms;

        /**
         * The room in which the room machine is.
         */
        private Room currentRoom;

        /**
         * The initial room of the room machine.
         */
        private Room startRoom;
        public static RoomMachine GetInstance() {
            if (instance == null)
            {
                instance = new RoomMachine();
                return instance;
            }
            else {
                return instance;
            }
        }
        /**
         * Default constructor, set all fields to values indicating that the room machine
         * has not yet been initialized.
         */
        private RoomMachine()
        {
           
            Rooms = new Dictionary<Room, List<Room>>();
            startRoom = null;
            currentRoom = null;
        }

        /**
         * Returns the room machine's current room, or null if no room has yet been added to
         * the room machine.
         */
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        /**
         * Returns a room with the specified name, or null if no room with the specified name
         * is contained in the room machine.
         */
        public Room GetRoomByName(string name)
        {
            foreach (Room room in Rooms.Keys)
            {
                if (room.GetName().Equals(name))
                {
                    return room;
                }
            }
            return null;
        }

        /**
         * Performs a transition from the current room to the specified target room, if such a transition
         * is possible.
         */
        public void MakeTransitionTo(Room toRoom)
        {

            /** first, check if the current room is set (that is, if the room maching has actually been
             initialized properly)... */
            if (currentRoom == null)
            {
                Console.WriteLine("Cannot make transition, current room is not defined");

            }

            // if the current state is set...
            else
            {

                /** get the current room's adjacency list (that is, all rooms to which a transition can be
                made from the current room)... **/
                List<Room> t = Rooms[currentRoom];

                // if the target room is contained in the current room's adjacency list (that is, if a
                // transition can be made from the current room to the target room), perform the transition...
                if (t.Contains(toRoom))
                {




                    // first, call the current room's OnRoomExit handler (to run any code that must
                    // be run when exiting the current room)...
                    currentRoom.OnRoomExit();

                    // then, change the current room to the target room...
                    currentRoom = toRoom;

                    // finally, call the new current room's (that is, the target room's) OnRoomEntry
                    // handler (to run any code that must be run when entering the target room)...
                    currentRoom.OnRoomEntry();
                }

                // a transition from the current room to the target room is not possible...
                else
                {
                    Console.WriteLine("This is not a valid exit");
                }
            }
        }

        /**
         * Add a room to the room machine. If the room maching is empty, also set it as a start
         * and current room.
         */
        public void AddRoom(Room room)
        {

            // if the current room has not been set (that is, if this is the first call to AddRoom)...
            if (startRoom == null)
            {

                // set the room state...
                startRoom = room;

                // set the room state...
                currentRoom = startRoom;

                // call the new current room's OnRoomEntry handler (to run any code that must be run
                // when entering the target room)...
                currentRoom.OnRoomEntry();
            }

            // if the room machine does not already contain the room...
            if (!Rooms.ContainsKey(room))
            {



                // create a new, empty adjacency list for the room...
                List<Room> t = new List<Room>();

                // add the room and its (empty) adjacency list to the room machine...
                Rooms.Add(room, t);

            }
            else
            {
                // the room already exists in the room machine, nothing to do...

            }
        }
       

        /**
         * Add a transition from a room to another room. Both rooms must already be in the
         * room machine.
         */
        public void AddTransition(Room fromRoom, Room toRoom)
        {

            // check if both rooms are in the room machine...
            if (Rooms.ContainsKey(fromRoom) && Rooms.ContainsKey(toRoom))
            {



                // get the from-room's adjacency list...
                List<Room> t = Rooms[fromRoom];

                // add the to-room to it...
                t.Add(toRoom);
            }
            else
            {
                // at least one of the two rooms has not already been added to the room machine,
                // cannot add the transition...
            }

        }
        public void TellCurrentNeighboors()
        {
            List<Room> tempList = new List<Room>();
            tempList = Rooms[currentRoom];
            foreach (Room room in tempList)
            {
                Console.WriteLine("Exit: " + room.GetName());
               
            }
            
        }
        public List<Room> GetNeighboors() {
            List<Room> tempList = new List<Room>();
            tempList = Rooms[currentRoom];
            return tempList;
        }
        public Room GetNeigboorByPointer(int pointerNumber) // finds Neighboor through index
        {
            Room[] tempArray = new Room[4];           
            tempArray = Rooms[currentRoom].ToArray();
            Room[] roomsArray = new Room[4];
            foreach (Room room in tempArray) {
                if (room.GetName() == "SOUTH")
                {
                    roomsArray[0] = room;

                }
                else if (room.GetName() == "NORTH")
                {
                    roomsArray[1] = room;
                }
                else if (room.GetName() == "WEST")
                {
                    roomsArray[2] = room;
                }
                else if (room.GetName() == "EAST")
                {
                    roomsArray[3] = room;
                }
                else if (room.GetName() == "CENTER") {
                    if (currentRoom.GetName() == "SOUTH")
                    {
                        roomsArray[1] = room;
                    }
                    else if (currentRoom.GetName() == "NORTH")
                    {
                        roomsArray[0] = room;
                    }
                    else if (currentRoom.GetName() == "WEST")
                    {
                        roomsArray[3] = room;
                    }
                    else if (currentRoom.GetName() == "EAST") {
                        roomsArray[2] = room;
                    }
                

                }

            }
            return roomsArray[pointerNumber];
            
           
        }
       
    }
 }
