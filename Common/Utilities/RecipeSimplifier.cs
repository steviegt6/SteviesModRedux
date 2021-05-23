using Terraria;

namespace SteviesModRedux.Common.Utilities
{
    public static class RecipeSimplifier
    {
        public static Recipe AddIngredients(this Recipe recipe, params (int, int)[] items)
        {
            foreach ((int item, int amount) in items)
                recipe.AddIngredient(item, amount);

            return recipe;
        }

        public static Recipe AddTiles(this Recipe recipe, params int[] tiles)
        {
            foreach (int tile in tiles)
                recipe.AddTile(tile);

            return recipe;
        }
    }
}