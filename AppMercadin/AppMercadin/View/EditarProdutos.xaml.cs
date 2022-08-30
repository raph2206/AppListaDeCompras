using AppMercadin.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMercadin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProduto : ContentPage
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {

                Produtos produto_anexado = BindingContext as Produtos;

                Produtos p = new Produtos
                {
                    Id = produto_anexado.Id,
                    Descricao = txt_desc.Text,
                    Quantidade = Convert.ToDouble(txt_qnt.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };

                await Main.Database.Update(p);

                await DisplayAlert("Sucesso!", "Produto Editado", "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}