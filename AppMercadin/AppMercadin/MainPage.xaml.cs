using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMercadin.Model;

namespace AppMercadin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Listagem());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Tarefa t = new Tarefa();
            t.Produto = txt_produto.Text;
            t.Preco = txt_preco.Text;
            t.Data_Criacao = dtpck_data_criacao.Date;

            await App.Database.Save(t);

            await DisplayAlert("Booa", "Tudo Salvo no SQLite", "OK");

            await Navigation.PushAsync(new Listagem());
        }
    }
}
