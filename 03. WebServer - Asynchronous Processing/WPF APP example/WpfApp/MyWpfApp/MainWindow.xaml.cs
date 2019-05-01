using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadAndShowImage(Image1, "https://www.nationalgeographic.com/content/dam/animals/thumbs/rights-exempt/mammals/d/domestic-dog_thumb.ngsversion.1546554600360.adapt.1900.1.jpg");
            DownloadAndShowImage(Image2, "https://cdn1.medicalnewstoday.com/content/images/articles/322/322868/golden-retriever-puppy.jpg");
            DownloadAndShowImage(Image3, "https://teensnowtalk.com/wp-content/uploads/2017/07/Dog-1.jpg");
            DownloadAndShowImage(Image4, "https://thenypost.files.wordpress.com/2018/10/102318-dogs-color-determine-disesases-life.jpg?quality=90&strip=all&w=618&h=410&crop=1");
            DownloadAndShowImage(Image5, "https://d17fnq9dkz9hgj.cloudfront.net/uploads/2018/03/Pomeranian_01.jpeg");
            DownloadAndShowImage(Image6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZfrenxPz96_Nst7YnpoinEgdrUsFgSjtSUa3s5FRRB4lQLZCJ");
        }

        private void DownloadAndShowImage(Image image, string url)
        {
            WebClient webClient = new WebClient();

            var byteArray = webClient.DownloadData(url);

            Thread.Sleep(1000);

            image.Source = LoadImage(byteArray);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
