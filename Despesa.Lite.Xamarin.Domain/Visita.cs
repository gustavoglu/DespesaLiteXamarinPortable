using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Domain
{
   public class Visita : EntityBase
    {
        public DateTime Data { get; set; }

        public TimeSpan HoraChegada { get; set; }

        public TimeSpan HoraSaida { get; set; }

        public TimeSpan TempoImprodutivo { get; set; }

        public string Observações { get; set; }

        public virtual ICollection<Despesa> Despesas { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
