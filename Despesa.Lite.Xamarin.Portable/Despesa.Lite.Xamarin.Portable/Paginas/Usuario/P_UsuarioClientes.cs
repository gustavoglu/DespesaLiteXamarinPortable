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
        P_UsuarioAddCliente Page_UsuarioAdicionarCliente;
        ObservableCollection<Cliente_Usuarios> Cliente_Usuarios;

        public P_UsuarioClientes(ApplicationUser usuario)
        {
            Title = usuario.Nome;

           // Page_UsuarioAdicionarCliente = new P_UsuarioAddCliente(Cliente_Usuarios.ToList(), _usuario);

            P_UsuarioAddCliente.AtualizarLista_Handler += P_UsuarioAddCliente_AtualizarLista_Handler; ;

            this._usuario = usuario;

            l_tituloLista = new Label() { Text = "Clientes deste Usuario" };

            Cliente_Usuarios = new ObservableCollection<Cliente_Usuarios>();

            ListV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = Clientes };

            ti_adicionarCliente = new ToolbarItem("Adicionar Cliente", "", AdicionarClienteAoUsuario);

            this.ToolbarItems.Add(ti_adicionarCliente);

            this.Content = ListV_Clientes;
            this.Padding = 30;

            CarregaClientesUsuario();


        }

        private void P_UsuarioAddCliente_AtualizarLista_Handler()
        {
            Cliente_Usuarios.Clear();
            CarregaClientesUsuario();
        }

        private void Page_UsuarioAdicionarCliente_ClientesSelecionados_Handler(List<Domain.Cliente> ClientesAAdicionar, List<Domain.Cliente> ClientesARemover)
        {
            foreach (var aremover in ClientesARemover)
            {
                if (Clientes.ToList().Exists(c => c.Id == aremover.Id))
                {
                    Clientes.Remove(aremover);
                }
            }

            foreach (var aadicionar in ClientesAAdicionar)
            {
                if (!Clientes.ToList().Exists(c => c.Id == aadicionar.Id))
                {
                    Clientes.Add(aadicionar);
                }
            }
        }

        private async void AdicionarClienteAoUsuario()
        {
            await Navigation.PushModalAsync(new P_UsuarioAddCliente(Cliente_Usuarios.ToList(), _usuario));
        }

        private async void CarregaClientesUsuario()
        {
            string link = Constantes.Server + Constantes.Server_Cliente_Usuarios;
            try
            {
                var cliente_usuarios = await WSOpen.Get<List<Domain.Cliente_Usuarios>>(link);

                if (cliente_usuarios != null && cliente_usuarios.Count > 0)
                {
                    foreach (var item in cliente_usuarios)
                    {
                        Cliente_Usuarios.Add(item);
                    }
                }

                //Page_UsuarioAdicionarCliente = new P_UsuarioAddCliente(Cliente_Usuarios.ToList(), _usuario);

            }
            catch
            {

            }

        }
    }
}
