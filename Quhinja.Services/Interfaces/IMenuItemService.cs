using Quhinja.Services.Implementations;
using Quhinja.Services.Models.InputModels.MenuItem;
using Quhinja.Services.Models.OutputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public  interface IMenuItemService
    {
        Task<MenuItemBasicOutputModel> GetMenuItemByIdAsync(int id);
        Task<ICollection<MenuItemBasicOutputModel>> GetMenuItemsAsync();
         Task<ICollection<TwoWeekDay>> GetTwoWeeks();

        Task<MenuItemBasicOutputModel> GetTodayMenuItem();

        Task<int> AddMissedDate(MissedLunchBasicInputModel input);

        Task AddMenuItem(MenuItemBasicInputModel input);

        Task RemoveMenuItemAsync(int menuItemId);

        Task removeMenuItemByDate(MenuItemBasicInputModel menuItemId);


    }
}
