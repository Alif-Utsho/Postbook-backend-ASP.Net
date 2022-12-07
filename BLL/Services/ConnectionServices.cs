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
    public class ConnectionServices
    {
        public static ConnectionModel Get(int id)
        {
            var connection = DataAccessFactory.ConnectionDataAccess().Get(id);
            var connectionModel = new ConnectionModel()
            {
                id = connection.id,
                sender = connection.sender,
                receiver = connection.receiver,
                status = connection.status
            };
            return connectionModel;
        }

        public static List<ConnectionModel> Get()
        {
            var connectionList = DataAccessFactory.ConnectionDataAccess().Get();
            var connectionModelList = new List<ConnectionModel>();
            foreach(var connection in connectionList)
            {
                var connectionModel = new ConnectionModel()
                {
                    id = connection.id,
                    sender = connection.sender,
                    receiver = connection.receiver,
                    status = connection.status
                };
                connectionModelList.Add(connectionModel);
            }
            return connectionModelList;
        }

        public static bool Add(ConnectionModel connectionModel)
        {
            var connection = new Connection()
            {
                sender = connectionModel.sender,
                receiver = connectionModel.receiver,
                status = connectionModel.status
            };
            return DataAccessFactory.ConnectionDataAccess().Add(connection);
        }

        public static bool Update(ConnectionModel connectionModel)
        {
            var connection = new Connection()
            {
                id = connectionModel.id,
                sender = connectionModel.sender,
                receiver = connectionModel.receiver,
                status = connectionModel.status
            };
            return DataAccessFactory.ConnectionDataAccess().Update(connection);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ConnectionDataAccess().Delete(id);
        }


        public static List<ConnectionDetails> GetRequests(int id)
        {
            var requests = DataAccessFactory.ConnectionDetails().GetRequests(id);
            var connectionDetailsList = new List<ConnectionDetails>();
            foreach(var request in requests)
            {
                var connectionDetails = new ConnectionDetails();
                connectionDetails.id = request.id;
                connectionDetails.status = request.status;
                var user = DataAccessFactory.UserDataAccess().Get(request.sender);
                
                connectionDetails.sender = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                var profile = DataAccessFactory.ProfileDataAccess().Get(request.sender);
                connectionDetails.sender_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };
                user = DataAccessFactory.UserDataAccess().Get(request.receiver);
                connectionDetails.receiver = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                profile = DataAccessFactory.ProfileDataAccess().Get(request.sender);
                connectionDetails.receiver_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };

                connectionDetailsList.Add(connectionDetails);

            }
            return connectionDetailsList;
        }
        public static List<ConnectionDetails> GetSents(int id)
        {
            var sents = DataAccessFactory.ConnectionDetails().GetSents(id);
            var connectionDetailsList = new List<ConnectionDetails>();
            foreach (var sent in sents)
            {
                var connectionDetails = new ConnectionDetails();
                connectionDetails.id = sent.id;
                connectionDetails.status = sent.status;
                var user = DataAccessFactory.UserDataAccess().Get(sent.sender);
                connectionDetails.sender = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                var profile = DataAccessFactory.ProfileDataAccess().Get(sent.sender);
                connectionDetails.sender_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };
                user = DataAccessFactory.UserDataAccess().Get(sent.receiver);
                connectionDetails.receiver = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                profile = DataAccessFactory.ProfileDataAccess().Get(sent.sender);
                connectionDetails.receiver_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };

                connectionDetailsList.Add(connectionDetails);

            }
            return connectionDetailsList;
        }
        public static List<ConnectionDetails> GetFriends(int id)
        {
            var friends = DataAccessFactory.ConnectionDetails().GetFriends(id);
            var connectionDetailsList = new List<ConnectionDetails>();
            foreach (var friend in friends)
            {
                var connectionDetails = new ConnectionDetails();
                connectionDetails.id = friend.id;
                connectionDetails.status = friend.status;
                var user = DataAccessFactory.UserDataAccess().Get(friend.sender);

                connectionDetails.sender = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                var profile = DataAccessFactory.ProfileDataAccess().Get(friend.sender);
                connectionDetails.sender_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };
                user = DataAccessFactory.UserDataAccess().Get(friend.receiver);
                connectionDetails.receiver = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                profile = DataAccessFactory.ProfileDataAccess().Get(friend.sender);
                connectionDetails.receiver_profile = new ProfileModel()
                {
                    id = profile.id,
                    user_id = profile.user_id,
                    bio = profile.bio,
                    dp = profile.dp,
                    instagram = profile.instagram,
                    github = profile.github,
                    linkedin = profile.linkedin
                };

                connectionDetailsList.Add(connectionDetails);

            }
            return connectionDetailsList;
        }

        public static List<ConnectionModel> SentByFriends(int id)
        {
            var connectionList = DataAccessFactory.ConnectionDetails().SentByFriends(id);
            var connectionModelList = new List<ConnectionModel>();
            foreach (var connection in connectionList)
            {
                var connectionModel = new ConnectionModel()
                {
                    id = connection.id,
                    sender = connection.sender,
                    receiver = connection.receiver,
                    status = connection.status
                };
                connectionModelList.Add(connectionModel);
            }
            return connectionModelList;
        }
        public static List<ConnectionModel> RecByFriends(int id)
        {
            var connectionList = DataAccessFactory.ConnectionDetails().RecByFriends(id);
            var connectionModelList = new List<ConnectionModel>();
            foreach (var connection in connectionList)
            {
                var connectionModel = new ConnectionModel()
                {
                    id = connection.id,
                    sender = connection.sender,
                    receiver = connection.receiver,
                    status = connection.status
                };
                connectionModelList.Add(connectionModel);
            }
            return connectionModelList;
        }
    }
}
