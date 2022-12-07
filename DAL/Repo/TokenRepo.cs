using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TokenRepo : iCrud<Token, string>
    {
        private DBEntities db;
        public TokenRepo(DBEntities db)
        {
            this.db = db;
        }
        public bool Add(Token model)
        {
            db.Tokens.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(string token)
        {
            var t = db.Tokens.FirstOrDefault(x => x.token1.Equals(token));
            db.Tokens.Remove(t);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(x => x.token1.Equals(token));
            
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token model)
        {
            var t = db.Tokens.FirstOrDefault(x => x.token1.Equals(model.token1));
            db.Entry(t).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }
    }
}
