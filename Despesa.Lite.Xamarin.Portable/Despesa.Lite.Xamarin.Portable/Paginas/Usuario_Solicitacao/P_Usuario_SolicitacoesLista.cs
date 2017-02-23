using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Despesa.Lite.Xamarin.Domain;
using Xamarin.Forms;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewModels;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao
{
   public class P_Usuario_SolicitacoesLista : ContentPage
    {
        ListView listV_Usuario_Solicitacoes;
        ObservableCollection<VM_Usuario_Solicitacoes> Usuario_Solicitacoes;
        ToolbarItem ti_NovaSolicitacao;

        public P_Usuario_SolicitacoesLista()
        {
            Title = "Solicitações de Usuarios";

            Usuario_Solicitacoes = new ObservableCollection<VM_Usuario_Solicitacoes>();
            listV_Usuario_Solicitacoes = new ListView() { HasUnevenRows = true, ItemsSource = Usuario_Solicitacoes };
            listV_Usuario_Solicitacoes.ItemTemplate = new DataTemplate(typeof(VM_Usuario_Solicitacoes));
            ti_NovaSolicitacao = new ToolbarItem("Nova Solicitação", "", NovaSolicitacao);

            this.ToolbarItems.Add(ti_NovaSolicitacao);
            this.Content = listV_Usuario_Solicitacoes;

            CarregaSolicitacoes();
        }

        private async void NovaSolicitacao()
        {
            await Navigation.PushModalAsync(new P_Usuario_SolicitacoesNovaSolicitacao());
        }

        private async void CarregaSolicitacoes()
        {
            string link = Constantes.Server + Constantes.Server_Usuario_Solicitacoes;
            try
            {

                var retorno = await WSOpen.Get<List<Domain.Usuario_Solicitacao>>(link);

                if (retorno != null && retorno.Count > 0)
                {
                    foreach (var item in retorno)
                    {
                        Usuario_Solicitacoes.Add(new VM_Usuario_Solicitacoes(item));
                    }
                }

            }catch
            {

            }
        }
    }
}
