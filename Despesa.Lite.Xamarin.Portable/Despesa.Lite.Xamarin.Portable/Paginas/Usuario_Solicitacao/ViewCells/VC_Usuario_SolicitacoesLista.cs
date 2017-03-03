using Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewModels;
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
        StackLayout sl_vert_nomes;
        Label l_Companhia;
        Label l_Usuario;
        Label l_Status;
        Button b_aceitar;
        Button b_recusar;

        public delegate void Aceitar(Domain.Usuario_Solicitacao solicitacao);
        public static event Aceitar AceitarHandler;

        public delegate void Rejeitar(Domain.Usuario_Solicitacao solicitacao);
        public static event Rejeitar RejeitarHandler;

        public VC_Usuario_SolicitacoesLista()
        {
            b_aceitar = new Button() { Text = "Aceitar" };
            b_recusar = new Button() { Text = "Recusar" };
            l_Companhia = new Label() {  };
            l_Status = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand};
            l_Usuario = new Label() { };

            l_Usuario.SetBinding(Label.TextProperty, "UsuarioNome");
            l_Companhia.SetBinding(Label.TextProperty, "CompanhiaNome");
            l_Status.SetBinding(Label.TextProperty, "Status");
            l_Status.SetBinding(Label.TextColorProperty, "CorStatus");

            b_aceitar.Clicked += B_aceitar_Clicked;
            b_recusar.Clicked += B_recusar_Clicked;

            sl_vert_nomes = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, Children = {l_Companhia, l_Usuario } };

            sl_hori_principal = new StackLayout() {Padding = 30, Orientation = StackOrientation.Horizontal, Children = { sl_vert_nomes, l_Status ,b_aceitar , b_recusar} };

            this.View = sl_hori_principal;

        }

        private void B_recusar_Clicked(object sender, EventArgs e)
        {
            var vmsolicitacao = this.BindingContext as VM_Usuario_Solicitacoes;
            AceitarHandler(vmsolicitacao._usuarioSolicitacao);
        }

        private void B_aceitar_Clicked(object sender, EventArgs e)
        {
            var vmsolicitacao = this.BindingContext as VM_Usuario_Solicitacoes;
            AceitarHandler(vmsolicitacao._usuarioSolicitacao);
        }
    }
}
