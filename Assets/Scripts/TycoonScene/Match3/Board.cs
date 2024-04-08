using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows_;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(dimension: 0);
    public int Height => Tiles.GetLength(dimension: 1);

    private readonly List<Tile> selection_ = new List<Tile>();

    private const float TweenDuration = 0.25f;

    private Tile selectedTile1_;
    private Tile selectedTile2_;

    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile[rows_.Max(selector: row => row.tiles_.Length), rows_.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = rows_[y].tiles_[x];

                tile.x = x;
                tile.y = y;

                tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

                Tiles[x, y] = tile;

            }
        }
    }
    public void Select(Tile tile)
    {
        if(!selection_.Contains(tile)) selection_.Add(tile);
        if (selection_.Count < 2) return;

        Debug.Log(message: $"Selected tiles at ({selection_[0].x}, {selection_[0].y}) and ({selection_[1].x}, {selection_[1].y})");

        selection_.Clear();
    }

    public async Task<> Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon_;
        var icon2 = tile2.icon_;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        //선택한 두 개 위치 바꾸기

        //만약 바꿨을 때 match 안되면 원래대로
        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
            .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play() //sequence
            .AsyncWaitForCompletion(); //task

        //부모 변경
        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon_ = icon2;
        tile2.icon_ = icon1;

        var title1Item = tile1.Item;
    }

}
