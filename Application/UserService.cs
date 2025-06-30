using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;

namespace Getting_Started.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid user ID");
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<int> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(id);
            }
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

    }
}
