using jodeware2.Data;
using jodeware2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.ViewModels
{
    public class ProduktViewModel : INotifyPropertyChanged
    {
        public RootObject _produktList;

        public event PropertyChangedEventHandler PropertyChanged;

        public RootObject ProduktList
        {
            get { return _produktList; }
            set { _produktList = value;
                OnPropertyChanged();
            }
        }

        public ProduktViewModel()
        {
            GetData();
        }

        public async Task<RootObject> GetData()
        {
            var service = new RestService();
            _produktList = await service.RefreshDataAsync();
            return _produktList;
            
        }

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
