using System.Windows.Forms;

namespace AuctionSniper.UI
{
    public class Main : Form, IPickerMainView
    {
        private readonly Label _lblStatus;

        public Main()
        {
            _lblStatus = new Label();
            Controls.Add(_lblStatus);
        }

        public string SniperStatus
        {
            get => _lblStatus.Text;
            set => _lblStatus.Text = value;
        }

        public string WindowTitle
        {
            get => Text; 
            set => Text = value;
        }
        
    }
}
