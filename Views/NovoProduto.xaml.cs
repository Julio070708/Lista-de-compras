using Lista_de_compras.Models;

namespace Lista_de_compras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),

                // 👇 ADICIONA ISSO
                Categoria = txt_categoria.Text
            };

            await App.Db.Insert(p);

            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}