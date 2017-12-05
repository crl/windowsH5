using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace taohuoxinggeH5
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
                //h5.Load(command, "http://h5.mguwp.net/");//游戏起始地址
                //h5.Load(command, "ms-appx-web:///Plant/index.html");//这个是本地

                DateTime dt=DateTime.Now;
                long t=dt.ToFileTimeUtc();

                string url=String.Format("http://gate.shushanh5.lingyunetwork.com/gate/micro/login.aspx?t={0}&p=win", t);
                //url = "http://192.168.1.51/test.html";

                h5.Load(command, url);
                h5.ShowAdvertisement += (asender, ae) =>//这个是广告，如果不需要广告则不用些这个，具体广告怎么接可以看文档
                {
                    var ad = new MiracleGames.Advertising.UI.AdControl("xxxxxxxxxx", "yyyyyyyyyy", true);//第一个是pc，第二个是手机，第三个广告刷新
                    ad.CloseIconVisibility = Visibility.Visible;
                    ad.ErrorOccurred += async (ss, ee) =>
                    {
                        System.Diagnostics.Debug.WriteLine(ee.ToString());
                        MessageDialog md = new MessageDialog(ee.Exception.ToString());
                        await md.ShowAsync();
                    };
                    this.grid.Children.Add(ad);
                    Canvas.SetZIndex(ad, 32766);
                };
            };
        }
    }
}
