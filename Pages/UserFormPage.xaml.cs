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
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class StudentFormPage : Page
    {
        private UsersService _service = new();
        public User _student = new();
        bool isEdit = false;
        public StudentFormPage(User? _editStudent = null)
        {
            InitializeComponent();
            if (_editStudent != null)
            {
                _student = _editStudent;
                isEdit = true;
            }
            DataContext = _student;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_student);
            NavigationService.GoBack();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Profile(object sender, RoutedEventArgs e)
        {
            if (_student.Name != null && _student.Email != null && _student.Password != null && _student.Login != null)
            {
                _student.UserProfile = new();
                NavigationService.Navigate(new UserProfileFormPage(isEdit,_student));
                
            }
            else
                MessageBox.Show("Все поля должны быть заполнены");
        }
    }
}
