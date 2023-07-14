using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApplication1.Models
{
    public class Door
    {


        public int Id { get; set; }
       

        public double? X { get; set; }

        public double? Y { get; set; }

        public Door()
        {
            Id = 0;
            X = 0;
            Y = 0;
        }

        
    }
}
