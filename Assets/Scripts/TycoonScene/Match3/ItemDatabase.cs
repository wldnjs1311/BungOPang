using System.Runtime.CompilerServices;
using UnityEngine;

public static class ItemDatabase
{
    public static Item[] Items { get; private set; }
    
    private static void Initialize() => Items = new Item[0];
}
