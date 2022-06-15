using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Enumerators;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio_Estoque.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErroPage : ContentPage
    {
        StatusError statusError;
        public ErroPage(StatusError erro)
        {
            InitializeComponent();
            statusError = erro;



            if (statusError == StatusError.Internet)
            {
                lblStatus.Text = $"Você esta sem Internet";
                btnTryAgain.Text = "Tentar Novamente";
                return;
            }
        }
        private void btnTryAgain_Clicked(object sender, EventArgs e)
        {
            if (statusError == StatusError.Internet)
            {
                App.Current.MainPage = new LoadPage();
                return;
            }
        }
    }
}