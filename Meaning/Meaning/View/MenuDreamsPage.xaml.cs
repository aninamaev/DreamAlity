using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Logic;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class MenuDreamsPage : ContentPage
    {
        public MenuDreamsPage()
        {
            var menuDreamsViewModel = new MenuDreamsViewModel
            {
                ContrastColor = GeneralSettings.CustomColor,
                PageColor = GeneralSettings.ContrastColor,
                PagePadding = GeneralSettings.CustomPagePadding
            };

            BindingContext = menuDreamsViewModel;

            InitializeComponent();
        }

        public void OnMotivationClicked(object sender, EventArgs e)
        {
            var motivationPage = new MotivationPage();
            Navigation.PushAsync(motivationPage);
        }

        public void OnQuestionsClicked(object sender, EventArgs e)
        {
            var questionsItems = ItemsFromDb.ReturnItemsForInterface(ItemType.Question);
            var questionMotivation = ItemsFromDb.ReturnItemMotivation(ItemType.Question);
            var questionsImageSource = "q1.jpg";

            var questionsPage = new ItemsPage(questionsItems, questionMotivation, questionsImageSource, ItemType.Question) { Title = "Questions" };
            Navigation.PushAsync(questionsPage);
        }

        public void OnQuotesClicked(object sender, EventArgs e)
        {
            var quotesItems = ItemsFromDb.ReturnItemsForInterface(ItemType.Quote);
            var quotesMotivation = ItemsFromDb.ReturnItemMotivation(ItemType.Quote);
            var quotesImageSource = "q2.jpg";

            var quotesPage = new ItemsPage(quotesItems, quotesMotivation, quotesImageSource, ItemType.Quote) { Title = "Quotes" };
            Navigation.PushAsync(quotesPage);
        }

        public void OnSuggestionsClicked(object sender, EventArgs e)
        {
            var suggestionItems = ItemsFromDb.ReturnItemsForInterface(ItemType.Suggestion);
            var suggestionMotivation = ItemsFromDb.ReturnItemMotivation(ItemType.Suggestion);
            var suggestioImageSource = "q3.jpg";

            var suggestionPage = new ItemsPage(suggestionItems, suggestionMotivation, suggestioImageSource, ItemType.Suggestion) {Title = "Suggestion"};
            Navigation.PushAsync(suggestionPage);
        }

        public void OnForgetAboutClicked(object sender, EventArgs e)
        {
            var forgetsItems = ItemsFromDb.ReturnItemsForInterface(ItemType.Forget);
            var forgetsMotivation = ItemsFromDb.ReturnItemMotivation(ItemType.Forget);
            var forgestImageSource = "q4.jpg";

            var forgetsPage = new ItemsPage(forgetsItems, forgetsMotivation, forgestImageSource, ItemType.Forget) {Title = "Forget About"};
            Navigation.PushAsync(forgetsPage);
        }
    }
}
