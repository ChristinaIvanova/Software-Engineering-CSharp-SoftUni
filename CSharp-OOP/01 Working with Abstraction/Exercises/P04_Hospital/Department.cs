using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        private const int capacity = 20;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.CreateRooms();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void AddBedToRoom(Bed bed)
        {
            Room currentRoom = this.Rooms.Where(x => !x.isFull).FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.AddBedToRoom(bed);
            }

        }

        public void CreateRooms()
        {
            for (int i = 0; i < capacity; i++)
            {
                this.Rooms.Add(new Room());
            }
        }
    }
}
