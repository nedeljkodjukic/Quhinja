namespace Quhinja.Data.Entiities
{
    public  class IngridientInRecipe
    {

        public int Id { get; set; }

        public int IngridientId { get; set; }
        
        public Ingridient Ingridient { get; set; }

        public int RecipeId { get; set; }
      
        public Recipe Recipe { get; set; }

        public int  Quantity { get; set; }

        public string Unit { get; set; }

    }
}
