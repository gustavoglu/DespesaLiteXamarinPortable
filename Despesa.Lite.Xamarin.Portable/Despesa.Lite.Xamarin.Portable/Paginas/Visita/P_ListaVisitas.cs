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

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita
{
    public class P_ListaVisitas : ContentPage
    {
        protected StackLayout sl_principal;
        protected ListView listV_visitas;
        protected ToolbarItem ti_adicionar;
        protected ObservableCollection<Domain.Visita> Visitas;

        public P_ListaVisitas()
        {
            Title = "Visitas";

            Visitas = new ObservableCollection<Domain.Visita>();
            ti_adicionar = new ToolbarItem("", "", NovaVisita);
            listV_visitas = new ListView()
            {
                ItemsSource = Visitas,
                HasUnevenRows = true,
            };

            listV_visitas.ItemTapped += ListV_visitas_ItemTapped;



            sl_principal = new StackLayout() { Children = { listV_visitas } };
            this.ToolbarItems.Add(ti_adicionar);
            this.Content = sl_principal;


            CarregaListaVisita();
        }

        private void ListV_visitas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
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

            var cliente = await WSOpen.Get<Cliente>(linkcliente + "/" + "ae8caf41-5495-47ac-a385-6869d723d71e");



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
    }
}
