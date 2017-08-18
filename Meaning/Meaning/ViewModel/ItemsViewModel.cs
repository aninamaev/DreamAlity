using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Meaning.Annotations;
using Meaning.Model;
using Xamarin.Forms;

namespace Meaning.ViewModel
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        public Color PageColor { get; set; }
        public Color ContrastColor { get; set; }
        public Thickness PagePadding { get; set; }

        public string ItemImageSource { get; set; }

        private ObservableCollection<ItemforInterface> itemsCollection;
        public ObservableCollection<ItemforInterface> ItemsCollection
        {
            get { return itemsCollection; }
            set
            {
                itemsCollection = value;
                OnPropertyChanged();
            }
        }

        public string ItemMotivation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
