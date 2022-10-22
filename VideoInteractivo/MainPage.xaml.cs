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
        int fallos = 0;
        int fallosTarea2 = 0;
        int aciertos = 0;
        int acto = 1;
        SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        SolidColorBrush blackBrush = new SolidColorBrush(Windows.UI.Colors.Black);

        public MainPage()
        {
            this.InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////    METODO PRINCIPAL
        /// <summary>
        /// Metodo principal para la selección de tarea dependiendo en el acto que vaya el video
        /// </summary>
        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            switch (acto)
            {
                case 1:
                    tarea1();
                    break;
                case 2:
                    tarea2();
                    break;
                case 100:
                    Boton_Reintentar1.Visibility = Visibility.Visible;
                    break;
                case 3:
                    tarea3();
                    break;
                default:
                    // code block
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////    TAREA 1
        /// <summary>
        /// Metodos relacionados con el acto 1
        /// </summary>
        public void tarea1()
        {
            Rectangulo_Dialog.Visibility = Visibility.Visible;
            Boton_Dialog1_1.Visibility = Visibility.Visible;
            Boton_Dialog1_2.Visibility = Visibility.Visible;
        }

        private void Boton_Dialog1_1_Click(object sender, RoutedEventArgs e)
        {
            aciertos++;
            acto = 2;
            video.Play();
            selector_de_video(1);
            Boton_Dialog1_1.Visibility = Visibility.Collapsed;
            Boton_Dialog1_2.Visibility = Visibility.Collapsed;
            Text_Dialog.Visibility = Visibility.Collapsed;
            Rectangulo_Dialog.Visibility = Visibility.Collapsed;

        }

        private void Boton_Dialog1_2_Click(object sender, RoutedEventArgs e)
        {
            fallos++;
            acto = 100;
            video.Play();
            selector_de_video(2);
            Boton_Dialog1_1.Visibility = Visibility.Collapsed;
            Boton_Dialog1_2.Visibility = Visibility.Collapsed;
            Text_Dialog.Visibility = Visibility.Collapsed;
            Rectangulo_Dialog.Visibility = Visibility.Collapsed;
        }

        private void Boton_Reintentar1_Click(object sender, RoutedEventArgs e)
        {
            acto = 1;
            Boton_Reintentar1.Visibility = Visibility.Collapsed;
            video.Play();
            selector_de_video(0);
        }


        /////////////////////////////////////////////////////////////////////////////////////////    TAREA 2
        /// <summary>
        /// Metodos relacionados con el acto 2
        /// </summary>
        public void tarea2()
        {
            Rectangulo_Dialog.Visibility = Visibility.Visible;
            Imagen_Dialog3.Visibility = Visibility.Visible;
            TextBox_Dialog3.Visibility = Visibility.Visible;
            Text_Dialog3.Visibility = Visibility.Visible;
            Boton_Dialog3.Visibility = Visibility.Visible;
        }

        private void Boton_Dialog3_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Dialog3.Text.ToLower() == "bruja")
            {
                aciertos++;
                acto = 3;
                video.Play();
                selector_de_video(3);
                Rectangulo_Dialog.Visibility = Visibility.Collapsed;
                Imagen_Dialog3.Visibility = Visibility.Collapsed;
                TextBox_Dialog3.Visibility = Visibility.Collapsed;
                error_Dialog3.Visibility = Visibility.Collapsed;
                Text_Dialog3.Visibility = Visibility.Collapsed;
                Boton_Dialog3.Visibility = Visibility.Collapsed;
                botonEnlace.Visibility = Visibility.Visible;
                Text_Dialog.Visibility = Visibility.Visible;
                Rectangulo_Link.Visibility = Visibility.Visible;
            }
            else
            {
                fallos++;
                fallosTarea2++;
                switch (fallosTarea2)
                {
                    case 1:
                        error_Dialog3.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        error_Dialog3.Text = "Respuesta incorrecta: B _ _ j _";
                        break;
                    case 3:
                        error_Dialog3.Text = "Respuesta incorrecta: B _ uj _";
                        break;
                    case 4:
                        error_Dialog3.Text = "Respuesta incorrecta: Bruj _";
                        break;
                    default:
                        // code block
                        break;
                }
            }

        }


        /////////////////////////////////////////////////////////////////////////////////////////    TAREA 3
        /// <summary>
        /// Metodos relacionados con el acto 3
        /// </summary>
        public void tarea3()
        {
            botonEnlace.Visibility = Visibility.Collapsed;
            Text_Dialog.Visibility = Visibility.Collapsed;
            Rectangulo_Link.Visibility = Visibility.Collapsed;
        }


        /////////////////////////////////////////////////////////////////////////////////////////    METODOS AUXILIARES
        /// <summary>
        /// Metodo en el cual ira cambiando el video del reproductor multimedia
        /// </summary>
        /// <param name="num_video"></param>
        public void selector_de_video(int num_video)
        {
            string pathAux = "";
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            path = path.Replace("\\bin\\Debug\\", "");
            
           
            switch (num_video)
            {
                case 0:
                    pathAux = path + "/Assets/Videos/minecraft_1.mp4";
                    break;
                case 1:
                    pathAux = path + "/Assets/Videos/minecraft_2vivo.mp4";
                    break;
                case 2:
                    pathAux = path + "/Assets/Videos/minecraft_2muerte.mp4";
                    break;
                case 3:
                    pathAux = path + "/Assets/Videos/minecraft_3.mp4";
                    break;
                default:
                    // code block
                    break;
            }

            video.Source = new System.Uri(pathAux.ToString());
        }
        async void abrirEnlace(Uri uri)
        {
            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }

        private void botonEnlace_Click(object sender, RoutedEventArgs e)
        {
            string enlace = "";
            switch (acto)
            {
                case 3:
                    // Create a Uri object from a URI string 
                    enlace = @"https://minecraft.fandom.com/wiki/Brewing";
                    break;
                default:
                    // code block
                    break;
            }
            var uri = new Uri(enlace);
            abrirEnlace(uri);
        }
    }
}
