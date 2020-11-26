using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.MenuItem;
using Quhinja.Services.Models.OutputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class MenuItemService : IMenuItemService
    {
        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;


        public MenuItemService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<int> AddMissedDate(MissedLunchBasicInputModel input)
        {
            User userInDb = await data.Users.Include(x=>x.MissedDates).SingleOrDefaultAsync(x => x.Id == input.UserId);
            MenuItem menuItemInDb = await data.MenuItems.Include(x=>x.MissedUsers).SingleOrDefaultAsync(x => x.Id == input.MenuItemId);
            var missedLunch = mapper.Map<MissedLunch>(input);
            missedLunch.UserId = userInDb.Id;
            missedLunch.User = userInDb;
            missedLunch.MenuItem = menuItemInDb;
            await data.MissedLunches.AddAsync(missedLunch);
            data.SaveChanges();

            return missedLunch.Id;
        }

        public async Task<MenuItemBasicOutputModel> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await data.MenuItems.Include(x=>x.MissedUsers).Include(mi => mi.Recipe).ThenInclude(r => r.Ingridients).SingleOrDefaultAsync(d => d.Id == id);
            if (menuItem != null)
            {
                return mapper.Map<MenuItemBasicOutputModel>(menuItem);
            }
            throw new Exception("Not found in db");
        }

        public async Task<ICollection<MenuItemBasicOutputModel>> GetMenuItemsAsync()
        {
            return await data.MenuItems.Include(x=>x.MissedUsers).Include(mi => mi.Recipe).ThenInclude(r => r.Ingridients)
                          .Select(r => mapper.Map<MenuItemBasicOutputModel>(r))
                          .ToListAsync();
        }

        public async Task RemoveMenuItemAsync(int miId)
        {
            var menuItemInDb = await data.MenuItems
                        
                        .SingleOrDefaultAsync(ing => ing.Id == miId);

            if (menuItemInDb != null)//
            {
                data.MenuItems.Remove(menuItemInDb);
                data.SaveChanges();
            }

        }
    }
}
