﻿

namespace Tutorials.Data.Entities
{
    public class Teacher
    {
        public Teacher()
        {
          
        }
        public int TeacherId { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Secretary> Secretary { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        

        



    }
}