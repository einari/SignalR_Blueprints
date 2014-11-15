using Bifrost.Messaging;
using PropertyChanged;

namespace Chapter7
{
    [ImplementPropertyChanged]
    public class MainPageViewModel
    {
        public MainPageViewModel(IMessenger messenger)
        {
            messenger.SubscribeTo<TransferMessage>(t =>
            {
                SelectedPageIndex = 1;
            });

            messenger.SubscribeTo<NavigateHomeMessage>(t => SelectedPageIndex = 0);
        }


        public int SelectedPageIndex { get; set; }
    }
}
