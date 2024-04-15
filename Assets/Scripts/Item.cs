using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "BungOPang/Igredient")]
public sealed class IngredientType : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite sprite;
}

[CreateAssetMenu(menuName = "BungOPang/CustomerType")]
public sealed class CustomerType : ScriptableObject
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