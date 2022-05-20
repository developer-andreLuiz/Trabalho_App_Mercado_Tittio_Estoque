using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trabalho_App_Mercado_Tittio_Estoque.Helpers;

namespace Trabalho_App_Mercado_Tittio_Estoque.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lblName.Text = GlobalHelper.instance.employee.nome;
            lblOccupation.Text = GlobalHelper.instance.listEmployeeOccupation.Find(x => x.id == GlobalHelper.instance.employee.cargo).nome;  
        }

        private async void FrameStoreItemEntry_Tapped(object sender, EventArgs e)
        {
            PushAsyncWithoutDuplicate(new StoreItemEntryPage());

        }
        private async void FrameWithdrawalItemsStore_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Informação", "Retirada de Itens", "ok");
        }
    }
}