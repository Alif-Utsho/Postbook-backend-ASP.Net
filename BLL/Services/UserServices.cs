using BLL.Entities;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static UserModel Get(int id)
        {
            var user = DataAccessFactory.UserDataAccess().Get(id);
            if (user == null) return null;
            var userModel = new UserModel()
            {
                id = user.id,
                name = user.name,
                phone = user.phone,
                email = user.email,
                type = user.type,
                password = user.password
            };
            return userModel;
        }

        public static List<UserModel> Get()
        {
            var userList = DataAccessFactory.UserDataAccess().Get();
            var userModelList = new List<UserModel>();
            foreach(var user in userList)
            {
                var userModel = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type,
                    password = user.password
                };
                userModelList.Add(userModel);
            }
            return userModelList;
        }
        public static bool Add(UserModel userModel)
        {
            var user = new User()
            {
                name = userModel.name,
                phone = userModel.phone,
                email = userModel.email,
                type = userModel.type,
                password = userModel.password
            };
            return DataAccessFactory.UserDataAccess().Add(user);
        }

        public static bool Update(UserModel userModel)
        {
            var user = new User()
            {
                id = userModel.id,
                name = userModel.name,
                phone = userModel.phone,
                email = userModel.email,
                type = userModel.type,
                password = userModel.password
            };
            return DataAccessFactory.UserDataAccess().Update(user);
        }
        
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }

        public static UserModel Registration(UserModel userModel)
        {
            var user = new User()
            {
                name = userModel.name,
                phone = userModel.phone,
                email = userModel.email,
                type = userModel.type,
                password = userModel.password
            };
            var u = DataAccessFactory.AuthDataAccess().Registration(user);
            var um = new UserModel()
            {
                id = u.id,
                name = u.name,
                phone = u.phone,
                email = u.email,
                type = u.type,
                password = u.password
            };
            return um;
        }

        public static UserModel Login(UserModel userModel)
        {
            var user = new User()
            {
                email = userModel.email,
                password = userModel.password
            };
            var u = DataAccessFactory.AuthDataAccess().Login(user);
            if (u == null) return null;
            var um = new UserModel()
            {
                id = u.id,
                name = u.name,
                phone = u.phone,
                email = u.email,
                type = u.type,
                password = u.password
            };
            return um;
        }
    }
}
