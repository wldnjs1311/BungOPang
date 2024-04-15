using UnityEngine;

public static class IngredientDatabase
{
    public static IngredientType[] Ingredients { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]private static void Initialize() => Ingredients = Resources.LoadAll<IngredientType>(path: "Ingredients/");
    
}
