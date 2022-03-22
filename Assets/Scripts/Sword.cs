using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator EnemyAnimator;
    public PolygonCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
        EnemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>().animator;
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
            EnemyAnimator.SetBool("Death", true);
            Destroy(collider.gameObject);
        }
    }
}
