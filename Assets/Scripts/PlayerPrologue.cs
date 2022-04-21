using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrologue : MonoBehaviour
{

    public float speed, lineOfSite;  
    private Transform check;

    void Start()
    {
        check = GameObject.FindGameObjectWithTag("check").transform;
    }

    void Update()
    {
        if (check != null)
        {
            float distanceFromcheck = Vector2.Distance(check.position, transform.position);
            if(distanceFromcheck < lineOfSite && check != null)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, check.position, speed * Time.deltaTime);

                Vector3 characterScale = transform.localScale;
                if (transform.position.x > check.position.x)
                {
                    characterScale.x = -1;
                }
                else
                {
                    characterScale.x = 1;
                }
                transform.localScale = characterScale;
            }
        }
    }
}
