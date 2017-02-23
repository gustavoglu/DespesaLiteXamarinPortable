using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewCells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao
{
    public class P_Usuario_SolicitacoesNovaSolicitacao : ContentPage
    {
        ListView listV_Companhias;
        ObservableCollection<ApplicationUser> Companhias;

        public P_Usuario_SolicitacoesNovaSolicitacao()
        {

            Title = "Nova Solicitação";

            VC_Usuario_SolicitacoesListaCompanhia.EnviaSolicitacao_Handler += VC_Usuario_SolicitacoesListaCompanhia_EnviaSolicitacao_Handler;

            Companhias = new ObservableCollection<ApplicationUser>();

            listV_Companhias = new ListView() { HasUnevenRows = true, ItemsSource = Companhias };
            listV_Companhias.ItemTemplate = new DataTemplate(typeof(VC_Usuario_SolicitacoesListaCompanhia));


            this.Content = listV_Companhias;

            CarregaCompanhias();

        }

        private async void VC_Usuario_SolicitacoesListaCompanhia_EnviaSolicitacao_Handler(string idCompanhia)
        {
            string link = Constantes.Server + Constantes.Server_Usuario_Solicitacoes;

            try
            {
                var usuarioSolicitacao = new Domain.Usuario_Solicitacao()
                {
                    id_companhia = idCompanhia
                };

               var resposta = await WSOpen.Post(link, usuarioSolicitacao);

                if (resposta != null)
                {

                }

            }
            catch
            {

            }
        }

        private async void CarregaCompanhias()
        {
            string link = Constantes.Server + Constantes.Server_Usuarios + Constantes.Server_Usuarios_Companhias;

            try
            {
                var retorno = await WSOpen.Get<List<Domain.ApplicationUser>>(link);
                if (retorno != null && retorno.Count > 0)
                {
                    foreach (var item in retorno)
                    {
                        Companhias.Add(item);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
