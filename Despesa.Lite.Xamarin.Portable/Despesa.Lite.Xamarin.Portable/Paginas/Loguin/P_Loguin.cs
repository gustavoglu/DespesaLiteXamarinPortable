using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using System;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Loguin
{
    public class P_Loguin : ContentPage
    {
        StackLayout sl_principal;
        Label l_email;
        Label l_senha;
        Entry e_email;
        Entry e_senha;
        Button b_loguin;

        public P_Loguin()
        {
            l_email = new Label() { Text = "E-mail", HorizontalOptions = LayoutOptions.CenterAndExpand, HorizontalTextAlignment = TextAlignment.Center };
            e_email = new Entry() { Placeholder = "", HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_senha = new Entry() { Placeholder = "", HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_senha = new Label() { Text = "Senha", HorizontalOptions = LayoutOptions.CenterAndExpand, HorizontalTextAlignment = TextAlignment.Center };
            b_loguin = new Button() { Text = "Logar", HorizontalOptions = LayoutOptions.CenterAndExpand };

            b_loguin.Clicked += B_loguin_Clicked;

            sl_principal = new StackLayout() { Children = { l_email, e_email, l_senha, e_senha, b_loguin } };
            this.Content = sl_principal;

        }

        private async void B_loguin_Clicked(object sender, EventArgs e)
        {
            var response = await WSOpen.GetToken(e_email.Text, e_senha.Text);
            if (response)
            {
                await DisplayAlert("", "Ok", "ok");
            }else
            {
                await DisplayAlert("", "erro", "ok");
            }
        }
    }
}
