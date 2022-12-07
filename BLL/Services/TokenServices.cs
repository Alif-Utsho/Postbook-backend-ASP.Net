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
    public class TokenServices
    {
        public static TokenModel Get(string tokenstring)
        {
            var token = DataAccessFactory.TokenDataAccess().Get(tokenstring);
            if (token == null) return null; 
            var tokenModel = new TokenModel()
            {
                id = token.id,
                user_id = token.user_id,
                token1 = token.token1,
                type = token.type,
                expired = token.expired
            };
            return tokenModel;
        }
        public static List<TokenModel> Get()
        {
            var tokenList = DataAccessFactory.TokenDataAccess().Get();
            var tokenModelList = new List<TokenModel>();
            foreach(var t in tokenList)
            {
                var token = new TokenModel()
                {
                    id = t.id,
                    user_id = t.user_id,
                    token1 = t.token1,
                    type = t.type,
                    expired = t.expired
                };
                tokenModelList.Add(token);
            }
            return tokenModelList;
        }
        public static bool Add(TokenModel token)
        {
            var t = new Token()
            {
                user_id = token.user_id,
                type = token.type,
                token1 = token.token1,
                expired = token.expired
            };
            return DataAccessFactory.TokenDataAccess().Add(t);
        }
        public static bool Update(TokenModel tokenModel)
        {
            var token = new Token()
            {
                id = tokenModel.id,
                type = tokenModel.type,
                token1 = tokenModel.token1,
                expired = tokenModel.expired,
                user_id = tokenModel.user_id
            };
            return DataAccessFactory.TokenDataAccess().Update(token);
        }
        public static bool Delete(string tokenString)
        {
            return DataAccessFactory.TokenDataAccess().Delete(tokenString);
        }
    }
}
