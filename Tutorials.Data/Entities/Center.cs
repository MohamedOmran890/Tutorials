﻿using System.ComponentModel.DataAnnotations;

namespace Tutorials.Data.Entities
{
    public class Center
    {
        public Center()
        {
           

        }
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers {get; set;}

    }
}