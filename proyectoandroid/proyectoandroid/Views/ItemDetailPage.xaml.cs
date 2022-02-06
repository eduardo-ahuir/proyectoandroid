using proyectoandroid.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace proyectoandroid.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}