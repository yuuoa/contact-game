using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public float speed, lineOfSite, canAttack;
    private Transform player;
    private float attackDamage = 10f;
    private float attackSpeed = 1f;
    public Rigidbody2D rb;
    [SerializeField] private GameObject Sword;
    [SerializeField] private PolygonCollider2D col;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if(distanceFromPlayer < lineOfSite && player != null)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

                Vector3 characterScale = transform.localScale;
                if (transform.position.x > player.position.x)
                {
                    animator.SetFloat("EnemyMove", 1);
                    characterScale.x = -1;
                }
                else if (transform.position.x < player.position.x)
                {
                    animator.SetFloat("EnemyMove", 1);
                    characterScale.x = 1;
                }
                transform.localScale = characterScale;
            }
            else
            {
                animator.SetFloat("EnemyMove", 0);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetFloat("EnemyMove", 0);
            if (attackSpeed <= canAttack)
            {
                StartCoroutine(Timing());
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    public IEnumerator Timing()
    {
        animator.SetBool("EnemyAttack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("EnemyAttack", false);
    }

    public IEnumerator EnemyDeath()
    {
        speed = 0;
        Sword.SetActive(false);
        col.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetBool("EnemyDeath", true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            StartCoroutine(EnemyDeath());
        }
    }
}
