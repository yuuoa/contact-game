using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public GameObject enemyPrefabs;

    private List<Transform> summonedEnemy = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ObjectPositionList.Instance.GetPosition(2);
        
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, ObjectPositionList.Instance.GetListLength());
    }

    private void SummonEnemy()
    {
        
    }
}
