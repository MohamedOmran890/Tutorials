
using System.ComponentModel.DataAnnotations;
using Tutorials.Data.Entities ;

namespace Tutorials.Api.DTO
{
    public class FilterDTO
    {
       public  List<int> Days {get; set;} 
        public List<Room> rooms{get; set;}
        public int typeRoom {get; set;}
        public string region {get; set;}
        public double price{get; set;}



    }



}