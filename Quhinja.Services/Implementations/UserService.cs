using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
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
            var userInDb= await data.Users
                .Include(u=>u.MissedDates)
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .SingleOrDefaultAsync(us => us.Id == id);
            if (userInDb!=null)
            {
                var outputObject = mapper.Map<UserInfoOutputModel>(userInDb);
                return outputObject;
            }
            else
            {
                throw new Exception("Ne postoji u bazi");

            }
        }
        public async Task<int> GetRatingForUser(int id, int dishId)
        {
            var rating = await data.UsersRatingForDishes.Where(x => x.DishId == dishId && x.UserId == id).Select(x => x.Rating).FirstOrDefaultAsync();
            return rating;
        }

        public async Task<IEnumerable<UserInfoOutputModel>> GetTodayBirthUsers()
        {
            DateTime today = DateTime.Now;
            return await data.Users
                            .Where(x=>x.DateOfBirth.Day== today.Day && x.DateOfBirth.Month == today.Month)
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .Select(user => mapper.Map<UserInfoOutputModel>(user))
                          .ToListAsync();
        }

        public async Task<IEnumerable<UserInfoOutputModel>> GetTodayEmployeeDateUsers()
        {
            DateTime today = DateTime.Now;
            return await data.Users
                            .Where(x => x.DateOfEmployment.Day == today.Day && x.DateOfEmployment.Month == today.Month)
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .Select(user => mapper.Map<UserInfoOutputModel>(user))
                          .ToListAsync();
        }

        public async Task<IEnumerable<UserInfoOutputModel>> GetUsers()
        {
            return await data.Users
                           .Include(u => u.MissedDates).ThenInclude(x=>x.MenuItem)
                          .Include(u => u.FavouriteDish)
                          .Include(u => u.UserRoles)
                          .Select(user => mapper.Map<UserInfoOutputModel>(user))
                          .ToListAsync();
        }

        public async Task UpdateUserAsync(UserUpdateInputModel model, int userId)
        {
            var userInDb = await data.Users.FindAsync(userId);
            userInDb.Name = model.Name;
            userInDb.Surname = model.Surname;
            var oldDish=0;

            if (model.FavouriteDishId != 0)
            {
                if(userInDb.FavouriteDishId!=null)
                oldDish = (int)userInDb.FavouriteDishId;
                else oldDish = 0;

                userInDb.FavouriteDishId = model.FavouriteDishId;
                
            }

            data.Update(userInDb);
            var menuItemForEmpl = await data.MenuItems.Include(x => x.Recipe).Where(x => x.DateOfDish.Date == userInDb.DateOfEmployment.Date).FirstOrDefaultAsync();

            var menuItemForBirth = await data.MenuItems.Include(x => x.Recipe).Where(x => x.DateOfDish.Date == userInDb.DateOfBirth.Date).FirstOrDefaultAsync();


            var FavouriteDish = await data.Dishes.Include(x => x.Recipes).Include(x => x.selectedRecipe).SingleOrDefaultAsync(x => x.Id == model.FavouriteDishId);

            //set FavouriteDish in Menu 
            if (FavouriteDish != null && oldDish != model.FavouriteDishId)
            {


                if (menuItemForBirth == null)
                {
                    MenuItem mi = new MenuItem();
                    mi.DateOfDish = userInDb.DateOfBirth;
                    mi.RecipeId = FavouriteDish.selectedRecipeId;
                    await data.MenuItems.AddAsync(mi);
                    await data.SaveChangesAsync();
                }
                else
                {
                    menuItemForBirth.RecipeId = FavouriteDish.selectedRecipeId;
                    data.MenuItems.Update(menuItemForBirth);
                    await data.SaveChangesAsync();
                }
                if (menuItemForEmpl == null)
                {
                    MenuItem mi = new MenuItem();
                    mi.DateOfDish = userInDb.DateOfEmployment;
                    mi.RecipeId = FavouriteDish.selectedRecipeId;
                    await data.MenuItems.AddAsync(mi);
                    await data.SaveChangesAsync();
                }
                else
                {
                    menuItemForEmpl.RecipeId = FavouriteDish.selectedRecipeId;
                    data.MenuItems.Update(menuItemForEmpl);
                    await data.SaveChangesAsync();
                }


            }
            await data.SaveChangesAsync();

        }
       

        public async Task UpdateProfilePictureAsync(int userId, string profilePictureUrl)
        {
            var user = await data.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("Ne postoji u bazi");
            }

            user.ProfilePictureUrl = profilePictureUrl;

            data.SaveChanges();
        }

        public async Task UpdateProfilePictureBytesAsync(int userId, byte [] profilePictureUrl)
        {
            var user = await data.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("Ne postoji u bazi");
            }

            user.Image = profilePictureUrl;

            data.SaveChanges();
        }
    }
}
