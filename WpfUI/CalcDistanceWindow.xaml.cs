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
namespace WpfUI
{
    /// <summary>
    /// Interaction logic for CalcDistanceWindow.xaml
    /// </summary>
    public partial class CalcDistanceWindow : Window
    {
        public CalcDistanceWindow()
        {
            InitializeComponent();
        }
        private void CallBackroundWorker(object sender, RoutedEventArgs e)
        {
            List<object> args = new List<object> { source.Text, target.Text };

            BackgroundWorker gamad = new BackgroundWorker();
            gamad.DoWork += Gamad_DoWork;
            gamad.RunWorkerCompleted += Gamad_RunWorkerCompleted;
            gamad.RunWorkerAsync(args);

        }

        private void Gamad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result as string;
            this.distance.Text = result;
            this.distance2.Text = result;
            MessageBox.Show(e.Result.ToString());
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

