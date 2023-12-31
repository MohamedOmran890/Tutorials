﻿using System.ComponentModel.DataAnnotations;
using System.Timers;
using Tutorials.Data.Enums;
using Tutorials.Data.Enums;

namespace Tutorials.Data.Entities
{
    public class Room
    {
        public Room()
        {
            
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public TypeRoom TypeRoom { get; set; } 
        public int CurrentStudentNumber { get; set; }
        public int SizeRoom { get; set; }
        public double Duration { get; set; }
        
        public DayRoom DayOfWeeks { get; set; }
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<RoomStudent> RoomStudents { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int LevelId { get; set; }
        public virtual Level Level { get; set; }


        
    }
}