using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public PolygonCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            col.enabled = true;
            StartCoroutine(Timing());
        }
    }

    public IEnumerator Timing()
    {
        yield return new WaitForSeconds(0.2f);
        col.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collider.gameObject);
        }
    }
}
