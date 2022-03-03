using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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

                Vector3 characterScale = transform.localScale;
                if (transform.position.x > player.position.x)
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
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                PlayerPrefs.SetFloat("Health", health);
                canAttack = 0f;
            }
            else
                canAttack += Time.deltaTime;
        }
    }
}
