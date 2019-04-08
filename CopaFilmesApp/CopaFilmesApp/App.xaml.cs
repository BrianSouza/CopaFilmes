using CopaFilmesApp.Services;
using CopaFilmesApp.Services.Interface;
using CopaFilmesApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CopaFilmesApp
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<IFilmesProvider, FilmesProvider>();
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<Services.Interface.INavigation, Services.Interface.Navigation>();
            InitializeComponent();
            MainPage = new NavigationPage(new ListaFilmesView()) { BarBackgroundColor = Color.DimGray , BarTextColor = Color.White};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
