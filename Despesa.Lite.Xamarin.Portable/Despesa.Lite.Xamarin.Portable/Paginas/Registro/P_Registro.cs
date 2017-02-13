using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
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
        StackLayout sl_companhia;
        ToolbarItem ti_confirmar;
        Switch sw_Campanhia;
        Label l_companhia;
        Label l_nome;
        Label l_email;
        Label l_senha;
        Label l_confirmasenha;
        Entry e_nome;
        Entry e_email;
        Entry e_senha;
        Entry e_confirmasenha;

        public P_Registro()
        {
            Title = "Registro";

            l_nome = new Label() { Text = "Nome Completo" };
            l_email = new Label() { Text = "E-mail" };
            l_senha = new Label() { Text = "Senha" };
            l_confirmasenha = new Label() { Text = "Confirmação da Senha" };
            l_companhia = new Label() { Text = "Companhia?" };
            e_nome = new Entry() {  };
            e_email = new Entry() { };
            e_senha = new Entry() { IsPassword = true };
            e_confirmasenha = new Entry() { IsPassword = true };
            sw_Campanhia = new Switch() {  };

            ti_confirmar = new ToolbarItem("Confirmar","", Confirmar);

            sl_companhia = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { l_companhia,sw_Campanhia } };

            this.ToolbarItems.Add(ti_confirmar);
            sl_principal = new StackLayout() {Padding = 30 , Children = { l_nome, e_nome, l_email, e_email, l_senha, e_senha, l_confirmasenha, e_confirmasenha , sl_companhia } };

            this.Content = sl_principal;

        }

      

        public async void Confirmar()
        {
           bool resposta = await WSOpen.Registrar(e_nome.Text, e_email.Text, e_senha.Text, e_confirmasenha.Text, sw_Campanhia.IsToggled);
        }

     
    }
}
