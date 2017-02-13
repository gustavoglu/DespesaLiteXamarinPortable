using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Registro;
using Despesa.Lite.Xamarin.Portable.Paginas.Visita;
using System;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Loguin
{
    public class P_Loguin : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_loguin;
        Grid grid_botoes;
        Label l_email;
        Label l_senha;
        Entry e_email;
        Entry e_senha;
        Button b_loguin;
        Button b_registro;

        public P_Loguin()
        {
            Title = "Loguin";

            l_email = new Label() { Text = "E-mail", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };
            e_email = new Entry() { Text = "admin@admin.com",WidthRequest= 150, Placeholder = "", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_senha = new Entry() { Text = "Giroldinhu20!" ,WidthRequest = 150, Placeholder = "", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_senha = new Label() { Text = "Senha", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };
            b_loguin = new Button() { Text = "Logar", HorizontalOptions = LayoutOptions.Center};
            b_registro = new Button() { Text = "Registrar-se" , HorizontalOptions = LayoutOptions.Center };

            grid_botoes = new Grid();
            grid_botoes.Children.Add(b_registro,0,0);
            grid_botoes.Children.Add(b_loguin ,1,0);

            b_loguin.Clicked += B_loguin_Clicked;
            b_registro.Clicked += B_registro_Clicked;

            sl_loguin = new StackLayout() { Children = { l_email, e_email, l_senha, e_senha, grid_botoes } , HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            sl_principal = new StackLayout() { Children = { sl_loguin } };
            this.Content = sl_principal;

        }

        private async void B_registro_Clicked(object sender, EventArgs e)
        {
            
            await App.nav_request.PushAsync(new P_Registro(),true);
        }

        private async void B_loguin_Clicked(object sender, EventArgs e)
        {
            bool resposta = await WSOpen.GetToken(e_email.Text, e_senha.Text);
            if (resposta)
            {
               await App.nav_request.PushAsync(new P_ListaVisitas(),true);
            }else
            {
                await DisplayAlert("", "erro", "ok");
            }
        }
    }
}
