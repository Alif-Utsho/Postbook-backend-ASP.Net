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
    public class ProfileServices
    {
        public static ProfileModel Get(int id)
        {
            var profile = DataAccessFactory.ProfileDataAccess().Get(id);
            var profileModel = new ProfileModel()
            {
                id = profile.id,
                user_id = profile.user_id,
                bio = profile.bio,
                dp = profile.dp,
                instagram = profile.instagram,
                github = profile.github,
                linkedin = profile.linkedin
            };
            return profileModel;
        }

        public static List<ProfileModel> Get()
        {
            var profileList = DataAccessFactory.ProfileDataAccess().Get();
            var profileModelList = new List<ProfileModel>();
            foreach(var profile in profileList)
            {
                var profileModel = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };
                profileModelList.Add(profileModel);
            }
            return profileModelList;
        }

        public static bool Add(ProfileModel profileModel)
        {
            var profile = new Profile()
            {
                user_id = profileModel.user_id,
                bio = profileModel.bio,
                dp = profileModel.dp,
                instagram = profileModel.instagram,
                github = profileModel.github,
                linkedin = profileModel.linkedin
            };
            return DataAccessFactory.ProfileDataAccess().Add(profile);
        }

        public static bool Update(ProfileModel profileModel)
        {
            var profile = new Profile()
            {
                id = profileModel.id,
                user_id = profileModel.user_id,
                bio = profileModel.bio,
                dp = profileModel.dp,
                instagram = profileModel.instagram,
                github = profileModel.github,
                linkedin = profileModel.linkedin
            };
            return DataAccessFactory.ProfileDataAccess().Update(profile);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ProfileDataAccess().Delete(id);
        }
    }
}
