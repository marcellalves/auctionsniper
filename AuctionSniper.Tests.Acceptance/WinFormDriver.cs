using System.Threading;
using System.Windows.Forms;
using AuctionSniper.UI;

namespace AuctionSniper.Tests.Acceptance
{
    public class WinFormDriver
    {
        protected Thread _thread;
        private readonly int _sleepMilliseconds;

        public WinFormDriver(Main main, int sleepMilliseconds)
        {
            Main = main;
            _sleepMilliseconds = sleepMilliseconds;
        }

        public Main Main { get; }

        public void LaunchApplicationInItsOwnThread()
        {
            _thread = new Thread(new ParameterizedThreadStart(Launch));
            _thread.Start(Main);
            Main.Show();
            Main.BringToFront();
            Main.Refresh();
        }

        public void QuitApplication()
        {
            Thread.Sleep(_sleepMilliseconds);
            Main.Close();
            Application.Exit();
        }

        private static void Launch(object input)
        {
            var form = (Form) input;
            Application.Run(form);
        }
    }
}