using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstV1
{
    public class UrunlerContext : DbContext
    {
        public UrunlerContext() : base("baglanti")
        {
            
        }
        public virtual DbSet<Urun> Urunler { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }

    }
}
