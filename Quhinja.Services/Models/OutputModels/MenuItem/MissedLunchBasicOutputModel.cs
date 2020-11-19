using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.MenuItem
{
    class MissedLunchBasicOutputModel
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        
        //public MenuItemBasicOutputModel MenuItem { get; set; }

        public int UserId { get; set; }

    }
}
