namespace Quhinja.Data.Entiities
{
    public class Ingridient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

    }
}