using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Bogus;

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

        private string? Password;

        public string? password
        {
            get { return Password; }
            set { Password = value;
                OnPropertyChanged("password");
            }
        }




        public event PropertyChangedEventHandler ?PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler ?handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtbx.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx.Text.Length > 5) password = txtbx.Text;
            else MessageBox.Show("Invalid Argument", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            txtbx.Text = "";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtbx.Visibility = Visibility.Collapsed;
            btn2.Visibility = Visibility.Collapsed;

            var faker = new Faker();
            password=faker.Internet.Password(8);

        }
    }
}
