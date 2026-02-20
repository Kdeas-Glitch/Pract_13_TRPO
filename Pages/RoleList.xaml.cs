using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Pract_12.Data;
using Pract_12.Service;
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

namespace Pract_12.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleList.xaml
    /// </summary>
    public partial class RoleList : Page
    {
        public RolesService RoleService { get; set; } = new();
        public Role? current {  get; set; } = null;

        public ObservableCollection<User> Users { get; set; } = new();
        public UsersService UsersServic { get; set; } = new();
        

        public RoleList()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Choose(object sender, MouseButtonEventArgs e)
        {
            //if (current != null)
            //{
            //    RoleService.LoadRelation(current, "User");
            //}
            Users.Clear();
            UsersServic.GetAll();
            foreach(var user in UsersServic.Users)
            {
                if (user.Role.Title == current.Title)
                {
                    Users.Add(user);
                }
            }

        }
    }
}
