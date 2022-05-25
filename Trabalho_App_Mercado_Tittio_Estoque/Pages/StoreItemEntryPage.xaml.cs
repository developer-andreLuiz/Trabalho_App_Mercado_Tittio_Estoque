using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Services;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trabalho_App_Mercado_Tittio_Estoque.Helpers;

namespace Trabalho_App_Mercado_Tittio_Estoque.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreItemEntryPage : ContentPage
    {
        StoreShelfServiceModel shelf = null;
        ProductServiceModel product = null;
        int day = 0;
        int month = 0;
        int year = 0;
        int amount = 0;
        public StoreItemEntryPage()
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
                    if (product != null)
                    {
                        foreach (var item in GlobalHelper.instance.listProductStore)
                        {
                            if (item.prateleira == shelf.id && item.produto == product.id)
                            {
                                await DisplayAlert("Atenção", "Ja possui o produto na prateleira", "ok");
                                entryProduct.Text = String.Empty;
                                labelProduct.Text = "Produto:";
                                product = null;
                                return;
                            }
                        }
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

                        if (shelf != null)
                        {
                            foreach (var item in GlobalHelper.instance.listProductStore)
                            {
                                if (item.prateleira == shelf.id && item.produto == product.id)
                                {
                                    await DisplayAlert("Atenção", "Ja possui o produto na prateleira", "ok");
                                    entryProduct.Text = String.Empty;
                                    labelProduct.Text = "Produto:";
                                    product = null;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private async void entryDay_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (entryDay.Text.Length > 0)
                {
                    day = 0;
                    if (entryDay.Text.Trim().Length > 0)
                    {
                        day = int.Parse(entryDay.Text.Trim());
                        if (day < 1 || day > 31)
                        {
                            await DisplayAlert("Atenção", "Dia Errado", "ok");
                            entryDay.Text = String.Empty;
                            day = 0;
                            return;
                        }
                    }
                }
            }
            catch { }
            
           
        }
        private async void entryMonth_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (entryMonth.Text.Length > 0)
                {
                    month = 0;
                    if (entryMonth.Text.Trim().Length > 0)
                    {
                        month = int.Parse(entryMonth.Text.Trim());
                        if (month < 1 || month > 12)
                        {
                            await DisplayAlert("Atenção", "Mês Errado", "ok");
                            entryMonth.Text = String.Empty;
                            month = 0;
                            return;
                        }
                    }
                }
            }
            catch { }
           
            
        }
        private async void entryYear_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (entryYear.Text.Length > 0)
                {
                    year = 0;
                    if (entryYear.Text.Trim().Length > 0)
                    {
                        year = int.Parse(entryYear.Text.Trim());
                        if (year < 22)
                        {
                            await DisplayAlert("Atenção", "Ano Errado", "ok");
                            entryYear.Text = String.Empty;
                            year = 0;
                            return;
                        }
                        year += 2000;
                    }
                }
            }
            catch { }
          
           
        }
        private void entryAmount_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (entryAmount.Text.Length > 0)
                {
                    amount = 0;
                    if (entryAmount.Text.Trim().Length > 0)
                    {
                        amount = int.Parse(entryAmount.Text.Trim());
                    }
                }
            }
            catch { }
           
           
        }
      


        private async void frameButtonInsert_Tapped(object sender, EventArgs e)
        {
            if (shelf==null)
            {
                await DisplayAlert("Informação", "Pratileira não informada", "ok");
                return;
            }
            if (product == null)
            {
                await DisplayAlert("Informação", "Produto não informado", "ok");
                return;
            }
            if (day ==0)
            {
                await DisplayAlert("Informação", "Dia Invalido", "ok");
                return;
            }
            if (month == 0)
            {
                await DisplayAlert("Informação", "Mês Invalido", "ok");
                return;
            }
            if (year == 0)
            {
                await DisplayAlert("Informação", "Ano Invalido", "ok");
                return;
            }
            if (amount == 0)
            {
                await DisplayAlert("Informação", "Quantidade Invalida", "ok");
                return;
            }

            ProductStoreServiceModel productStoreServiceModel = new ProductStoreServiceModel();

            productStoreServiceModel.produto = product.id;
            productStoreServiceModel.custoUnitario = product.custoUnitario;
            productStoreServiceModel.entrada = DateTime.Now;

            productStoreServiceModel.validade = new DateTime(year, month, day);
            productStoreServiceModel.prateleira =shelf.id;
            productStoreServiceModel.quantidade = amount;
            productStoreServiceModel.funcionario = GlobalHelper.instance.employee.id;
            productStoreServiceModel.conferenciaValidade = 0;
            productStoreServiceModel.conferenciaValidade = 0;
            productStoreServiceModel = await ProductStoreService.instance.Create(productStoreServiceModel);
            if (productStoreServiceModel.id > 0)
            {
                GlobalHelper.instance.listProductStore.Add(productStoreServiceModel);
                await DisplayAlert("Informação", "Inserido", "ok");
                shelf = null;
                product = null;
                day = 0;
                month = 0;
                year = 0;
                amount = 0;
                entryShelf.Text = String.Empty;
                entryProduct.Text = String.Empty;
                labelProduct.Text = "Produto:";
                entryDay.Text = String.Empty;
                entryMonth.Text = String.Empty;
                entryYear.Text = String.Empty;
                entryAmount.Text = String.Empty;
            }
            else
            {
                await DisplayAlert("Erro", "Não Inserido", "ok");
            }
        }
        private async void frameButtonClear_Tapped(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Limpar Tela ?", "Sim", "Não");
            if (action.Equals("Sim"))
            {
                shelf = null;
                product = null;
                day = 0;
                month = 0;
                year = 0;
                amount = 0;
                entryShelf.Text = String.Empty;
                entryProduct.Text = String.Empty;
                labelProduct.Text = "Produto:";
                entryDay.Text = String.Empty;
                entryMonth.Text = String.Empty;
                entryYear.Text = String.Empty;
                entryAmount.Text = String.Empty;
            }
           
        }

       
    }
}