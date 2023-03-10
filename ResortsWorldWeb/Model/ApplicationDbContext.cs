using Microsoft.EntityFrameworkCore;
using ResortsWorldWeb.Model.Entity;

namespace ResortsWorldWeb.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Resport> Resports { get; set; }
        public DbSet<PartOfTheWorld> PartOfTheWorlds { get; set; }
        public DbSet<Country> Countries { get; set; }

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
