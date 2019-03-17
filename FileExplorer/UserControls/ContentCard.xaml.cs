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
    /// Interaction logic for ContentCard.xaml
    /// </summary>
    public partial class ContentCard : UserControl
    {
        public ContentCard()
        {
            InitializeComponent();
        }

        #region ContentImage


        public string ContentImage
        {
            get { return (string)GetValue(ContentImageProperty); }
            set { SetValue(ContentImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentImageProperty =
            DependencyProperty.Register("ContentImage", typeof(string), typeof(ContentCard), new PropertyMetadata(SetContentImage));

        private static void SetContentImage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string imgBase64Str = d.GetValue(ContentImageProperty) as string;

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

                    ContentCard contentCard = d as ContentCard;
                    if (d != null) contentCard.contentImage.Source = img;
                }
            }
        }
        #endregion

        #region ContentName
        public string ContentName
        {
            get { return (string)GetValue(ContentNameProperty); }
            set { SetValue(ContentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentNameProperty =
            DependencyProperty.Register("ContentName", typeof(string), typeof(ContentCard), new PropertyMetadata(null));
        #endregion
    }
}
