using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario
{
    public class P_UsuarioClientes : ContentPage
    {
        private readonly ApplicationUser _usuario;
        ToolbarItem ti_adicionarCliente;
        StackLayout sl_principal;
        ListView ListV_Clientes;
        ObservableCollection<Domain.Cliente> Clientes;
        List<Domain.Cliente> ClientesAdicionados;
        Label l_tituloLista;

        public P_UsuarioClientes(ApplicationUser usuario)
        {
            Title = usuario.Nome;

            this._usuario = usuario;

            l_tituloLista = new Label() { Text = "Clientes deste Usuario" };

            Clientes = new ObservableCollection<Domain.Cliente>();

            ListV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = Clientes };

            ti_adicionarCliente = new ToolbarItem("Adicionar Cliente", "", AdicionarClienteAoUsuario);

            this.ToolbarItems.Add(ti_adicionarCliente);

            this.Content = ListV_Clientes;
            this.Padding = 30;

            CarregaClientesUsuario();


        }

        private async void AdicionarClienteAoUsuario()
        {
            await Navigation.PushModalAsync(new P_UsuarioAddCliente());
        }

        private async void CarregaClientesUsuario()
        {
            string link = Constantes.Server + Constantes.Server_Cliente_Usuarios;
            try
            {
                var cliente_usuarios = await WSOpen.Get<List<Domain.Cliente_Usuarios>>(link);

                if (cliente_usuarios != null && cliente_usuarios.Count > 0)
                {
                    foreach (var clienteusuario in cliente_usuarios)
                    {
                        Clientes.Add(clienteusuario.Cliente);
                    }
                }
             
            }
            catch
            {

            }

        }
    }
}
