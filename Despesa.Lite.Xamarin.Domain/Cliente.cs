using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Domain
{
   public class Cliente : EntityBase
    {
        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }

        public virtual ICollection<Cliente_Usuarios> Cliente_Usuarios { get; set; }
    }
}
