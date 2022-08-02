using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionList : MonoBehaviour
{
    public GameObject Skeleton, Skull, Powerup, Finish, Key;
    public GameObject Bones, Bones2, Stones, Torch;
    private static ObjectPositionList _instance;
    private TilemapVisualizer tilemapVisualizer;
    private List<Vector3Int> tilePositionList = new List<Vector3Int>();

    public static ObjectPositionList Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ObjectPositionList>();
            }
            return _instance;
        }
    }

    public void AddTilePosition(Vector3Int position)
    {
        tilePositionList.Add(position);
    }

    public int GetListLength()
    {
        return tilePositionList.Count;
    }

    public Vector3Int GetPosition(int index)
    {
        return tilePositionList[index];
    }

    public void CheckAllPosition()
    {
       foreach(Vector3Int item in tilePositionList)
       {
           Debug.Log(item);
       }
       Debug.Log("Last Pos = " + tilePositionList[tilePositionList.Count - 1]);
    }

    public void SpawnSkeleton()
    {   
        for (int SpawnDistance = 12; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 25)
        {
            Instantiate (Skeleton, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnSkull()
    {   
        for (int SpawnDistance = 25; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 25)
        {
            Instantiate (Skull, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnPowerup()
    {
        for (int SpawnDistance = 100; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 100)
        {
            Instantiate (Powerup, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnKey()
    {
        Instantiate (Key, tilePositionList[Mathf.Abs(tilePositionList.Count) / 2], Quaternion.identity);
    }

    public void SpawnFinish()
    {
        Instantiate (Finish, tilePositionList[Mathf.Abs(tilePositionList.Count) - 1], Quaternion.identity);
    }

    public void SpawnBones()
    {
        for (int SpawnDistance = 15; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 100)
        {
            Instantiate (Bones, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnBones2()
    {
        for (int SpawnDistance = 25; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 100)
        {
            Instantiate (Bones2, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnStones()
    {
        for (int SpawnDistance = 45; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 100)
        {
            Instantiate (Stones, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnTorch()
    {
        for (int SpawnDistance = 85; SpawnDistance < Mathf.Abs(tilePositionList.Count); SpawnDistance+= 50)
        {
            Instantiate (Torch, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }
}
