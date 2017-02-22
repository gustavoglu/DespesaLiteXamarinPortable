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

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao
{
    public class P_Usuario_SolicitacoesEnviar : ContentPage
    {
        ListView listV_Companhias;
        ObservableCollection<ApplicationUser> Companhias;

        public P_Usuario_SolicitacoesEnviar()
        {
            Companhias = new ObservableCollection<ApplicationUser>();
            listV_Companhias = new ListView() { HasUnevenRows = true, ItemsSource = Companhias };



            this.Content = listV_Companhias;
        }


        private async void CarregaCompanhias()
        {
            string link = Constantes.Server + Constantes.Server_Usuarios_Companhias;

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
