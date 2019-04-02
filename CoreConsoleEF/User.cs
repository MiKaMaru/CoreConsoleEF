using System.ComponentModel.DataAnnotations;

namespace CoreConsoleEF
{
    public class User
    {
        public int Id { get; set; }
        [Required] //аннотация о том, что Name обязательно должно иметь значение
        public string Name { get; set; }
        public int Age { get; set; }
        // навигационное свойство
        public Company Manufacturer { get; set; }

    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Tablet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}


///необходимо изучить, что такое миграции