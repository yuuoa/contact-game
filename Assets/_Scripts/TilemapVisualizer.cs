using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase floorTile, wallTop;
    public GameObject Square;
    //public GameObject Circle;
    public GameObject Finish;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }

        Square = GameObject.Find("Square");
        //Circle = GameObject.Find("Circle");
        Finish = GameObject.Find("Finish");

        //ObjectPositionList.CheckAllPosition();
        //ObjectPositionList.Instance.SpawnPlayer();
        ObjectPositionList.Instance.SpawnEnemy();
        ObjectPositionList.Instance.SpawnFinish();
        ObjectPositionList.Instance.SpawnFlask();
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
        ObjectPositionList.Instance.AddTilePosition(tilePosition);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
