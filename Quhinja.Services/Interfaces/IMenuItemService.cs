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

        Task<int> AddMissedDate(MissedLunchBasicInputModel input);
        Task RemoveMenuItemAsync(int menuItemId);

    }
}
