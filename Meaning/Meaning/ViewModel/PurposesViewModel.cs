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
    public class PurposesViewModel : INotifyPropertyChanged
    {
        public Color PageColor { get; set; }
        public Color ContrastColor { get; set; }
        public Thickness PagePadding { get; set; }
        public int GeneralVisualItemsSpacing { get; set; }

        public string PurposesImageSource { get; set; }

        public string MotivationItemText { get; set; }

        private ObservableCollection<PurposeForInterface> purposesCollection;

        public ObservableCollection<PurposeForInterface> PurposesCollection
        {
            get { return purposesCollection; }
            set
            {
                purposesCollection = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
