using Foodieenator.Data.Context;
using Foodieenator.Data.UnitOfWork;
using Foodieenator.Entities.Entities;
using Foodieenator.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Service.Concrete
{
    public class UserService : IService<User>
    {
        IUnitOfWork _uow;
        public UserService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(User entity)
        {
            var user = GetById(entity.Id);
            if (user == null)
                _uow.GetRepository<User>().Add(entity);
            else
            {
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.Role = entity.Role;
                user.SurName = entity.SurName;
                user.UserName = entity.UserName;
                _uow.GetRepository<User>().Update(user);
            }

            _uow.SaveChanges();
        }

        public List<User> GetAll()
        {
            List<User> users = _uow.GetRepository<User>().GetAll();
            return users;
        }

        public User GetById(int id)
        {
            User user = _uow.GetRepository<User>().Get(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public void HardDelete(User entity)
        {
            var user = GetById(entity.Id);
            _uow.GetRepository<User>().HardDelete(user);
            _uow.SaveChanges();
        }
        public int Login(string userName,string password)
        {
            var user = _uow.GetRepository<User>().Get(x=>x.UserName==userName&&x.Password==password).FirstOrDefault();
            if (user != null)
            {
         
               if (user.Role == "Admin")
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
