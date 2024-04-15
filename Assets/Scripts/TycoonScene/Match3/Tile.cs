using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private IngredientType ingredient;

    public IngredientType Ingredient
    {
        get => ingredient;
        set
        {
            if (ingredient == value) return;

            ingredient = value;
            icon_.sprite = ingredient.sprite;
        }
    }

    public SpriteRenderer icon_;
    public Button button_;

    public Tile Left => x > 0 ? Board.Instance.Tiles[x - 1, y] : null;
    public Tile Top => y > 0 ? Board.Instance.Tiles[x, y - 1] : null;
    public Tile Right => x < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y] : null;
    public Tile Bottom => y < Board.Instance.Height - 1 ? Board.Instance.Tiles[x, y + 1] : null;

    public Tile[] NeighboursX => new[]
    {
        Left,
        Right,
    };

    public Tile[] NeighboursY => new[]
    {
        Top,
        Bottom,
    };

    private void Start() => button_.onClick.AddListener(call: () => Board.Instance.Select(tile: this));

    public List<Tile> GetConnectedTileX(List<Tile> exclude = null)
    {
        var result = new List<Tile> { this, };

        if (exclude == null)
        {
            exclude = new List<Tile> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        foreach (var neighbour in NeighboursX)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Ingredient != Ingredient) continue;

            result.AddRange(neighbour.GetConnectedTileX(exclude));
        }

        return result;
    }

    public List<Tile> GetConnectedTileY(List<Tile> exclude = null)
    {
        //세로로 이어져 있는 타일 반환
        var result = new List<Tile> { this, };

        if (exclude == null)
        {
            exclude = new List<Tile> { this, };
        }
        else
        {
            exclude.Add(item: this);
        }

        foreach (var neighbour in NeighboursY)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Ingredient != Ingredient) continue;

            result.AddRange(collection: neighbour.GetConnectedTileY(exclude));
        }

        return result;
    }
}
