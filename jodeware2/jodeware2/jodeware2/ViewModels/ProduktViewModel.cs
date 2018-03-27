using jodeware2.Data;
using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.ViewModels
{
    public class ProduktViewModel : INotifyPropertyChanged
    {
        public List<Produkt> _produktList;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Produkt> ProduktList
        {
            get { return _produktList; }
            set { _produktList = value;
                OnPropertyChanged();
            }
        }

        public ProduktViewModel()
        {
            //GetData();
        }

        public async Task<List<Produkt>> GetData()
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
