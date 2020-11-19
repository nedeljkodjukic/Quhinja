using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.MenuItem
{
    public class MissedLunchBasicInputModel
    { 
        public int Id { get; set; }

        public int MenuItemId { get; set; }

        public int UserId { get; set; }
    }
}
