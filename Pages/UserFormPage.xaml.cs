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
            bool ex = false;
            if (_student.UserProfile != null)
            {
                if (_student.UserProfile.Bio == "" || _student.UserProfile.Bio == null)
                {
                    _student.UserProfile.Bio = null;
                }
                else
                {
                    ex = true;
                }
                if (_student.UserProfile.AvatarUrl == "" || _student.UserProfile.AvatarUrl == null)
                {
                    _student.UserProfile.AvatarUrl = null;
                }
                else
                {
                    ex = true;
                }
                if (_student.UserProfile.Phone == "" || _student.UserProfile.Phone == null)
                {
                    _student.UserProfile.Phone = null;
                }
                else
                {
                    ex = true;
                }
                if (_student.UserProfile.Birthday.ToString() == "" || _student.UserProfile.Birthday == null)
                {
                    _student.UserProfile.Birthday = null;
                }
                else
                {
                    ex = true;
                }
            }


            if (ex)
            {
                if (isEdit)
                    _service.Commit();
                else
                    _service.Add(_student);
                NavigationService.GoBack();
            }
            else
            {
                _student.UserProfile = null;
                NavigationService.GoBack();     
            }
        }
        private void back(object sender, RoutedEventArgs e)//как исправить ошибку
        {
            NavigationService.Navigate(new MainPage());
        }

        private void Profile(object sender, RoutedEventArgs e)
        {
            if(_student.UserProfile == null)
            _student.UserProfile = new();
            NavigationService.Navigate(new UserProfileFormPage(isEdit, _student));
        }
    }
}
