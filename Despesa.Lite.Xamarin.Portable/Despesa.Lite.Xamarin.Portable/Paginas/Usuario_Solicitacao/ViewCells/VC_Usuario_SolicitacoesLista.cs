using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewCells
{
    public class VC_Usuario_SolicitacoesLista : ViewCell
    {
        StackLayout sl_hori_principal;
        Label l_Companhia;
        Label l_Status;

        public VC_Usuario_SolicitacoesLista()
        {
            l_Companhia = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand};
            l_Status = new Label() { HorizontalOptions = LayoutOptions.End};

            l_Companhia.SetBinding(Label.TextProperty, "CompanhiaNome");
            l_Status.SetBinding(Label.TextProperty, "Status");
            l_Status.SetBinding(Label.TextColorProperty, "CorStatus");



            sl_hori_principal = new StackLayout() {Orientation = StackOrientation.Horizontal, Children = {l_Companhia , l_Status } };
            this.View = sl_hori_principal;



        }
    }
}
