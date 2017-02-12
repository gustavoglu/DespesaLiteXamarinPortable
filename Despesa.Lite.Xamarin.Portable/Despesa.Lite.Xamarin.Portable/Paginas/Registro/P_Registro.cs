using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Registro
{
    public class P_Registro : ContentPage
    {

        StackLayout sl_principal;
        Label l_nome;
        Label l_email;
        Label l_senha;
        Label l_confirmasenha;
        Entry e_nome;
        Entry e_email;
        Entry e_senha;
        Entry e_confirmasenha;
        Button b_registrar;

        public P_Registro()
        {
            Title = "Registro";

            l_nome = new Label();
            l_email = new Label();
            l_senha = new Label();
            l_confirmasenha = new Label();
            e_nome = new Entry();
            e_email = new Entry();
            e_senha = new Entry();
            e_confirmasenha = new Entry();
            b_registrar = new Button();



            sl_principal = new StackLayout();
            this.Content = sl_principal;

        }
    }
}
