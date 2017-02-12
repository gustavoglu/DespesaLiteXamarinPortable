using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Portable.Aplicacao
{
   public class Constantes
    {
        public static string TokenUsuario { get; set; }

        public const string Server = "http://localhost:57712/";

        public const string Server_Token = "Token";

        public const string Server_Register = "api/Account/Register";

        public const string Server_Visitas = "api/Visitas";

        public const string Server_Despesas = "api/despesas";

        public const string Server_Usuario_Solicitacoes= "api/Usuario_Solicitacoes";

        public const string Server_Clientes = "api/Clientes";

        public const string Server_Cliente_Usuarios= "api/Cliente_Usuarios";




    }
}
