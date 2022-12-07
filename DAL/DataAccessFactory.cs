using DAL.Database;
using DAL.iRepo;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        DBEntities db = new DBEntities();
        public static iCrud<User, int> UserDataAccess()
        {
            return new UserRepo(new DBEntities());
        }
        public static iCrud<Token, string> TokenDataAccess()
        {
            return new TokenRepo(new DBEntities());
        }
        public static iCrud<Report, int> ReportDataAccess()
        {
            return new ReportRepo(new DBEntities());
        }
        public static iCrud<React, int> ReactDataAccess()
        {
            return new ReactRepo(new DBEntities());
        }
        public static iCrud<Profile, int> ProfileDataAccess()
        {
            return new ProfileRepo(new DBEntities());
        }
        public static iCrud<Post, int> PostDataAccess()
        {
            return new PostRepo(new DBEntities());
        }
        public static iCrud<Connection, int> ConnectionDataAccess()
        {
            return new ConnectionRepo(new DBEntities());
        }
        public static iCrud<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(new DBEntities());
        }
        public static iDeleteByUserPostID<int, int> ReactDeleteByUserPostID()
        {
            return new ReactRepo(new DBEntities());
        }


        public static iAuth AuthDataAccess()
        {
            return new UserRepo(new DBEntities());
        }

        
        public static iDetails<Post, int> PostDetailsAccess()
        {
            return new PostRepo(new DBEntities());
        }

        public static iConDetails<Connection, int> ConnectionDetails()
        {
            return new ConnectionRepo(new DBEntities());
        }

        public static iDeleteByPostID<Comment, int> DeleteComment()
        {
            return new CommentRepo(new DBEntities());
        }
        public static iDeleteByPostID<React, int> DeleteReacts()
        {
            return new ReactRepo(new DBEntities());
        }
        public static iDeleteByPostID<Report, int> DeleteReport()
        {
            return new ReportRepo(new DBEntities());
        }

        public static iFindByUserID<Post, int> GetPostOfUser()
        {
            return new PostRepo(new DBEntities());
        }

        public static iFindByPostID<React, int> GetReacts()
        {
            return new ReactRepo(new DBEntities());
        }
        public static iFindByPostID<Comment, int> GetComments()
        {
            return new CommentRepo(new DBEntities());
        }
        public static iFindByPostID<Report, int> GetReports()
        {
            return new ReportRepo(new DBEntities());
        }
    }
}
