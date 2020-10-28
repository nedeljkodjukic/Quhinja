using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;

        public UserService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public async Task<UserInfoOutputModel> GetUserAsync(int id)
        {
            return await data.Users
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .Select(user => mapper.Map<UserInfoOutputModel>(user))
                          .SingleOrDefaultAsync(us => us.Id == id);
        }

        public async Task<IEnumerable<UserInfoOutputModel>> GetUsers()
        {
            return await data.Users
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .Select(user => mapper.Map<UserInfoOutputModel>(user))
                          .ToListAsync();
        }

        public async Task UpdateUserAsync(UserBasicInputModel model, int userId)
        {
            var userInDb = await data.Users.FindAsync(userId);

            userInDb.Name = model.Name;
            userInDb.Surname = model.Surname;
            userInDb.Position = model.Position;
            userInDb.DishId = model.DishId;
            

            data.SaveChanges();
        }
    }
}
