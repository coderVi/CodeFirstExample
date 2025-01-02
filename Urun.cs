using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstV1
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal BirimFiyat { get; set; }
        public int StokAdet {  get; set; }
        public string Aciklama { get; set; }

        public override string ToString()
        {

            return Ad + "("+StokAdet+")";
        }
    }
}
