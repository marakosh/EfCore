using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    public class ForecastHistory
    {
        public int Id { get; set; }
        public string Icon { get; set; } 
        public string CityName { get; set; } = null!;
        public float Temp { get; set; }
        public int Humidity { get; set; }
        public float FeelsLike { get; set; }
        public float WindSpeed { get; set; }
        public int Pressure { get; set; }
        public virtual City City { get; set; } = null!;
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ForecastHistory> ForecastHistories { get; set; } = null!;
    }
}
