using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Cliente;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita
{
    public class P_ListaVisitas : ContentPage
    {
        protected StackLayout sl_principal;
        protected ListView listV_visitas;
        protected ToolbarItem ti_adicionar;
        protected ToolbarItem ti_clientes;
        protected ToolbarItem ti_meususuarios;
        protected ToolbarItem ti_solicitacoes;
        protected ObservableCollection<Domain.Visita> Visitas;

        public P_ListaVisitas()
        {
            Title = "Visitas";

            Visitas = new ObservableCollection<Domain.Visita>();

            listV_visitas = new ListView()
            {
                ItemsSource = Visitas,
                HasUnevenRows = true,
            };

            listV_visitas.ItemTapped += ListV_visitas_ItemTapped;

            ti_adicionar = new ToolbarItem("Nova Visita", "", NovaVisita);
            ti_clientes = new ToolbarItem("Clientes", "", Clientes);
            ti_meususuarios = new ToolbarItem("Meus Usuarios", "", MeusUsuarios);
            ti_solicitacoes = new ToolbarItem("Solicitações", "", Solicitacoes);
            this.ToolbarItems.Add(ti_adicionar);
            this.ToolbarItems.Add(ti_clientes);
            this.ToolbarItems.Add(ti_meususuarios);
            this.ToolbarItems.Add(ti_solicitacoes);

            sl_principal = new StackLayout() { Children = { listV_visitas } };

            this.Content = sl_principal;


            CarregaListaVisita();
        }

        private void ListV_visitas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Clientes()
        {
            await App.nav_request.PushAsync(new P_ClientesMain());
        }

        private void MeusUsuarios()
        {
            App.nav_request.PushAsync(new P_MeusUsuarios());
        }

        private async void CarregaListaVisita()
        {
            string link = Constantes.Server + Constantes.Server_Visitas;
            try
            {
                var lista = await WSOpen.Get<List<Domain.Visita>>(link);
                if (lista != null || lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        Visitas.Add(item);
                    }

                }
                else
                {

                }

            }
            catch
            {

            }
        }

        private async void NovaVisita()
        {
            await App.nav_request.PushAsync(new P_NovaVisita());
        }

        async void testeVisita()
        {
            string link = Constantes.Server + Constantes.Server_Visitas;
            string linkcliente = Constantes.Server + Constantes.Server_Clientes;

            var cliente = await WSOpen.Get<Domain.Cliente>(linkcliente + "/" + "ae8caf41-5495-47ac-a385-6869d723d71e");



            //Cliente cliente = new Cliente()
            //{
            //    Nome = "teste2"
            //    , RazaoSocial = "teste2"
            //};
            var Despesas = new List<Domain.Despesa>()
             {
                 new Domain.Despesa()
                 {
                      Detalhes = "teste",
                       Pedagio = 10,
                        Quilometragem = 10,
                        Outros = 10,
                        Refeicao = 10,
                 }
             };
            var visita = new Domain.Visita()
            {
                id_cliente = cliente.Id,
                Data = DateTime.Now.Date,
                Observações = "teste",
                HoraChegada = DateTime.Now.TimeOfDay,
                HoraSaida = DateTime.Now.TimeOfDay,
                TempoImprodutivo = DateTime.Now.TimeOfDay,
                Despesas = Despesas

            };

            await WSOpen.Post<Domain.Visita>(link, visita);
        }

        async void Solicitacoes()
        {
            await App.nav_request.PushAsync(new P_Usuario_SolicitacoesLista());
        }
    }
}
