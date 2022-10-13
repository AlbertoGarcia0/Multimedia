using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace VideoInteractivo
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int contadorActo = 0;
        SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        SolidColorBrush blackBrush = new SolidColorBrush(Windows.UI.Colors.Black);

        public MainPage()
        {
            this.InitializeComponent();
            //video.MediaEnded
            //video.RealTimePlayback
        }

        /// <summary>
        /// Metodo principal para la selección de tarea dependiendo en el acto que vaya el video
        /// </summary>
        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            contadorActo++;
            switch (contadorActo)
            {
                case 1:
                    tarea1();
                    break;
                case 2:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }
        }

        /// <summary>
        /// Metodos relacionados con el acto 1
        /// </summary>
        public void tarea1()
        {
            Boton_Dialog1_1.Visibility = Visibility.Visible;
            Boton_Dialog1_2.Visibility = Visibility.Visible;
        }

        private void Boton_Dialog1_1_Click(object sender, RoutedEventArgs e)
        {
            video.Play();
            Boton_Dialog1_1.Visibility = Visibility.Collapsed;
            Boton_Dialog1_2.Visibility = Visibility.Collapsed;
            Text_Dialog.Visibility = Visibility.Collapsed;
            string pathAux;
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            path = path.Replace("\\bin\\Debug\\", "");
            pathAux = path + "/Assets/Videos/trailernovia_2.mp4";
            video.Source = new System.Uri(pathAux.ToString());
        }

        private void Boton_Dialog1_2_Click(object sender, RoutedEventArgs e)
        {
            Text_Dialog.Visibility = Visibility.Visible;
            Boton_Dialog1_2.Background = redBrush;
            Boton_Dialog1_2.Foreground = blackBrush;
        }

        /// <summary>
        /// Metodos relacionados con el acto 2
        /// </summary>
        public void tarea2()
        {
            Boton_Dialog1_1.Visibility = Visibility.Visible;
            Boton_Dialog1_2.Visibility = Visibility.Visible;
        }

        /*
private void Boton_Dialog1_1_Click(object sender, RoutedEventArgs e)
{
   video.Play();
   Boton_Dialog1_1.Visibility = Visibility.Collapsed;
   Boton_Dialog1_2.Visibility = Visibility.Collapsed;
   Text_Dialog.Visibility = Visibility.Collapsed;
   string pathAux;
   string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
   path = path.Replace("\\bin\\Debug\\", "");
   pathAux = path + "/Assets/Videos/trailernovia_2.mp4";
   video.Source = new System.Uri(pathAux.ToString());
}

private void Boton_Dialog1_2_Click(object sender, RoutedEventArgs e)
{
   Text_Dialog.Visibility = Visibility.Visible;
}
*/
    }
}
