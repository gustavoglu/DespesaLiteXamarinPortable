using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Domain
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        public string UserName{ get; set; }

        public string Nome { get; set; }

        public bool Companhia { get; set; }

        public bool Ativo { get; set; }

        public bool Deletado { get; set; }

        public virtual ICollection<Cliente_Usuarios> Cliente_Usuarios { get; set; }

        public virtual ICollection<Usuario_Solicitacao> Usuario_Solicitacoes { get; set; }

        public virtual ICollection<Usuario_Solicitacao> Companhia_Solicitacoes { get; set; }
    }
}
