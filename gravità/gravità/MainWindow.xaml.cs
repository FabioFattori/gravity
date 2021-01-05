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
        int altezzaVino;
        int altezzaCocaCola;
        //readonly Uri uriBottigliaVino = new Uri("vino.jpg", UriKind.Relative);//recupera uri
        public MainWindow()
        {
            InitializeComponent();

            //ImageSource img = new BitmapImage(uriBottigliaVino);//uso uri per creare oggetto img
            
            


            Thread t1 = new Thread(new ThreadStart(iniziaCadutaVino));
            Thread t2 = new Thread(new ThreadStart(InizioCadutaCocacola));
            t1.Start();
            t2.Start();
        }


        public void iniziaCadutaVino()//metodo per muovere una immagine
        {

            altezzaVino = 60;
            Random r = new Random();
            while (altezzaVino != 374)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    img_vino.Margin = new Thickness(463, altezzaVino, 0, 0);


                }));
                if (374 - altezzaVino >= 50)
                {

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(200, 400)));
                    altezzaVino += r.Next(10, 75);
                }
                else
                {
                    altezzaVino += 374 - altezzaVino;
                }
            }
                
            
        }

        public void InizioCadutaCocacola()
        {
            int altezzaCocaCola = 74;
            Random r = new Random();
            while (altezzaCocaCola != 374)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    img_cocacola.Margin = new Thickness(383, altezzaCocaCola, 0, 0);


                }));
                if (374 - altezzaCocaCola >= 50)
                {

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(200, 400)));
                    altezzaCocaCola += r.Next(10, 75);
                }
                else
                {
                    altezzaCocaCola += 374 - altezzaCocaCola;
                }
            }
        }
    }
}
    
