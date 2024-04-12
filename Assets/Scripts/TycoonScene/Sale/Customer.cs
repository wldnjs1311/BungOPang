using UnityEngine;

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
