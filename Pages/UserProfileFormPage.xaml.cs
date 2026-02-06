using Pract_12.Data;
using Pract_12.Service;

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

namespace Pract_12.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserProfileFormPage.xaml
    /// </summary>
    public partial class UserProfileFormPage : Page
    {
        private UsersService _service = new();
        public User _student = new();
        bool isEdit = false;
        public UserProfileFormPage(bool edit, User? _editStudent = null)
        {
            InitializeComponent();
            if (_editStudent != null)
            {
                _student = _editStudent;
            }
            isEdit = edit;
            DataContext = _student.UserProfile;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_student);

            NavigationService.GoBack();
            NavigationService.GoBack();
        }
        private void back(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
        }
    }
}
