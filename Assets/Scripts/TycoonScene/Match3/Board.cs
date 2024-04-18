using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows_;

    public Tile[,] Tiles { get; private set; }
    public Row Rows { get; private set; }

    public int Width => Tiles.GetLength(dimension: 0);
    public int Height => Tiles.GetLength(dimension: 1);

    private readonly List<Tile> selection_ = new List<Tile>();

    private const float TweenDuration = 0.125f;

    private Tile selectedTile1_;
    private Tile selectedTile2_;

    private void Awake() => Instance = this;

    public List<Tile> popTiles;
    private void Start()
    {
        Tiles = new Tile[rows_.Max(selector: row => row.tiles_.Length), rows_.Length];

        for (var y = 0; y < Height; y++)
        {
            float yPos = (6f / Height) * y - 4.15f ;
            rows_[y].transform.position = new Vector3(0, yPos, 0);
            for (var x = 0; x < Width; x++)
            {
                var tile = rows_[y].tiles_[x];

                tile.x = x;
                tile.y = y;

                tile.Ingredient = IngredientDatabase.Ingredients[Random.Range(0, IngredientDatabase.Ingredients.Length)];

                float xPos = (4.6f / Width) * x - 2f + transform.position.x;
                tile.transform.position = new Vector3(xPos, yPos, 0);

                Tiles[x, y] = tile;
            }
        }

        SetPop();
        Pop();
    }
    public async void Select(Tile tile)
    {
        if (selection_.Count() == 0) selection_.Add(tile);
        else if (selection_[0].NeighboursX.Contains(tile) || selection_[0].NeighboursY.Contains(tile))
            selection_.Add(tile);
        else selection_.Clear();

        if (selection_.Count < 2) return;

        await Swap(selection_[0], selection_[1]);

        if (CanPop(selection_[0], selection_[1]))
        {
            SetPop();
            Pop();
        }
        else
            await Swap(selection_[0], selection_[1]);

        selection_.Clear();
    }

    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon_;
        var icon2 = tile2.icon_;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        //선택한 두 개 위치 바꾸기
        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
            .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play() //실행
            .AsyncWaitForCompletion();  //한 task 끝날 때까지 기다리기

        //부모 변경
        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        //tile 아이콘 변경
        tile1.icon_ = icon2;
        tile2.icon_ = icon1;

        var tile1Item = tile1.Ingredient;

        //아이템 변경
        tile1.Ingredient = tile2.Ingredient;
        tile2.Ingredient = tile1Item;
    }

    private void Update()
    {

    }

    private bool CanPop(Tile a, Tile b)
    {
        if (a.GetConnectedTileX().Skip(1).Count() >= 2 || a.GetConnectedTileY().Skip(1).Count() >= 2
            || b.GetConnectedTileX().Skip(1).Count() >= 2 || b.GetConnectedTileY().Skip(1).Count() >= 2)
            return true;
        return false;
    }

    private void SetPop()
    {
        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
            {
                if (popTiles.Contains(Tiles[x, y])) continue;

                if (Tiles[x, y].GetConnectedTileX().Skip(1).Count() >= 2)
                    foreach (Tile tile in Tiles[x, y].GetConnectedTileX())
                        popTiles.Add(tile);

                if (Tiles[x, y].GetConnectedTileY().Skip(1).Count() >= 2)
                    foreach (Tile tile in Tiles[x, y].GetConnectedTileY())
                        popTiles.Add(tile);
            }
    }

    private async void Pop()
    {
        var deflateSequence = DOTween.Sequence();

        foreach (var tile in popTiles)
            deflateSequence.Join(tile.icon_.transform.DOScale(Vector3.zero, TweenDuration));

        await deflateSequence.Play()
            .AsyncWaitForCompletion();

        var inflateSequence = DOTween.Sequence();

        foreach (var tile in popTiles) //새로운 아이템 생성
        {
            tile.Ingredient = IngredientDatabase.Ingredients[Random.Range(0, IngredientDatabase.Ingredients.Length)];
            inflateSequence.Join(tile.icon_.transform.DOScale(new Vector3(0.1f, 0.1f, 1f), TweenDuration));

        }
        await inflateSequence.Play()
            .AsyncWaitForCompletion();

        popTiles.Clear();
        Debug.Log($"popTIles size :{popTiles.Count}");
    }
}

//최적화
//CanPop() 을 원소 하나씩 확인하는걸로 바꿔서 pop된 원소에 대해서만 검사

/*
 * 해결해야 할 문제
 * 1. pop한 후 새로 생성된 item들의 match는 터지지 않음
 * 2. 더 이상 맞출 수 없는 puzzle의 경우 rearrange 필요
 */