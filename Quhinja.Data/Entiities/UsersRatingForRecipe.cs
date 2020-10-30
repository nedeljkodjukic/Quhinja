namespace Quhinja.Data.Entiities
{
    using global::Quhinja.Data.Entities;

    namespace Quhinja.Data.Entiities
    {
        public class UsersRatingForRecipe
        {

            public int Id { get; set; }
            public int UserId { get; set; }

            public User User { get; set; }

            public int RecipeId { get; set; }


            public Recipe Recipe { get; set; }

            public int Rating { get; set; }
        }
    }
}

