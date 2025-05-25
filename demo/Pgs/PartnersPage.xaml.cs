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
    /// Interaction logic for PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();

            List<Partners> oldPart = Entities.GetContext().Partners.ToList();
            List<PartnerNew> partn = new List<PartnerNew>();
            foreach(var par in oldPart)
            {
                partn.Add(new PartnerNew(par));
            }

            ListViewPartners.ItemsSource = partn;
        }




        class PartnerNew
        {
            public Partners partner { get; set; }

            public string discount { get; set; }

            public PartnerNew(Partners partner)
            {
                this.partner = partner;
                int sum = Entities.GetContext().PartnerProducts.Where(x => x.IdPartner == partner.Id).Count();
                if (sum > 0)
                {
                    sum = Entities.GetContext().PartnerProducts.Where(x => x.IdPartner == partner.Id).Sum(p => p.Quantity);
                    
                }
                discount = sum < 10000 ? "0%" : sum < 50000 ? "5%" : sum < 300000 ? "10%" : "15%";
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPartnersPage(null));
        }

        private void ListViewPartners_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListBox listBox)
            {
                var selectedItem = listBox.SelectedItem as PartnerNew;
                if (selectedItem != null)
                {
                    NavigationService.Navigate(new AddPartnersPage(selectedItem.partner));
                }
            }
               
        }
    }
}
