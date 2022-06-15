using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Enumerators;
using Trabalho_App_Mercado_Tittio_Estoque.Helpers;
using Trabalho_App_Mercado_Tittio_Estoque.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio_Estoque.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        float percentageBar = 0;
        float percentageIncrease = 10;
        uint animationTime = 1000;

        bool internetIsOn = false;
        bool internetVerified = false;

        bool employeeVerified = false;
        bool employeeOccupationVerified = false;
        bool productVerified = false;
        bool productStoreVerified = false;
        bool productBarcodeVerified = false;
        bool storeShelfVerified = false;

        bool nextPage = false;
       


        public LoadPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (internetVerified == false)
                {
                    InternetCheck();
                    return true;
                }
                if (employeeVerified == false)
                {
                    EmployeeAsync();
                    return true;
                }
                if (employeeOccupationVerified == false)
                {
                    EmployeeOccupationAsync();
                    return true;
                }
                if (productVerified == false)
                {
                    ProductAsync();
                    return true;
                }
                if (productStoreVerified == false)
                {
                    ProductStoreAsync();
                    return true;
                }
                if (productBarcodeVerified == false)
                {
                    ProductBarcodeAsync();
                    return true;
                }
                if (storeShelfVerified == false)
                {
                    StoreShelfAsync();
                    return true;
                }
                if (nextPage==false)
                {
                    NextPage();
                    return true;
                }
                return true;
            }
          );
        }

        void AnimationBar(string msg, bool finished)
        {
            if (finished)
            {
                percentageBar = 100;
                lblPercentage.Text = percentageBar + "%";
                lblStatus.Text = $"Pronto para Iniciar";
                Bar.ProgressTo(percentageBar / 100, animationTime, Easing.Linear);
            }
            else
            {
                percentageBar += percentageIncrease;
                lblPercentage.Text = percentageBar + "%";
                lblStatus.Text = $"{msg}";
                Bar.ProgressTo(percentageBar / 100, animationTime, Easing.Linear);
            }
        }
        void InternetCheck()
        {
            internetVerified = true;
            internetIsOn = DeviceHelper.InternetCheck();
            AnimationBar("Internet Verificada", false);
            if (internetIsOn == false)
            {
                App.Current.MainPage = new ErroPage(StatusError.Internet);
            }
        }
        async Task EmployeeAsync()
        {
            if (internetIsOn)
            {
                employeeVerified = true;
                EmployeeService service = new EmployeeService();
                GlobalHelper.instance.listEmployee = await service.GetAll();
                AnimationBar("Funcionários", false);
            }
        }
        async Task EmployeeOccupationAsync()
        {
            if (internetIsOn)
            {
                employeeOccupationVerified = true;
                EmployeeOccupationService service = new EmployeeOccupationService();
                GlobalHelper.instance.listEmployeeOccupation = await service.GetAll();
                AnimationBar("Funcionário Cargos", false);
            }
        }
        async Task ProductAsync()
        {
            if (internetIsOn)
            {
                productVerified = true;
                ProductService service = new ProductService();
                GlobalHelper.instance.listProduct = await service.GetAll();
                AnimationBar("Produto", false);
            }
        }
        async Task ProductStoreAsync()
        {
            if (internetIsOn)
            {
                productStoreVerified = true;
                ProductStoreService service = new ProductStoreService();
                GlobalHelper.instance.listProductStore = await service.GetAll();
                AnimationBar("Produto Loja", false);
            }
        }
        async Task ProductBarcodeAsync()
        {
            if (internetIsOn)
            {
                productBarcodeVerified = true;
                ProductBarcodeService service = new ProductBarcodeService();
                GlobalHelper.instance.listProductBarcode = await service.GetAll();
                AnimationBar("Código de Barra", false);
            }
        }
        async Task StoreShelfAsync()
        {
            if (internetIsOn)
            {
                storeShelfVerified = true;
                StoreShelfService service = new StoreShelfService();
                GlobalHelper.instance.listStoreShelf = await service.GetAll();
                AnimationBar("Loja Prateleira", false);
            }
        }

        void NextPage()
        {
            if (internetIsOn)
            {
                if (employeeVerified && employeeOccupationVerified && productVerified && productBarcodeVerified && storeShelfVerified)
                {
                    nextPage = true;
                    AnimationBar("Pronto", true);
                    App.Current.MainPage = new LoginPage();
                    return;
                }
            }
        }

    }
}