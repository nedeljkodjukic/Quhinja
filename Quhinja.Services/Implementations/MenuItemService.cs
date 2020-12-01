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

    public class TwoWeekDay
    {
        public DateTime day { get; set; }
        public MenuItemBasicOutputModel menuItem { get; set; }
    }
    public class MenuItemService : IMenuItemService
    {
        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;


        public MenuItemService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

       public async  Task<MenuItemBasicOutputModel> GetTodayMenuItem()
        {
            var menuItem = await data.MenuItems
                .Include(mi => mi.Recipe).ThenInclude(r=>r.Dish)
                .Include(mi=>mi.Recipe)
                    .ThenInclude(mi => mi.Ingridients).ThenInclude(ing => ing.Ingridient)
               .Where(d => d.DateOfDish.Day == DateTime.Now.Day
               && d.DateOfDish.Year == DateTime.Now.Year && d.DateOfDish.Month == DateTime.Now.Month).FirstOrDefaultAsync();
            return mapper.Map<MenuItemBasicOutputModel>(menuItem);
        }
        public async Task<ICollection<TwoWeekDay>> GetTwoWeeks()
        {
            List<TwoWeekDay> array = new List<TwoWeekDay>();
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            DateTime deadLine = currentWeekStartDate.AddDays(14);
          while(currentWeekStartDate.Date < deadLine.Date)
            {
                var menuItem = await data.MenuItems.Include(r=>r.Recipe).ThenInclude(x=>x.Dish).Where(x => x.DateOfDish.Date == currentWeekStartDate.Date).FirstOrDefaultAsync();

                if (!(currentWeekStartDate.DayOfWeek == DayOfWeek.Saturday || currentWeekStartDate.DayOfWeek == DayOfWeek.Sunday))
                {



                    if (menuItem != null)
                    {
                        array.Add(new TwoWeekDay
                        {
                            day = currentWeekStartDate,
                            menuItem = mapper.Map<MenuItemBasicOutputModel>(menuItem)
                        });


                    }
                    else
                    {
                        array.Add(new TwoWeekDay
                        {
                            day = currentWeekStartDate,
                            menuItem = null
                        });
                    }
                }
                currentWeekStartDate = currentWeekStartDate.AddDays(1);
            
            }
            return array;   
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
            var menuItemInDb = await data.MenuItems.Include(n=>n.MissedUsers)
                        
                        .SingleOrDefaultAsync(ing => ing.Id == miId);

            var missedUserss = await data.MissedLunches.Include(mu => mu.MenuItem).Where(m => m.MenuItemId == miId).ToListAsync();
            if (missedUserss.Count>0)
            foreach(MissedLunch date in missedUserss)
            {
                data.MissedLunches.Remove(date);
                await data.SaveChangesAsync();
            }

            if (menuItemInDb != null)//
            {
                data.MenuItems.Remove(menuItemInDb);
             await   data.SaveChangesAsync();
            }

        }

        public async Task removeMenuItemByDate(MenuItemBasicInputModel dateTime)
        {
            DateTime dTime = dateTime.DateOfDish;
            
            var menuItemInDb = await data.MenuItems.Include(n => n.MissedUsers).Where(n=>n.DateOfDish.Date==dTime.Date)
                
                        .SingleOrDefaultAsync();

            var missedUserss = await data.MissedLunches.Include(mu => mu.MenuItem).Where(m => m.MenuItemId == menuItemInDb.Id).ToListAsync();
            if (missedUserss.Count > 0)
                foreach (MissedLunch date in missedUserss)
                {
                    data.MissedLunches.Remove(date);
                    await data.SaveChangesAsync();
                }

            if (menuItemInDb != null)//
            {
                data.MenuItems.Remove(menuItemInDb);
                await data.SaveChangesAsync();
            }

        }

        public async Task AddMenuItem(MenuItemBasicInputModel input)
        {
            var menuItemFroDb = await data.MenuItems.Where(x => x.DateOfDish.Date == input.DateOfDish.Date).SingleOrDefaultAsync();
            if (menuItemFroDb == null)
            {
                MenuItem mi = mapper.Map<MenuItem>(input);
                await data.MenuItems.AddAsync(mi);
                await data.SaveChangesAsync();
            }
            else
            {
                menuItemFroDb.RecipeId = input.RecipeId;
                data.MenuItems.Update(menuItemFroDb);
                await data.SaveChangesAsync();
            }


        }
    }
}
