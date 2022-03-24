using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float lineOfSite;
    private Transform player;

    private float attackDamage = 10f;
    private float attackSpeed = 1f;
    private float canAttack;
    private float health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if(distanceFromPlayer < lineOfSite && player != null)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                animator.SetFloat("EnemyMove", 1);

                Vector3 characterScale = transform.localScale;
                if (transform.position.x > player.position.x)
                {
                    characterScale.x = -1;
                }
                else if (transform.position.x < player.position.x)
                {
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                animator.SetBool("EnemyAttack", true);
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                PlayerPrefs.SetFloat("Health", health);
                canAttack = 0f;
            }
            else
            {
                animator.SetBool("EnemyAttack", false);
                canAttack += Time.deltaTime;
            }
        }
    }

    public IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(0.3f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            animator.SetBool("EnemyDeath", true);
            StartCoroutine(EnemyDeath());
            Destroy(gameObject);
        }
    }
}
