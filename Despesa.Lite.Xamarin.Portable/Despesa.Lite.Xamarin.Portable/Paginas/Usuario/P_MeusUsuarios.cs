using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario
{
   public class P_MeusUsuarios : ContentPage
    {
        StackLayout sl_principal;

        ObservableCollection<Domain.ApplicationUser> Usuarios;
        ListView listV_Usuarios;


        public P_MeusUsuarios()
        {
            Title = "Meus Usuarios";

            Usuarios = new ObservableCollection<Domain.ApplicationUser>();
            listV_Usuarios = new ListView() { HasUnevenRows = true, ItemsSource = Usuarios };
            listV_Usuarios.ItemTapped += ListV_Usuarios_ItemTapped;

            this.Content = listV_Usuarios;
            this.Padding = 30;


            CarregaMeusUsuarios();
        }

        private async  void ListV_Usuarios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var usuario = e.Item as ApplicationUser;

            await App.nav_request.PushAsync(new P_UsuarioClientes(usuario));

        }

        private async void CarregaMeusUsuarios()
        {
            string link = Constantes.Server + Constantes.Server_Usuarios + Constantes.Server_Usuarios_MeusUsuarios;
            try
            {
               var _usuarios = await WSOpen.Get<List<Domain.ApplicationUser>>(link);
                if (_usuarios != null && _usuarios.Count > 0)
                {
                    foreach (var usuario in _usuarios)
                    {
                        Usuarios.Add(usuario);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
