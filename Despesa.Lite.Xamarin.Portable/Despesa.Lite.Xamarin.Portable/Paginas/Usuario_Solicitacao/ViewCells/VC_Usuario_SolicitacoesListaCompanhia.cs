using Despesa.Lite.Xamarin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewCells
{
    public class VC_Usuario_SolicitacoesListaCompanhia : ViewCell
    {
        StackLayout sl_hori_principal;
        Label l_Companhia;
        Button b_Enviar;

        public delegate void EnviaSolicitacao(string IdCompanhia);

        public static event EnviaSolicitacao EnviaSolicitacao_Handler;

        public VC_Usuario_SolicitacoesListaCompanhia()
        {
            l_Companhia = new Label() { HorizontalOptions =  LayoutOptions.CenterAndExpand };
            b_Enviar = new Button() { Text = "Enviar Solicitação", HorizontalOptions = LayoutOptions.EndAndExpand };

            l_Companhia.SetBinding(Label.TextProperty, "Nome");

            b_Enviar.Clicked += B_Enviar_Clicked;


            sl_hori_principal = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { l_Companhia, b_Enviar } };
            this.View = sl_hori_principal;
        }

        private void B_Enviar_Clicked(object sender, EventArgs e)
        {
            var Companhia = BindingContext as ApplicationUser;

            EnviaSolicitacao_Handler(Companhia.Id);
        }
    }
}
