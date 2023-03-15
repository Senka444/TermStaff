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
using TermStaff.Models;

namespace TermStaff.Pages
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public User GlobalUser { get; set; }

        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public Authorization()
        {
            CurrentUser = new User();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Id != null)
            {
                GlobalUser = DB.Instance.User.Where(u => u.Id == CurrentUser.Id).FirstOrDefault();
                if (GlobalUser != null)
                {
                    NavigationService.Navigate(new ApplicationPage(GlobalUser));
                }
                else
                {
                    MessageBox.Show("You Lose");

                }
            }
        }
    }
}
