using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileExplorer.UserControls
{
    /// <summary>
    /// Interaction logic for FE_LocalDriveCard_UC.xaml
    /// </summary>
    public partial class FE_LocalDriveCard_UC : UserControl
    {
        public FE_LocalDriveCard_UC()
        {
            InitializeComponent();
        }
        
        public string DriveName
        {
            get { return (string)GetValue(DriveNameProperty); }
            set { SetValue(DriveNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DriveName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DriveNameProperty =
            DependencyProperty.Register("DriveName", typeof(string), typeof(FE_LocalDriveCard_UC), new PropertyMetadata(ToggleSpaceBar));

        private static void ToggleSpaceBar(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string driveName = d.GetValue(DriveNameProperty) as string;

            if (!string.IsNullOrEmpty(driveName) && driveName.ToUpper().StartsWith("CD"))
            {
                FE_LocalDriveCard_UC uc = d as FE_LocalDriveCard_UC;
                if (uc != null) uc.spacebar.Visibility = Visibility.Collapsed;
            }
        }
        
        public long UsedSpacePercent
        {
            get { return (long)GetValue(UsedSpacePercentProperty); }
            set { SetValue(UsedSpacePercentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UsedSpacePercent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsedSpacePercentProperty =
            DependencyProperty.Register("UsedSpacePercent", typeof(long), typeof(FE_LocalDriveCard_UC), new PropertyMetadata((long)0));

        public string SpaceInfo
        {
            get { return (string)GetValue(SpaceInfoProperty); }
            set { SetValue(SpaceInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpaceInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpaceInfoProperty =
            DependencyProperty.Register("SpaceInfo", typeof(string), typeof(FE_LocalDriveCard_UC), new PropertyMetadata(null));

        public string DriveImage
        {
            get { return (string)GetValue(DriveImageProperty); }
            set { SetValue(DriveImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DriveImageProperty =
            DependencyProperty.Register("DriveImage", typeof(string), typeof(FE_LocalDriveCard_UC), new PropertyMetadata(SetContentImage));

        private static void SetContentImage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string imgBase64Str = d.GetValue(DriveImageProperty) as string;

            if (!string.IsNullOrEmpty(imgBase64Str))
            {
                byte[] imgBytes = Convert.FromBase64String(imgBase64Str);
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.StreamSource = ms;
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.EndInit();

                    FE_LocalDriveCard_UC contentCard = d as FE_LocalDriveCard_UC;
                    if (d != null) contentCard.localDriveImg.Source = img;
                }
            }
        }
    }
}
