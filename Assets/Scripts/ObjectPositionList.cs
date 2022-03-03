using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionList : MonoBehaviour
{
    public GameObject Square;
    public GameObject Flask;
    //public GameObject Circle;
    public GameObject Finish;
    private static ObjectPositionList _instance;

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
    
    [SerializeField] private TilemapVisualizer tilemapVisualizer;

    private List<Vector3Int> tilePositionList = new List<Vector3Int>();

    // Update is called once per frame

    void Start()
    {
        // CheckAllPosition();
    }
    void Update()
    {
        Square = GameObject.Find("Square");
        Flask = GameObject.Find("Flask");
        //Circle = GameObject.Find("Circle");
        Finish = GameObject.Find("Finish");
        Destroy(Square);
        Destroy(Flask);
        //Destroy(Circle);
        Destroy(Finish);
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

    public void CheckAllPosition(){
       foreach(Vector3Int item in tilePositionList){
           Debug.Log(item);
       }

       Debug.Log("Last Pos = " + tilePositionList[tilePositionList.Count - 1]);
    }

    public void SpawnEnemy()
    {
        for (int SpawnDistance = 25; SpawnDistance <= Mathf.Abs(tilePositionList.Count); SpawnDistance+= 25)
        {
            Instantiate (Square, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

        public void SpawnFlask()
    {
        for (int SpawnDistance = 55; SpawnDistance <= Mathf.Abs(tilePositionList.Count); SpawnDistance+= 55)
        {
            Instantiate (Flask, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnFinish()
    {
        Instantiate (Finish, tilePositionList[Mathf.Abs(tilePositionList.Count) - 1], Quaternion.identity);
    }
}
