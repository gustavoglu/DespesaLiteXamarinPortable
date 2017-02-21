using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario.ViewCells;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario
{
    public class P_UsuarioAddCliente : ContentPage
    {
        StackLayout sl_principal;
        ToolbarItem ti_adicionarClientes;
        ObservableCollection<VM_SelecionaClientes> VM_Clientes;
        ListView listV_Clientes;
        List<Domain.Cliente_Usuarios> _cliente_UsuariosDoUsuario;
        ApplicationUser _usuario;

        public delegate void AtualizarLista();
        public static event AtualizarLista AtualizarLista_Handler;


        public P_UsuarioAddCliente(List<Domain.Cliente_Usuarios> clientesDoUsuario, ApplicationUser usuario)
        {
            Title = "Adicionar Clientes ao Usuario";

            _cliente_UsuariosDoUsuario = clientesDoUsuario;
            _usuario = usuario;

            VM_Clientes = new ObservableCollection<VM_SelecionaClientes>();
            listV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = VM_Clientes };
            listV_Clientes.ItemTapped += ListV_Clientes_ItemTapped;
            listV_Clientes.ItemTemplate = new DataTemplate(typeof(VC_UsuarioAddClienteLista));

            ti_adicionarClientes = new ToolbarItem("Confirmar", "", AdicionarClientesEscolhidos);
            this.ToolbarItems.Add(ti_adicionarClientes);

            this.Content = listV_Clientes;
            // this.Padding = 30;

            CarregarClientes();

        }

        private void ListV_Clientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vmcliente = e.Item as VM_SelecionaClientes;

            var listview = sender as ListView;
            listview.SelectedItem = null;

            vmcliente.Selecionado = !vmcliente.Selecionado;

        }

        private async void AdicionarClientesEscolhidos()
        {
            List<Domain.Cliente_Usuarios> ClientesARemover = new List<Domain.Cliente_Usuarios>();

            List<Domain.Cliente> ClientesAAdicionar = new List<Domain.Cliente>();


            foreach (var vmclientes in VM_Clientes.Where(s => s.Selecionado == true))
            {
                if (!_cliente_UsuariosDoUsuario.Exists(c => c.Id == vmclientes._cliente.Id))
                {
                    ClientesAAdicionar.Add(vmclientes._cliente);
                }
            }

            foreach (var vmclientes in VM_Clientes.Where(s => s.Selecionado == false))
            {
                if (_cliente_UsuariosDoUsuario.Exists(c => c.id_cliente == vmclientes._cliente.Id))
                {
                    ClientesARemover.Add(_cliente_UsuariosDoUsuario.SingleOrDefault(c => c.id_cliente == vmclientes._cliente.Id));
                }
            }

            if (ClientesARemover.Count > 0 )
            {
                RemoverClientes(ClientesARemover);
            }

            if (ClientesAAdicionar.Count > 0)
            {
                AdicionaClientes(ClientesAAdicionar);
            }

            if (ClientesAAdicionar.Count > 0 || ClientesARemover.Count > 0)
            {
                AtualizarLista_Handler();
            }
            

            await Navigation.PopModalAsync(true);
        }

        private async void CarregarClientes()
        {

            try
            {
                var retorno = await WSOpen.GetClientes();

                if (Constantes.Clientes != null && Constantes.Clientes.Count > 0)
                {
                    foreach (var cliente in Constantes.Clientes)
                    {
                        VM_Clientes.Add(new VM_SelecionaClientes(cliente));
                    }

                }
            }
            catch
            {

            }
        }

        private async void AdicionaClientes(List<Domain.Cliente> ClientesAAdicionar)
        {
            List<Cliente_Usuarios> Cliente_UsuariosAAdicionar = new List<Cliente_Usuarios>();

            string link = Constantes.Server + Constantes.Server_Cliente_UsuariosLista;

            foreach (var clientes in ClientesAAdicionar)
            {
                Cliente_UsuariosAAdicionar.Add(new Cliente_Usuarios()
                {
                    id_cliente = clientes.Id,
                    id_usuario = _usuario.Id
                });
            }

            try
            {
               var resposta = await WSOpen.Post(link, Cliente_UsuariosAAdicionar);
            }
            catch
            {

            }
        }

        private async void RemoverClientes(List<Domain.Cliente_Usuarios> Clientes_UsuariosARemover)
        {
            string link = Constantes.Server + Constantes.Server_Cliente_UsuariosListaDelete;

            try
            {
                var resposta = await WSOpen.Post(link, Clientes_UsuariosARemover);
            }
            catch
            {

            }
        }

    }


}
