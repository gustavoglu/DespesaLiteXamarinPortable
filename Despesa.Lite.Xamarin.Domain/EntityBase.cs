using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Domain
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public string CriadoPor { get; set; } = "";

        public string DeletadoPor { get; set; } = "";

        public string AtualizadoPor { get; set; } = "";

        public string AtivadoPor { get; set; } = "";

        public string DesativadoPor { get; set; } = "";

        public DateTime? CriadoEm { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public bool? Ativo { get; set; }

        public bool? Deletado { get; set; }
    }
}
