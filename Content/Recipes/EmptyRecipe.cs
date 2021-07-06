using SteviesModRedux.Content.Configs;
using Terraria;

namespace SteviesModRedux.Content.Recipes
{
    public class EmptyRecipe : Recipe.ICondition
    {
        public bool RecipeAvailable(Recipe recipe) => ReduxConfig.Instance.EmptyTestRecipes;

        public string Description => "fart noises";
    }
}