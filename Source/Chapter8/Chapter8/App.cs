using Chapter8.Accounts;
using Xamarin.Forms;

namespace Chapter8
{
    public class App
    {
        public static INavigation Navigation { get; private set; }

        public static Page GetMainPage()
        {
            var navigationPage = new NavigationPage(new Overview());
            Navigation = navigationPage.Navigation;
            return navigationPage;

            /*
            return new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, Forms !",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };*/
        }
    }
}
