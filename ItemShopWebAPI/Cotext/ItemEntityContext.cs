using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Cotext
{
    public class ItemEntityContext : DbContext
    {

        //private string _connectionString;
        //public ItemEntityContext(IConfiguration configuration)
        //{
        //     _connectionString = configuration.GetConnectionString("PostgreConnection");
        //}

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(_connectionString);
        public DbSet<ItemEntity> ItemEntity {  get; set; }

        public ItemEntityContext(DbContextOptions<ItemEntityContext> options) : base(options)
        {

        }



    }
}
