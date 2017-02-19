using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario.ViewCells
{
   public class VC_UsuarioAddClienteLista : ViewCell
    {
        Label l_nomeCliente;
        Grid grid_principal;

        public VC_UsuarioAddClienteLista()
        {
            grid_principal = new Grid(); 
            l_nomeCliente = new Label() {  HorizontalOptions = LayoutOptions.CenterAndExpand};


            l_nomeCliente.SetBinding(Label.TextProperty, "ClienteNome");
            l_nomeCliente.SetBinding(Label.TextColorProperty, "CorClienteNome");
            grid_principal.SetBinding(Grid.BackgroundColorProperty, "CorSelecionado");

            this.grid_principal.Children.Add(l_nomeCliente);

            View = grid_principal;
            
        }
    }
}
