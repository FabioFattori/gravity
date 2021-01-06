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
        int altezzaPringles;
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
            altezzaCocaCola = 72;
            altezzaVino = 62;
            altezzaPringles = 45;
            altezze.Add("vino");
            altezze.Add("coca cola");
            altezze.Add("pringles");
        }

        public void InizioCadutaVino()//metodo per muovere una immagine
        {
            
            altezzaVino = 62;
            Random r = new Random();
            while (altezzaVino != 388)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    img_vino.Margin = new Thickness(463, altezzaVino, 0, 0);
                    

                }));
                if (388 - altezzaVino >= 45)
                {

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    altezzaVino += r.Next(20, 35);
                }
                else
                {
                    altezzaVino += 388 - altezzaVino;
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
                list_classifica_finale.Visibility = Visibility.Visible;
            }));
        }

        public void InizioCadutaCocacola()
        {
            
            int altezzaCocaCola = 72;
            Random r = new Random();
            while (altezzaCocaCola != 402)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    img_cocacola.Margin = new Thickness(383, altezzaCocaCola, 0, 0);
                    

                }));
                if (402 - altezzaCocaCola >= 50)
                {

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    altezzaCocaCola += r.Next(25, 30);
                }
                else
                {
                    altezzaCocaCola += 402 - altezzaCocaCola;
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
        public void InizioCadutaPringles()//metodo per muovere una immagine
        {

            altezzaPringles = 45;
            Random r = new Random();
            while (altezzaPringles != 384)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {
                    img_pringles.Margin = new Thickness(343, altezzaPringles, 0, 0);


                }));
                if (384 - altezzaPringles >= 65)
                {

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    altezzaPringles += r.Next(24, 32);
                }
                else
                {
                    altezzaPringles += 384 - altezzaPringles;
                }
                this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
                {

                    altezze.RemoveAt(2);

                    altezze.Add("pringles         " + Convert.ToString(altezzaPringles));
                }));

            }
            this.Dispatcher.BeginInvoke(new Action(() =>//scriviamo cosi perchè il wpf è gestito da thread quindi vanno in conflitto:action è un delegato che risolve il conflitto
            {

                list_classifica_finale.Items.Add("pringles");
                list_classifica_finale.Visibility = Visibility.Visible;
            }));
        }

        private void btn_inizia_Click(object sender, RoutedEventArgs e)
        {
            
            SettaggioPerAvvio();
            Thread t1 = new Thread(new ThreadStart(InizioCadutaVino));
            Thread t2 = new Thread(new ThreadStart(InizioCadutaCocacola));
            Thread t3 = new Thread(new ThreadStart(InizioCadutaPringles));
            t1.Start();
            t2.Start();
            t3.Start();

           
        }
    }
}
    
