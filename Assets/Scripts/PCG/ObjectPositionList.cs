using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionList : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Powerup;
    public GameObject Finish;
    public GameObject Key;
    private static ObjectPositionList _instance;
    [SerializeField] private TilemapVisualizer tilemapVisualizer;
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

    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        Powerup = GameObject.Find("Powerup");
        Finish = GameObject.Find("Finish");
        Key = GameObject.Find("Key");
        Destroy(Enemy);
        Destroy(Powerup);
        Destroy(Finish);
        Destroy(Key);
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

    public void SpawnEnemy()
    {
        for (int SpawnDistance = 25; SpawnDistance <= Mathf.Abs(tilePositionList.Count); SpawnDistance+= 25)
        {
            Instantiate (Enemy, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnPowerup()
    {
        for (int SpawnDistance = 80; SpawnDistance <= Mathf.Abs(tilePositionList.Count); SpawnDistance+= 80)
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
}
