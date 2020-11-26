using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.MenuItem
{
    public class MissedLunchBasicOutputModel
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        
        public MenuItemMissedLunchOutput MenuItem { get; set; }

        public int UserId { get; set; }

    }
}
