using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using friendZone.Models;

namespace friendZone.Repositories
{
    public class FollowsRepository
    {
        private readonly IDbConnection _db;

        public FollowsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Follow Create(Follow follow)
        {
            string sql = @"
            INSERT INTO follows
            (followerId, followingId)
            VALUES
            (@FollowerId, @FollowingId);
            SELECT LAST_INSERT_ID();";
            follow.Id = _db.ExecuteScalar<int>(sql, follow);
            return follow;
        }

        internal Follow GetById(int id)
        {
            string sql = @"SELECT * FROM follows WHERE id = @id LIMIT 1";
            return _db.QueryFirstOrDefault<Follow>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM follows WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal List<FollowerViewModel> GetFollows()
        {
            string sql = @"SELECT * FROM accounts";
            return _db.Query<FollowerViewModel>(sql).ToList();
        }
    }
}