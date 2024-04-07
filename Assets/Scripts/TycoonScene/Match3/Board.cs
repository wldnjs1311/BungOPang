using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows_;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(dimension: 0);
    public int Height => Tiles.GetLength(dimension: 1);

    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile[rows_.Max(selector: row => row.tiles_.Length), rows_.Length];

        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
                Tiles[x, y] = rows_[y].tiles_[x];

    }
}
