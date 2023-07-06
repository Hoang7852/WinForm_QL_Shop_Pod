using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class BaoCao
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public DateTime Ngay { get; set; }
        public double DoanhThu { get; set; }
    }
}
