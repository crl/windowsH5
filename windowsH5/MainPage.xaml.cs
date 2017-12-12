using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace h5
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                MiracleGames.Game.H5Control h5 = new MiracleGames.Game.H5Control();
                MiracleGames.AuthenticationNavigationCommand command = new MiracleGames.AuthenticationNavigationCommand();
                command.ParentContainer = grid;


                DateTime dt=DateTime.Now;
                long t=dt.ToFileTimeUtc();

                string url=String.Format("http://gate.shushanh5.lingyunetwork.com/gate/micro/login.aspx?t={0}&p=win", t);
                //url = "ms-appx-web:///test/test.html";
                h5.Load(command, url);
            };
        }
    }
}
