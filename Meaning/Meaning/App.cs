using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meaning.View;
using Xamarin.Forms;

namespace Meaning
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StartMeaningAppPage() {Title = "DreamAlity"}) { BarTextColor = GeneralSettings.CustomColor, BarBackgroundColor = Color.White };
        }
    }

    public class GeneralSettings
    {
        public static Color CustomColor { get; set; } = Color.FromRgb(163, 114, 168);
        public static Color TextColor { get; set; } = Color.Black;
        public static Color ContrastColor { get; set; } = Color.White;
        public static Thickness CustomPagePadding { get; set; } = new Thickness(7, 7, 7, 7);
        public static int CustomVisualItemsSpacing { get; set; } = 7;
    }

    public class StartMeaningAppPage : MasterDetailPage
    {
        public StartMeaningAppPage()
        {
            Master = new MenuDreamsPage() { Title = "Menu" };
            Detail = new DesignDreamsPage { Title = "DreamAlity" }; 
        }
    }
}