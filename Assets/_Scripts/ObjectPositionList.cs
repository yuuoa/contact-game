using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionList : MonoBehaviour
{
    public GameObject Square;
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

    }
    void Update()
    {
        Square = GameObject.Find("Square");
        //Circle = GameObject.Find("Circle");
        Finish = GameObject.Find("Finish");
        Destroy(Square);
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
        Vector3 position = transform.position;
        position.y += 0.5f;
        position.x += 0.5f;
        transform.position = position;
        return tilePositionList[index];
    }

    //public void CheckAllPosition(){
    //    foreach(Vector3Int item in tilePositionList){
    //        Debug.Log(item);
    //    }

    //    Debug.Log("Last Pos = " + tilePositionList[tilePositionList.Count - 1]);
    //}

    //public void SpawnPlayer()
    //{
    //    Instantiate(Circle, tilePositionList[0], Quaternion.identity);
    //}

    public void SpawnEnemy()
    {
        for (int SpawnDistance = 25; SpawnDistance <= tilePositionList.Count; SpawnDistance+= 25)
        {
            Instantiate (Square, tilePositionList[SpawnDistance], Quaternion.identity);
        }
    }

    public void SpawnFinish()
    {
        Instantiate (Finish, tilePositionList[tilePositionList.Count - 1], Quaternion.identity);
    }
}
