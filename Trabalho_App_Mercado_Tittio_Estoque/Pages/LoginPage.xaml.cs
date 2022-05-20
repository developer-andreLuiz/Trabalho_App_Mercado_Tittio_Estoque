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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void FrameSignIn_Tapped(object sender, EventArgs e)
        {
            foreach (var a in GlobalHelper.instance.listEmployee)
            {
                if (a.senha.Equals(entryPassword.Text))
                {
                    GlobalHelper.instance.employee = a;
                }
            }
            if (GlobalHelper.instance.employee == null)
            {
                await DisplayAlert("Erro", "Funcionário não encontrado", "ok");
                entryPassword.Text = String.Empty;
                return;
            }

            if (GlobalHelper.instance.employee.habilitado == 0)
            {
                await DisplayAlert("Erro", "Funcionário Desabilitado", "ok");
                GlobalHelper.instance.employee = null;
                entryPassword.Text = String.Empty;
                return;
            }

            if (GlobalHelper.instance.employee.nivel == 1 && GlobalHelper.instance.listEmployeeOccupation.Find(x => x.id == GlobalHelper.instance.employee.cargo).nome.ToUpper().Trim().Equals("ESTOQUISTA") == false)
            {
                await DisplayAlert("Erro", "Funcionário Não Autorizado", "ok");
                GlobalHelper.instance.employee = null;
                entryPassword.Text = String.Empty;
                return;
            }

            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void entryPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entryPassword.Text.Length > 3)
            {
                FrameSignIn.IsVisible = true;
            }
            else
            {
                FrameSignIn.IsVisible = false;
            }
        }
    }
}