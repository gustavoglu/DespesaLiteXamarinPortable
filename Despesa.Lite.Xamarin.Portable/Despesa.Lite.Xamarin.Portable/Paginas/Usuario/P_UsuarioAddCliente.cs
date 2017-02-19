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
        List<Domain.Cliente> _clientesDoUsuario;

        public delegate void ClientesSelecionados(List<Domain.Cliente> ClientesAAdicionar, List<Domain.Cliente> ClientesARemover);
        public static event ClientesSelecionados ClientesSelecionados_Handler;


        public P_UsuarioAddCliente(List<Domain.Cliente> clientesDoUsuario)
        {
            Title = "Adicionar Clientes ao Usuario";

            _clientesDoUsuario = clientesDoUsuario;

            VM_Clientes = new ObservableCollection<VM_SelecionaClientes>();
            listV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = VM_Clientes};
            listV_Clientes.ItemTapped += ListV_Clientes_ItemTapped;
            listV_Clientes.ItemTemplate = new DataTemplate(typeof(VC_UsuarioAddClienteLista));

            ti_adicionarClientes = new ToolbarItem("Confirmar","", AdicionarClientesEscolhidos);
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
            List<Domain.Cliente> ClientesARemover = new List<Domain.Cliente>();

            List<Domain.Cliente> ClientesAAdicionar = new List<Domain.Cliente>();


            foreach (var vmclientes in VM_Clientes.Where(s => s.Selecionado == true))
            {
                if (! _clientesDoUsuario.Exists(c => c.Id == vmclientes._cliente.Id))
                {
                    ClientesAAdicionar.Add(vmclientes._cliente);
                } 
            }

            foreach (var vmclientes in VM_Clientes.Where(s => s.Selecionado == false))
            {
                if (_clientesDoUsuario.Exists(c => c.Id == vmclientes._cliente.Id))
                {
                    ClientesARemover.Add(vmclientes._cliente);
                }
            }

            if (ClientesARemover.Count > 0 || ClientesAAdicionar.Count > 0)
            {
                ClientesSelecionados_Handler(ClientesAAdicionar, ClientesARemover);
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
        
    }


}
