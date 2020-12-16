using System;
using System.Collections.Generic;
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
using System.Threading;

namespace gravità
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //readonly Uri uriBottigliaVino = new Uri("vino.jpg", UriKind.Relative);//recupera uri
        public MainWindow()
        {
            InitializeComponent();

            //ImageSource img = new BitmapImage(uriBottigliaVino);//uso uri per creare oggetto img
            
            


            Thread t1 = new Thread(new ThreadStart(iniziaCadutaBottiglie));
            t1.Start();
        }

        public void iniziaCadutaBottiglie()//metodo per muovere una immagine
        {
            int altezza = 90;
            Random r = new Random();
            while (altezza < 270)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    if (altezza != 90)
                    {
                        altezza += r.Next(50, 100);
                        img_cocacola.Margin = (new Thickness(403, altezza, 0, 0));
                        altezza += r.Next(50, 100);
                        img_vino.Margin = new Thickness(301, altezza, 0, 0);
                    }
                    else
                    {
                        img_vino.Margin = new Thickness(301, altezza, 0, 0);
                        img_cocacola.Margin = (new Thickness(403, altezza, 0, 0));
                        altezza += 1;
                    }
                       
                    
                    

                }));
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(200, 400)));
                
            }


                
        }
    }
}
