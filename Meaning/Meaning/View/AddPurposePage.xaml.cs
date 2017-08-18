using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Model;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class AddPurposePage : ContentPage
    {
        private PurposeForInterface purpose;

        public Action RefreshPurposeAction;

        public AddPurposePage(PurposeForInterface purpose, string imageSource, string motivationText)
        {
            this.purpose = purpose;

            var addDreamViewModel = new AddDreamViewModel()
            {
                AddDreamLabel = purpose == null ? "Adding a new purpose:" : "Editing purpose:",
                Content = purpose == null ? "" : purpose.Content,
                NotesLabelText = "How do I feel this purpose?",
                Notes = purpose == null ? "" : purpose.Notes,
                DueDateLabel = "This will be accomplished on",
                CurrentDisplayedDate = purpose?.DueDateTime ?? DateTime.Now.AddDays(1),
                ProgressTextLabel = "Work in progress:",
                ProgressValue = purpose?.ProgressValue ?? 0,
                AddDreamImageSource = imageSource,
                AddDreamMotivationText = motivationText
            };
            BindingContext = addDreamViewModel;

            InitializeComponent();
        }

        public void SavePurposeClicked(object sender, EventArgs e)
        {
            var thisPurpose = new Purpose()
            {
                Content = ContentText.Text,
                Notes = NotesText.Text,
                DueDate = DatePicker.Date,
                ProgressLevel = Slider.Value
            };

            var mp = new ManagePurposes();
            if (purpose == null)
                mp.AddPurpose(thisPurpose);
            else
            {
                thisPurpose.Id = purpose.Id;
                mp.UpdatePurpose(thisPurpose);
            }

            RefreshPurposeAction?.Invoke();
            Navigation.PopAsync();
        }
    }
}