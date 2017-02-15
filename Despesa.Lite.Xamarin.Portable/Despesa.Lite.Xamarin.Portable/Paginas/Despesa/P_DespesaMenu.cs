using Despesa.Lite.Xamarin.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Despesa
{
    public class P_DespesaMenu : ContentPage
    {
        ScrollView scr_principal;
        StackLayout sl_principal;
        StackLayout sl_vert_um;
        StackLayout sl_vert_dois;
        StackLayout sl_vert_tres;
        StackLayout sl_vert_quatro;
        StackLayout sl_hori_um;
        StackLayout sl_hori_dois;

        ToolbarItem ti_adicionarImagem;

        Label l_quilometragem;
        Label l_pedagio;
        Label l_refeicao;
        Label l_outros;
        Label l_detalhes;

        Entry e_quilometragem;
        Entry e_pedagio;
        Entry e_refeicao;
        Entry e_outros;
        Editor ed_detalhes;

        ListView listV_despesa_imagens;
        ObservableCollection<Despesa_Imagem> list_Despesa_Imagens;

        public P_DespesaMenu()
        {
            Title = "Despesas";

            l_quilometragem = new Label() { Text = "Quilometragem" };
            l_pedagio = new Label() { Text = "Pedágio" };
            l_refeicao = new Label() { Text = "Refeição" };
            l_outros = new Label() { Text = "Outros" };
            l_detalhes = new Label() { Text = "Detalhes" };

            e_quilometragem = new Entry() { Keyboard = Keyboard.Numeric };
            e_pedagio = new Entry() { Keyboard = Keyboard.Numeric };
            e_refeicao = new Entry() { Keyboard = Keyboard.Numeric };
            e_outros = new Entry() { Keyboard = Keyboard.Numeric };
            ed_detalhes = new Editor();
            scr_principal = new ScrollView();

            list_Despesa_Imagens = new ObservableCollection<Despesa_Imagem>();
            listV_despesa_imagens = new ListView() { ItemsSource = list_Despesa_Imagens, HasUnevenRows = true };

            ti_adicionarImagem = new ToolbarItem("Adicionar Imagem", "", AdicionarImagem);
            this.ToolbarItems.Add(ti_adicionarImagem);

            sl_vert_um = new StackLayout() { Children = { l_quilometragem, e_quilometragem } };
            sl_vert_dois = new StackLayout() { Children = { l_pedagio, e_pedagio } };
            sl_vert_tres = new StackLayout() { Children = { l_refeicao, e_refeicao } };
            sl_vert_quatro = new StackLayout() { Children = { l_outros, e_outros } };

            sl_hori_um = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { sl_vert_um, sl_vert_dois } };
            sl_hori_dois = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { sl_vert_tres, sl_vert_quatro } };

            sl_principal = new StackLayout() { Children = { sl_hori_um,sl_hori_dois, l_detalhes,ed_detalhes,listV_despesa_imagens} };

            scr_principal.Content = sl_principal;

            this.Content = scr_principal;
        }


        protected void AdicionarImagem()
        {

        }
    }
}
