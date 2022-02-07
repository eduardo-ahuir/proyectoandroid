using proyectoandroid.Models;
using proyectoandroid.ViewModels;
using proyectoandroid.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoandroid.Views
{
    public partial class Añadir : ContentPage
    {
        ItemsViewModel _viewModel;

        public Añadir()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}