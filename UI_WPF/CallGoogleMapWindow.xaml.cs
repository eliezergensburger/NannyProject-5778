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
using System.Windows.Shapes;
using System.ComponentModel;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for CallGoogleMapWindow.xaml
    /// </summary>
    public partial class CallGoogleMapWindow : Window
    {
        public CallGoogleMapWindow()
        {
            InitializeComponent();
        }

        private void btnDistance_Click(object sender, RoutedEventArgs e)
        {
            this.resultsLB.Items.Clear();
            List<object> args = new List<object> { source.Text, target.Text };

            BackgroundWorker gamad = new BackgroundWorker();
            gamad.DoWork += Gamad_DoWork;
            gamad.RunWorkerCompleted += Gamad_RunWorkerCompleted;
            gamad.RunWorkerAsync(args);

            BackgroundWorker odgamad = new BackgroundWorker();
            odgamad.DoWork += Odgamad_DoWork;
            odgamad.RunWorkerCompleted += Odgamad_RunWorkerCompleted;
            odgamad.RunWorkerAsync(args);
        }

        private void Odgamad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.distance2.Text = e.Result.ToString();
            this.resultsLB.Items.Add(e.Result.ToString());
            this.btncontinue.Background = Brushes.LightGreen;
        }

        private void Odgamad_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> args = e.Argument as List<object>;

            string s = args[0] as string;
            string d = args[1] as string;

            int result = BL.FactorySingletonBL.getInstance.getDrivingDistance(s, d);
            e.Result = result;
        }

        private void Gamad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.distance.Text = e.Result.ToString(); ;
            this.resultsLB.Items.Add(e.Result.ToString());
            this.btncontinue.Background = Brushes.LightSalmon;
        }

        private void Gamad_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> args = e.Argument as List<object>;

            string s = args[0] as string;
            string d = args[1] as string;

            int result = BL.FactorySingletonBL.getInstance.getWalkingDistance(s, d);
            e.Result = result;
        }
    }
}
