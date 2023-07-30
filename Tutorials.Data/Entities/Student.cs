﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    public class Student
    {
        public Student()
        {
            Address = new Address();
            Rooms = new List<Room>();

        }
        public int StudentId { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
