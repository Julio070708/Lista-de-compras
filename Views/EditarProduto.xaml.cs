using Lista_de_compras.Models;

namespace Lista_de_compras.Views;

public partial class EditarProduto : ContentPage
{
    Produto produtoAtual;

    public EditarProduto()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        produtoAtual = BindingContext as Produto;

        if (produtoAtual != null)
        {
            txt_descricao.Text = produtoAtual.Descricao;
            txt_quantidade.Text = produtoAtual.Quantidade.ToString();
            txt_preco.Text = produtoAtual.Preco.ToString();
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (produtoAtual == null)
                return;

            double quantidade = 0;
            double preco = 0;

            double.TryParse(txt_quantidade.Text, out quantidade);
            double.TryParse(txt_preco.Text, out preco);

            Produto p = new Produto
            {
                Id = produtoAtual.Id,
                Descricao = txt_descricao.Text ?? "",
                Quantidade = quantidade,
                Preco = preco
            };

            await App.Db.Update(p);

            await DisplayAlert("Sucesso!", "Produto atualizado!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}