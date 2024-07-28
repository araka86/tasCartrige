using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
    public class Cartrige
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Модель")]
        public string ModelCartrige { get; set; }

        [DisplayName("Артикль")]
        public string ArticleCartrige { get; set; }

        [DisplayName("Дата")]
        public DateTime? purchase_date { get; set; } = DateTime.Now.AddDays(-5);

        [DisplayName("Кількість")]
        public int CountCartrige { get; set; }

  //      public int CountCartigeFK { get; set; }

        public bool IsService { get; set; }

        public virtual ICollection<Printer> Printers { get; set; }
        public virtual ICollection<Compatibility> Compatibilitys { get; set; }


   
        public virtual ICollection<CountCartige> CountCartiges { get; set; } // Changed to ICollection



        //public virtual ICollection<CountCartige> CountCartiges { get; set; } // Коллекция связанных CountCartige

        //public Cartrige()
        //{
        //    CountCartiges = new HashSet<CountCartige>(); // Инициализация коллекции
        //}

    }
}
