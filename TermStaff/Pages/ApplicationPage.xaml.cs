using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace TermStaff.Pages
{
    /// <summary>
    /// Interaction logic for ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        private DB _db = new DB();

        private ObservableCollection<Models.Application> myApplication;

        public ObservableCollection<Models.Application> MyApplication
        {
            get { return myApplication; }
            set { myApplication = value; }
        }
        public ApplicationPage(User user)
        {
            MyApplication = new ObservableCollection<Models.Application>(DB.Instance.Application.ToList().Where(a=> a.Group.User.Black_list == false));


            InitializeComponent();
        }

        private void Btn_Add_Black_Listk(object sender, RoutedEventArgs e)
        {
            var selectedApplications = DGApplication.SelectedItems.Cast<Models.Application>().ToList();

    if (MessageBox.Show($"Вы точно хотите добавить следующего пользователя {selectedApplications.Count()} 'в черный список ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
    {
        try
        {
            var reason = string.Empty;
            var addReason = MessageBox.Show("Хотите добавить причину?", "Добавление причины", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (addReason == MessageBoxResult.Yes)
            {
                reason = Microsoft.VisualBasic.Interaction.InputBox("Введите причину", "Причина", "");
            }

            foreach (var app in selectedApplications)
            {
                var user = app.Group.User;
                user.Black_list = true;
                app.Decription = reason;
            }

            DB.Instance.SaveChanges();
            MessageBox.Show("Пользователь успешно добавлен в черный список.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении пользователя в черный список: {ex.Message}");
        }
    }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
