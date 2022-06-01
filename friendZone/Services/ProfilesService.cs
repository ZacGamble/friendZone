using friendZone.Repositories;

namespace friendZone.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }
    }
}