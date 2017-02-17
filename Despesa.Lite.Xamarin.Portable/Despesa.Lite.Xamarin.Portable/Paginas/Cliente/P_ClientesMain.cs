using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Cliente
{
    public class P_ClientesMain : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_alterar;
        ListView listV_Clientes;
        ObservableCollection<Domain.Cliente> Clientes;
        Domain.Cliente ClienteAlterado;
        Button b_adicionar;
        Button b_cancelar;
        Button b_alterar;
        Label l_tituloAddCliente;
        Label l_nome;
        Label l_razaoscial;
        Entry e_nome;
        Entry e_razaoscial;

        public P_ClientesMain()
        {
            Title = "Clientes";
            l_tituloAddCliente = new Label() { Text = "Adicoinar Cliente" };
            l_nome = new Label() { Text = "Nome" };
            l_razaoscial = new Label() { Text = "Razão Social" };
            e_nome = new Entry();
            e_razaoscial = new Entry();
            b_adicionar = new Button() { Text = "Adicionar Cliente" };
            b_cancelar = new Button() { Text = "Cancelar", IsVisible = false};
            b_alterar = new Button() { Text = "Alterar", IsVisible = false };
            Clientes = new ObservableCollection<Domain.Cliente>();
            listV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = Clientes };
            listV_Clientes.ItemTapped += ListV_Clientes_ItemTapped;
            b_adicionar.Clicked += B_adicionar_Clicked;
            b_cancelar.Clicked += B_cancelar_Clicked;
            b_alterar.Clicked += B_alterar_Clicked;
            sl_hori_alterar = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { b_cancelar, b_alterar } };
            sl_principal = new StackLayout() { Children = { l_tituloAddCliente, l_nome, e_nome, l_razaoscial, e_razaoscial, b_adicionar, sl_hori_alterar,listV_Clientes } };

            this.Content = sl_principal;

            CarregaClientes();

        }

        private async void B_alterar_Clicked(object sender, EventArgs e)
        {
            string link = Constantes.Server + Constantes.Server_Clientes + "/" + ClienteAlterado.Id;
            try
            {
                ClienteAlterado.Nome = e_nome.Text;
                ClienteAlterado.RazaoSocial = e_razaoscial.Text;

                var retorno = await WSOpen.Put(link, ClienteAlterado);

                if (retorno != null)
                {
                    e_nome.Text = "";
                    e_razaoscial.Text = "";
                    b_adicionar.IsVisible = true;
                    b_alterar.IsVisible = false;
                    b_cancelar.IsVisible = false;

                    Clientes.Add(ClienteAlterado);
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void B_cancelar_Clicked(object sender, EventArgs e)
        {
            b_adicionar.IsVisible = true;
            b_alterar.IsVisible = false;
            b_cancelar.IsVisible = false;

            e_nome.Text = "";
            e_razaoscial.Text = "";
        }

        private void ListV_Clientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cliente = e.Item as Domain.Cliente;
            ClienteAlterado = cliente;
            e_nome.Text = cliente.Nome;
            e_razaoscial.Text = cliente.RazaoSocial;

            b_adicionar.IsVisible = false;
            b_alterar.IsVisible = true;
            b_cancelar.IsVisible = true;

        }

        private async void B_adicionar_Clicked(object sender, EventArgs e)
        {
            string link = Constantes.Server + Constantes.Server_Clientes;

            try
            {
                var retorno = await WSOpen.Post(link, NovoCliente());
                if (retorno != null)
                {
                    Clientes.Add(retorno);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private Domain.Cliente NovoCliente()
        {
            Domain.Cliente Cliente = new Domain.Cliente()
            {
                Nome = e_nome.Text
                ,
                RazaoSocial = e_razaoscial.Text
            };

            return Cliente;
        }

        private async void CarregaClientes()
        {
            string link = Constantes.Server + Constantes.Server_Clientes;

            try
            {
               var listaClientes = await WSOpen.Get<List<Domain.Cliente>>(link);
                if (listaClientes != null && listaClientes.Count > 0)
                {
                    foreach (var item in listaClientes)
                    {
                        Clientes.Add(item);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
