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
    public class MesaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TMesa> _Mesas;
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
        public MesaViewModel()
        {
            _Mesas = new ObservableCollection<TMesa>();
            LoadDataCommand = new Command(async () => await LoadData());
            Task.Run(LoadData);
        }
        public ObservableCollection<TMesa> Mesas
        {
            get => _Mesas;
            set => _Mesas = value;
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

                var mesasCollection = await TMesaManager.GetAll();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Mesas.Clear();

                    foreach (TMesa mesa in mesasCollection)
                    {
                        Mesas.Add(mesa);
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
