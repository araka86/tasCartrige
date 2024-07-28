using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartrigeAltstar.Model
{
    public class CountCartige
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Модель")]
        public string ModelCartrige { get; set; }

        [DisplayName("Кількість")]
        public int CountCartrige { get; set; }

        [DisplayName("Дата")]
        public DateTime? purchase_date { get; set; } = DateTime.Now;


        public int CartrigeId { get; set; } // Foreign Key
        public virtual Cartrige Cartrige { get; set; } // Reference to Cartrige

    }
}
