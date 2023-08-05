
using System.ComponentModel.DataAnnotations;
using Tutorials.Data.Entities ;
using Tutorials.Data.Enums ;
namespace Tutorial.Infstructures.DTO
{
    public class FilterDTO
    {
       public  List<int> Days {get; set;} 
        public TypeRoom TypeRoom {get; set;}
        public string Region {get; set;}
        public double Price{get; set;}



    }



}