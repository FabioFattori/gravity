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
            int altezza = 74;
            Random r = new Random();
            int supporto;
            this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
            {
                
                img_vino.Margin = new Thickness(301, altezza, 0, 0);
                img_cocacola.Margin = (new Thickness(403, altezza, 0, 0));

            }));

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                while (altezza < 240)
                {
                    supporto = r.Next(25, 50);
                    altezza += supporto;
                    img_cocacola.Margin = (new Thickness(381, altezza, 0, 0));
                    altezza -= supporto;
                    supporto = r.Next(25, 50);
                    altezza += supporto;
                    img_vino.Margin = new Thickness(461, altezza, 0, 0);
                    altezza -= supporto;
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                }
            }));

        }
    }
}
