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
using System.Collections.ObjectModel;

namespace gravità
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int altezzaVino;
        int altezzaCocaCola;
        ObservableCollection<string> altezze;
        
        //readonly Uri uriBottigliaVino = new Uri("vino.jpg", UriKind.Relative);//recupera uri
        public MainWindow()
        {
            InitializeComponent();
           
            //ImageSource img = new BitmapImage(uriBottigliaVino);//uso uri per creare oggetto img
            altezze = new ObservableCollection<string>();
            list_classifica.ItemsSource = altezze;
            SettaggioPerAvvio();


        }

        public void SettaggioPerAvvio()
        {
            list_classifica_finale.Visibility = Visibility.Hidden;
            list_classifica_finale.Items.Clear();
            altezze.Clear();
            altezzaCocaCola = 74;
            altezzaVino = 60;
            altezze.Add("vino");
            altezze.Add("coca cola");
        }

        public void IniziaCadutaVino()//metodo per muovere una immagine
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

                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                    altezzaVino += r.Next(15, 100);
                }
                else
                {
                    altezzaVino += 374 - altezzaVino;
                }
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    
                    altezze.RemoveAt(0);

                    altezze.Add("vino         " + Convert.ToString(altezzaVino));
                }));
                
            }
            this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
            {
                
                list_classifica_finale.Items.Add("vino");
            }));
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

                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                    altezzaCocaCola += r.Next(15, 100);
                }
                else
                {
                    altezzaCocaCola += 374 - altezzaCocaCola;
                }
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    altezze.RemoveAt(1);
                    altezze.Add("coca cola     " + Convert.ToString(altezzaCocaCola));


                }));
                
                
            }
            this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
            {
                
                list_classifica_finale.Items.Add("coca cola");
                list_classifica_finale.Visibility = Visibility.Visible;
            }));
        }

        private void btn_inizia_Click(object sender, RoutedEventArgs e)
        {
            SettaggioPerAvvio();
            Thread t1 = new Thread(new ThreadStart(IniziaCadutaVino));
            Thread t2 = new Thread(new ThreadStart(InizioCadutaCocacola));
            t1.Start();
            t2.Start();
            
        }
    }
}
    
