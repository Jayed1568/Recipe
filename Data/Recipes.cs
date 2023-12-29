using RecipeApplication.Models;

namespace RecipeApplication.Data
{
    public class Recipes
    {
    readonly List<Recipe> recipes = new(){
        new()
        {
            Name = "Sweet Halva",
            Ingredients = @"Wheat flour 2 cups
            Sugar 1 cup
            Butter 1/2 cups
            Water 1 cup
            Rosewater 4 tablespoons
            Saffron 1/4 tsp
            Cardamom powder 1/4 tsp",
            Instructions = @"Keep a pan on a moderate flame and add 2 cups of flour to it.
            Stir and sauté the flour and be careful not to burn it.
            Your flour should be golden in color in order for you to move to the next step.
            Now it’s time for you to add 1/2 cup of butter or oil to your flour.
            Pour 1/4 teaspoon of ground saffron on 2 ice cubes. Let the ice cubes melt. Our bloomed saffron is ready.
            Pour a cup of water into a small pan on heat.
            Then add 1/4 teaspoon cardamom powder, 1 cup of sugar, 4 tablespoons of rosewater, and bloomed saffron to the water. Mix them well and make sure you do not over-add rosewater or cardamon. Halva syrup is ready!
            Add syrup to the flour and mix them on low heat again. Stir it frequently for some minutes. Be careful do not burn it!
            Your halva is ready. Take a plate and spread it on the plate. You can add designs to your halva and decorate it with almonds, coconut, or even pistachios."
        },

        
    };

        public IEnumerable<Recipe> List()
        => recipes;

        public Recipe FindById(Guid recipeId)
        => recipes.Single(recipe => recipe.ID == recipeId);

        public void Add(Recipe recipe)
        => recipes.Add(recipe);

        public void Update(Recipe newRecipe)
        {
            var oldRecipe = recipes.Single(r => r.ID == newRecipe.ID);

            oldRecipe.Name = newRecipe.Name;
            oldRecipe.Ingredients = newRecipe.Ingredients;
            oldRecipe.Instructions = newRecipe.Instructions;
        }

        public void Remove(Guid recipeId)
        => recipes.Remove(FindById(recipeId));
    }

}
