using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_12.Data
{
    public class UserProfile : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string? avatarurl;
        public string? AvatarUrl
        {
            get => avatarurl;
            set => SetProperty(ref avatarurl, value);
        }

        private string phone;
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }

        private string bio;
        public string Bio
        {
            get => bio;
            set => SetProperty(ref bio, value);
        }
        private User _user;
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
    }
}
