using demo.Model;
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

namespace demo.Pgs
{
    /// <summary>
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage(Partners partHistory)
        {
            InitializeComponent();
            DataGridHistory.ItemsSource = Entities.GetContext().PartnerProducts.Where(x => x.IdPartner == partHistory.Id).ToList();
            tBlPart.Text = partHistory.Name;
        }
    }
}
