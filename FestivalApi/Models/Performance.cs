using System;
namespace FestivaLApi.Models
{
    public class Performance
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
