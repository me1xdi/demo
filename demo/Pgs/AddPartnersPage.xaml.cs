using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddPartnersPage.xaml
    /// </summary>
    public partial class AddPartnersPage : Page
    {
        private Partners _currentPartner = new Partners();
        public AddPartnersPage(Partners selectedPartner)
        {
            if (selectedPartner != null)
            {
                _currentPartner = selectedPartner;
            }
            DataContext = _currentPartner;
                
            InitializeComponent();
            cbPartType.ItemsSource = Entities.GetContext().PartnersType.ToList();
        }

        

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPartner.Name))
            {
                sb.AppendLine("Введитe наименование!");
            }

            if(cbPartType.SelectedItem==null)
            {
                sb.AppendLine("Выберите тип партнера!");
            }


            if (_currentPartner.Rating.ToString()=="")
            {
                sb.AppendLine("Введитe рейтинг!");
            }

            if (string.IsNullOrWhiteSpace(_currentPartner.Address))
            {
                sb.AppendLine("Введитe адрес!");
            }

            if (string.IsNullOrWhiteSpace(_currentPartner.INN))
            {
                sb.AppendLine("Введитe ИНН!");
            }
            if (string.IsNullOrWhiteSpace(_currentPartner.Director))
            {
                sb.AppendLine("Введитe ФИО!");
            }
            if (string.IsNullOrWhiteSpace(_currentPartner.PhoneNumber))
            {
                sb.AppendLine("Введитe телефон!");
            }
            if (string.IsNullOrWhiteSpace(_currentPartner.Email))
            {
                sb.AppendLine("Введитe email!");
            }


            if (sb.Length > 0) 
            { 
                MessageBox.Show(sb.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if(!Regex.IsMatch(tbRating.Text, @"^\d{1}$|^10$"))
            {
                MessageBox.Show("Введитк рейтинг от 1 до 10!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.IsMatch(tbINN.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Введитк ИНН из 10 цифр!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(!Regex.IsMatch(tbPhone.Text, @"^[+]7\d{10}$"))
            {
                MessageBox.Show("Введите номер телефона в формате +7**********", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentPartner.Id == 0)
                Entities.GetContext().Partners.Add(_currentPartner);

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new PartnersPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryPage(_currentPartner));
        }
    }
}
