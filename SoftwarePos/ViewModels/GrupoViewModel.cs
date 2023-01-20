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
    public class GrupoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TGrupo> _grupos;
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
        public GrupoViewModel()
        {
            _grupos = new ObservableCollection<TGrupo>();
            LoadDataCommand = new Command(async () => await LoadData());
            Task.Run(LoadData);
        }
        public ObservableCollection<TGrupo> Grupos
        {
            get => _grupos;
            set => _grupos = value;
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

                var gruposCollection = await TGrupoManager.GetAll();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Grupos.Clear();

                    foreach (TGrupo grupo in gruposCollection)
                    {
                        Grupos.Add(grupo);
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
