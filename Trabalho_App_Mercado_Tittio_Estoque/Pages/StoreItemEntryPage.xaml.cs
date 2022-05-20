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
        public StoreItemEntryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnInsert_Clicked(object sender, EventArgs e)
        {
            ProductStoreServiceModel productStoreServiceModel = new ProductStoreServiceModel();

            productStoreServiceModel.produto = int.Parse(entryProduct.Text);

            productStoreServiceModel.entrada = DateTime.Now;

            productStoreServiceModel.validade = datePickerValidity.Date;

            productStoreServiceModel.prateleira = int.Parse(entryShelf.Text);


            productStoreServiceModel.quantidade = int.Parse(entryAmount.Text);

            productStoreServiceModel.funcionario = GlobalHelper.instance.employee.id;
            productStoreServiceModel.conferenciaValidade = 0;
            productStoreServiceModel.conferenciaValidade = 0;



            productStoreServiceModel = await ProductStoreService.instance.Create(productStoreServiceModel);

            if (productStoreServiceModel.id>0)
            {
                await DisplayAlert("Informação", "Inserido", "ok");
            }
            else
            {
                await DisplayAlert("Erro", "Não Inserido", "ok");
            }
           
        }
    }
}