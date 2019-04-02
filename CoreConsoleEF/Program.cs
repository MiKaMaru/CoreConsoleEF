using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CoreConsoleEF
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Добавление
            using (AppContext db = new AppContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // Добавление
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                // analog:
                /*
                 db.Users.AddRange(user1, user2);
                db.SaveChanges();
                 */
            }

            // получение/Чтение
            using (AppContext db = new AppContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Редактирование
            using (AppContext db = new AppContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //обновляем объект. нужно только в том случае, если мы внесли изменения вне конструкции using
                    //db.Users.Update(user);
                    //db.Users.UpdateRange(user1, user2);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Удаление
            using (AppContext db = new AppContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                    // analog:
                    /*
                     db.Users.RemoveRange(user1, user2);
                db.SaveChanges();
                     */
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.Read();
        }
    }
}