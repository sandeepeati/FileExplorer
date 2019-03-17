using FileExplorer.ViewModels;
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

namespace FileExplorer.Views
{
    /// <summary>
    /// Interaction logic for FE_MainV.xaml
    /// </summary>
    public partial class FE_Main_V : Window
    {
        public FE_Main_V()
        {
            InitializeComponent();
            this.DataContext = new FE_Main_VM();
        }
    }
}
