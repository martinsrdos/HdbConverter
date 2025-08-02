using HdbConverter.ViewModel;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new HdbViewModel();
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            BinEntry.Text = HexEntry.Text = DecEntry.Text = ""; 
        }
    }

}
