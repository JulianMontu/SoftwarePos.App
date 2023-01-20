using SoftwarePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoftwarePos.ViewModels
{
    public class ProductoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TProducto> _productos;
        public event PropertyChangedEventHandler PropertyChanged;
        
        private bool _isRefreshing = false;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value)
                    return;

                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }
        public ProductoViewModel()
        {
            _productos = new ObservableCollection<TProducto>();
            LoadDataCommand = new Command(async () => await LoadData());
            Task.Run(LoadData);
        }
        public ObservableCollection<TProducto> Productos
        {
            get => _productos;
            set => _productos = value;
        }
        public ICommand LoadDataCommand { get; private set; }

        //public ICommand PartSelectedCommand { get; private set; }

        //public ICommand AddNewPartCommand { get; private set; }
        public async Task LoadData()
        {
            if (IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;

                var productosCollection = await TProductManager.GetAll();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Productos.Clear();

                    foreach (TProducto producto in productosCollection)
                    {
                        Productos.Add(producto);
                    }
                });
            }
            catch (Exception e) 
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }
    }
}
