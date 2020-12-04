using Quhinja.Data.Entities;

namespace Quhinja.Data.Entiities
{
    public class MissedLunch
    {
      
            public int Id { get; set; }

            public int UserId { get; set; }

            public User User { get; set; }

            public int MenuItemId { get; set; }

            public MenuItem MenuItem { get; set; }
     }
}
