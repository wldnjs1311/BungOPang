using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "BungOPang/IgredientType")]
public sealed class IngredientType : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite sprite;
}

[CreateAssetMenu(menuName = "BungOPang/Customer")]
public sealed class Customer : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite sprite;
    public string description;
    public string[] comment;
    public int friendship;
}

[CreateAssetMenu(menuName = "BungOPang/Disruptor")]
public sealed class Disruptor : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite sprite;
}

[CreateAssetMenu(menuName = "BungOPang/BungOType")]
public sealed class BungOType : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite sprite;
    public string description;
    //public Skill skill;

}