using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Domain
{
   public class Cliente_Usuarios : EntityBase
    {
        public string id_usuario { get; set; } = null;

        public Guid? id_cliente { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
    }
}
