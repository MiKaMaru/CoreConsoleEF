using Microsoft.EntityFrameworkCore;

namespace CoreConsoleEF
{
    ///первый способ подключения без поддержки конфигурационного json файла
    //DbContext - определяет контекст данных
    public class AppContext : DbContext
    {
        private static string dbName = "P10131\\SQLEXPRESS";
        private string strSqlConn = "Server=" + dbName + ";Database=hello1;Trusted_Connection=True;";
        //DbSet - предоставляет набор объектов, хранящихся в БД
        //virtual - если уже создано и есть внутренние правила
        public DbSet<User> Users { get; set; }
        public AppContext()
        {
            //если нет БД, то создаст
            Database.EnsureCreated();
        }
        //самая длинная фигня в функции - устанавливает параметры подключения / билдер подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strSqlConn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }

    /// второй способ поключения
    //public class AppContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }

    //    public AppContext(DbContextOptions<AppContext> options)
    //        : base(options)
    //    {
    //        Database.EnsureCreated();
    //    }

    //}
}
