using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator EnemyAnimator;
    public Animator animator;
    public PolygonCollider2D col;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Timing());
        }
    }

    public IEnumerator Timing()
    {
        animator.SetBool("PlayerAttack", true);
        col.enabled = true;
        yield return new WaitForSeconds(0.2f);
        col.enabled = false;
        animator.SetBool("PlayerAttack", false);
    }
}
