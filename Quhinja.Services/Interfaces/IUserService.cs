﻿using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfoOutputModel>> GetUsers();
        Task<UserInfoOutputModel> GetUserAsync(int id);
        Task UpdateUserAsync(UserUpdateInputModel model, int userId);
        Task<int> GetRatingForUser(int id, int dishId);

        Task<IEnumerable<UserInfoOutputModel>> GetTodaysUsers();

        Task UpdateProfilePictureAsync(int userId, string profilePictureUrl);
    }
}
