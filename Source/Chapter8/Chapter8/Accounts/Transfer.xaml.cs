namespace Chapter8.Accounts
{
    public partial class Transfer
    {
        public Transfer()
        {
            InitializeComponent();
        }

        public TransferViewModel    ViewModel
        {
            get
            {
                return BindingContext as TransferViewModel;
            }
        }
    }
}
