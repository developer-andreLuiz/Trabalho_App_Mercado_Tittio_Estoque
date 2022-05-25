using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Helpers;
using Trabalho_App_Mercado_Tittio_Estoque.Services;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio_Estoque.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreItemExitPage : ContentPage
    {
        StoreShelfServiceModel shelf = null;
        ProductServiceModel product = null;
        public StoreItemExitPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void entryShelf_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                shelf = null;
                if (entryShelf.Text.Length > 0)
                {
                    if (entryShelf.Text.Length != 13)
                    {
                        await DisplayAlert("Atenção", "Código de Prateleira Errado", "ok");
                        entryShelf.Text = String.Empty;
                        return;
                    }
                    int stand = int.Parse(entryShelf.Text.Substring(10, 3));
                    int code = int.Parse(entryShelf.Text.Substring(3, 7));
                    foreach (var item in GlobalHelper.instance.listStoreShelf)
                    {
                        if (item.lojaEstante == stand && item.codigo == code)
                        {
                            shelf = item;
                            break;
                        }
                    }
                    if (shelf == null)
                    {
                        await DisplayAlert("Atenção", "Prateleira Não Encontada", "ok");
                        entryShelf.Text = String.Empty;
                        return;
                    }
                }
            }
            catch { }
        }

        private async void entryProduct_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (entryProduct.Text.Length > 0)
                {
                    product = null;
                    if (entryProduct.Text.Trim().Length > 0)
                    {
                        ProductBarcodeServiceModel productBarcodeServiceModel = null;
                        foreach (var item in GlobalHelper.instance.listProductBarcode)
                        {
                            if (item.codigoBarra.Equals(entryProduct.Text.Trim()))
                            {
                                productBarcodeServiceModel = item;
                                break;
                            }
                        }
                        if (productBarcodeServiceModel == null)
                        {
                            await DisplayAlert("Atenção", "Código de Barra Não Encontado", "ok");
                            entryProduct.Text = String.Empty;
                            return;
                        }

                        foreach (var item in GlobalHelper.instance.listProduct)
                        {
                            if (item.id == productBarcodeServiceModel.produto)
                            {
                                product = item;
                                break;
                            }
                        }
                        if (product == null)
                        {
                            await DisplayAlert("Atenção", "Produto Não Encontado", "ok");
                            entryProduct.Text = String.Empty;
                            return;
                        }
                        labelProduct.Text = product.descricao.Length > 50 ? $"Produto:{product.descricao.Substring(0, 50)}" : $"Produto:{product.descricao}";
                    }
                }
            }
            catch { }
        }

        private async void frameButtonRemove_Tapped(object sender, EventArgs e)
        {
            if (shelf == null)
            {
                await DisplayAlert("Informação", "Pratileira não informada", "ok");
                return;
            }
            if (product == null)
            {
                await DisplayAlert("Informação", "Produto não informado", "ok");
                return;
            }

            ProductStoreServiceModel productStoreServiceModel = null;
            foreach (var item in GlobalHelper.instance.listProductStore)
            {
                if (item.prateleira==shelf.id && item.produto==product.id )
                {
                    productStoreServiceModel = item;
                    break;
                   

                }
            }
            if (productStoreServiceModel!=null)
            {
                await ProductStoreService.instance.Delete(productStoreServiceModel.id);
                await DisplayAlert("Informação", "Produto Estornado", "ok");
                GlobalHelper.instance.listProductStore.Remove(productStoreServiceModel);
                shelf = null;
                product = null;

                entryShelf.Text = String.Empty;
                entryProduct.Text = String.Empty;
                labelProduct.Text = "Produto:";

            }
            else
            {
                await DisplayAlert("Erro", "Produto não Encontrado", "ok");
                product = null;
                entryProduct.Text = String.Empty;
                labelProduct.Text = "Produto:";
            }
           

        }
        private async void frameButtonClear_Tapped(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Limpar Tela ?", "Sim", "Não");
            if (action.Equals("Sim"))
            {
                shelf = null;
                product = null;
              
                entryShelf.Text = String.Empty;
                entryProduct.Text = String.Empty;
                labelProduct.Text = "Produto:";
              
            }
        }
    }
}