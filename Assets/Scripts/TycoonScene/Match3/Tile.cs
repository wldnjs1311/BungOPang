using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item item_;

    public Item Item
    {
        get => item_;
        set
        {
            if (item_ == value) return;

            Item = value;
            icon_.sprite = item_.sprite_;
        }
    }

    public Image icon_;
    public Button button_;
}
