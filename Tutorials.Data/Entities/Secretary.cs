﻿namespace Tutorials.Data.Entities
{
    public class Secretary:User
    {
        public Secretary()
        {
            
        }
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}