using Despesa.Lite.Xamarin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Portable.Aplicacao
{
   public class Constantes
    {

        public static ICollection<Cliente> Clientes { get; set; }

        public static List<string> Tempo = new List<string>()
        {
            "00:00","00:30","01:00","01:30","02:00","02:30","03:00","03:30","04:00","04:30","05:00","05:30","06:00","06:30","07:00","07:30",
            "08:00","08:30","09:00","09:30","10:00","10:30","11:00","11:30","12:00","12:30","13:00","13:30","14:00","14:30","15:00","15:30",
            "16:00","16:30","17:00","17:30","18:00","18:30","19:00","19:30","20:00","20:30","21:00","21:30","22:00","22:30","23:00","23:30",
            "24:00","24:30"
        };

        public static string TokenUsuario { get; set; }

        public const string Server = "http://localhost:57712/";

        public const string Server_Token = "Token";

        public const string Server_Register = "api/Account/Register";

        public const string Server_Visitas = "api/Visitas";

        public const string Server_Despesas = "api/despesas";

        public const string Server_Usuario_Solicitacoes= "api/Usuario_Solicitacoes";

        public const string Server_Usuario_Solicitacoes_Aceitar = "api/Usuario_Solicitacoes/Aceitar";

        public const string Server_Usuario_Solicitacoes_Recusar = "api/Usuario_Solicitacoes/Recusar";

        public const string Server_Clientes = "api/Clientes";

        public const string Server_Usuarios= "api/Usuarios";

        public const string Server_Usuarios_MeusUsuarios = "/MeusUsuarios";

        public const string Server_Usuarios_Companhias = "/Companhias";

        public const string Server_Cliente_Usuarios= "api/Cliente_Usuarios";

        public const string Server_Cliente_UsuariosLista = "api/Cliente_UsuariosLista";

        public const string Server_Cliente_UsuariosListaDelete = "api/Cliente_UsuariosListaDelete";

        public const string Server_Cliente_Usuarios_TrazerClientesDoUsuario = "api/Cliente_Usuarios/TrazerClientesDoUsuario";




    }
}
