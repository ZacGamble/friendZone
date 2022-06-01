using System;
using System.Collections.Generic;
using friendZone.Models;
using friendZone.Repositories;

namespace friendZone.Services
{
    public class FollowsService
    {
        private readonly FollowsRepository _repo;

        public FollowsService(FollowsRepository repo)
        {
            _repo = repo;
        }

        internal Follow Create(Follow follow)
        {
            return _repo.Create(follow);
        }
        internal Follow GetById(int id)
        {
            Follow found = _repo.GetById(id);
            if (found == null)
            {
                throw new System.Exception("No such favorite");
            }
            return found;
        }

        internal void Delete(int id, string followerId)
        {
            Follow followToRemove = GetById(id);
            if (followToRemove.FollowerId != followerId)
            {
                throw new Exception("You do not have permission to delete this");
            }
            _repo.Delete(id);
        }

        internal List<FollowerViewModel> GetFollows()
        {
            List<FollowerViewModel> follows = _repo.GetFollows();
            return follows;
        }
    }
}