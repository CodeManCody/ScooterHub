using ScooterHub.DataModels.Bird;
using ScooterHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScooterHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapUI : ContentPage
    {
        public MapVM vm;
        public MapUI()
        {
            InitializeComponent();

            vm = new MapVM();
            this.BindingContext = vm;
        }
    }
}