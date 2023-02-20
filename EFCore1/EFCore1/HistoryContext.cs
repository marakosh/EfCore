using EFCore1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    public class HistoryContext : DbContext
    {
        public DbSet<ForecastHistory> ForecastHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=History;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public List<ForecastHistory> GetAllForecastHistoriesWithEagerLoading()
        {
            return ForecastHistories.Include(f => f.City)
                                    .ToList();
        }
    }
}


//using (var context = new HistoryContext())
//{
//    List<ForecastHistory> forecastHistories = context.GetAllForecastHistoriesWithEagerLoading();
//}
