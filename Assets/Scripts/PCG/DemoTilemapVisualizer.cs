using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DemoTilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap, wallTilemap;
    [SerializeField] private TileBase floorTile, wallTop;
    public PCGStopwatch pcgstopwatch;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        pcgstopwatch.StopwatchStart();
        PaintTiles(floorPositions, floorTilemap, floorTile);
        StartCoroutine(PCGStopwatchDelay());
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    IEnumerator PCGStopwatchDelay()
    {
        yield return new WaitForSeconds(1f);
        pcgstopwatch.StopwatchStop();
    }


    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
