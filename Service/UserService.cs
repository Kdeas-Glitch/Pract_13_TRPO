using Microsoft.EntityFrameworkCore;

using Pract_12.Data;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_12.Service
{
    public class UsersService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<User> Users { get; set; } = new();
        public UsersService()
        {
            GetAll();
        }
        public void Add(User student)
        {
            var _student = new User
            {
                Name = student.Name,
                Login = student.Login,
                Email = student.Email,
                Password = student.Password,
                CreatedAt = student.CreatedAt,
                UserProfile = student.UserProfile,
            };
            _db.Add<User>(_student);
            Commit();
            Users.Add(_student);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Students
                .Include(s=>s.UserProfile)
                .ToList();
            Users.Clear();
            foreach (var student in users)
            {
                Users.Add(student);
            }
        }
        public void Remove(User student)
        {
            _db.Remove<User>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
    }
}
