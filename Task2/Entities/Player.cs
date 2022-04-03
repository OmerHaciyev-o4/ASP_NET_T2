using Microsoft.AspNetCore.Http;

namespace Task2.Entities
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string URL { get; set; }
        public int Age { get; set; }
        public IFormFile File { get; set; }
    }
}