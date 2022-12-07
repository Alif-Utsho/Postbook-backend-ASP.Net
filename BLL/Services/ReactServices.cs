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
    public class ReactServices
    {
        public static ReactModel Get(int id)
        {
            var react = DataAccessFactory.ReactDataAccess().Get(id);
            var reactModel = new ReactModel()
            {
                id = react.id,
                user_id = react.user_id,
                post_id = react.post_id
            };
            return reactModel;
        }

        public static List<ReactModel> Get()
        {
            var reactList = DataAccessFactory.ReactDataAccess().Get();
            var reactModelList = new List<ReactModel>();
            foreach(var react in reactList)
            {
                var reactModel = new ReactModel()
                {
                    id = react.id,
                    user_id = react.user_id,
                    post_id = react.post_id
                };
                reactModelList.Add(reactModel);
            }
            return reactModelList;
        }

        public static bool Add(ReactModel reactModel)
        {
            var react = new React()
            {
                user_id = reactModel.user_id,
                post_id = reactModel.post_id
            };
            return DataAccessFactory.ReactDataAccess().Add(react);
        }

        public static bool Update(ReactModel reactModel)
        {
            var react = new React()
            {
                id = reactModel.id,
                user_id = reactModel.user_id,
                post_id = reactModel.post_id
            };
            return DataAccessFactory.ReactDataAccess().Update(react);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ReactDataAccess().Delete(id);
        }

        public static List<ReactModel> GetByPostID(int id)
        {
            var reacts = DataAccessFactory.GetReacts().Get(id);
            var reactModelList = new List<ReactModel>();
            foreach(var react in reacts)
            {
                var reactModel = new ReactModel()
                {
                    id = react.id,
                    user_id = react.user_id,
                    post_id = react.post_id
                };
                reactModelList.Add(reactModel);
            }
            return reactModelList;
        }

        public static bool DeleteByPostID(int id)
        {
            return DataAccessFactory.DeleteReacts().DeleteByPostID(id);
        }

        public static bool DeleteByUserPostID(int user_id, int post_id)
        {
            return DataAccessFactory.ReactDeleteByUserPostID().Delete(user_id, post_id);
        }
    }
}
