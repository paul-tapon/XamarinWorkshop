using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDemo.Models;
using XamarinDemo.Services;

namespace XamarinDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Command LoadProductsCommand { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public IDataStore<Product> DataStore { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Products = new ObservableCollection<Product>();

            DataStore = new ProductDataStore();

            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            ExecuteLoadProductsCommand();
        }

        async Task ExecuteLoadProductsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Products.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Products.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
