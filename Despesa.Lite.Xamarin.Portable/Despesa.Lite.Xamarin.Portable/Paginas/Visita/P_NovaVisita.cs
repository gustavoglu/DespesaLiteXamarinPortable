using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Despesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita
{
    public class P_NovaVisita : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_chegada_hori;
        StackLayout sl_saida_hori;

        ScrollView scr_principal;

        Button b_chegada;
        Button b_saida;

        Label l_data;
        Label l_horaChegada;
        Label l_horaSaida;
        Label l_tempoImprodutivo;
        Label l_observacoes;
        Label l_cliente;

        DatePicker dp_data;
        TimePicker tp_horaChegada;
        TimePicker tp_horaSaida;
        Picker p_tempoImprodutivo;
        Editor ed_observacoes;
        Picker p_cliente;

        ToolbarItem ti_despesas;

        public P_NovaVisita()
        {
            Title = "Nova Visita";

            l_data = new Label() { Text = "Data" };
            l_horaChegada = new Label() { Text = "Hora Chegada" }; ;
            l_horaSaida = new Label() { Text = "Hora Saída" };
            l_tempoImprodutivo = new Label() { Text = "Tempo Improdutivo" }; ;
            l_observacoes = new Label() { Text = "Observações" };
            l_cliente = new Label() { Text = "Cliente" };

            dp_data = new DatePicker();
            tp_horaChegada = new TimePicker();
            tp_horaSaida = new TimePicker();
            p_tempoImprodutivo = new Picker();
            ed_observacoes = new Editor();
            p_cliente = new Picker();

            b_chegada = new Button() { Text = "Agora" };
            b_saida = new Button() { Text = "Agora" };

            scr_principal = new ScrollView();

            ti_despesas = new ToolbarItem("Despesas", "", Despesas);
            this.ToolbarItems.Add(ti_despesas);

            sl_chegada_hori = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { tp_horaChegada, b_chegada } };
            sl_saida_hori = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { tp_horaSaida, b_saida } };

            sl_principal = new StackLayout() { Padding = 30, Children = { l_cliente, p_cliente, l_data, dp_data, l_horaChegada, sl_chegada_hori, l_horaSaida, sl_saida_hori, l_tempoImprodutivo, p_tempoImprodutivo, l_observacoes, ed_observacoes } };
            scr_principal.Content = sl_principal;

            this.Content = scr_principal;
        }

        private async void Despesas()
        {
            await App.nav_request.PushAsync(new P_DespesaMenu());
        }

    }
}
