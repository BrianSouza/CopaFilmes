using CopaFilmesApp.Model;
using CopaFilmesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CopaFilmesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultadoView : ContentPage
    {
        ResultadoViewModel vmResultado;
        public ResultadoView(ObservableCollection<FilmesFinalistas> listaFinalistas)
        {
            InitializeComponent();
            vmResultado = new ResultadoViewModel(listaFinalistas);
            this.BindingContext = vmResultado;
        }
    }
}