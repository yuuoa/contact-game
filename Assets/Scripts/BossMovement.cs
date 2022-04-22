using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Animator animator;
    public float speed, lineOfSite, canAttack;
    private Transform player;
    private float attackDamage = 10f;
    private float attackSpeed = 1f;
    public Rigidbody2D rb;
    [SerializeField] private PolygonCollider2D col;
    [SerializeField] private GameObject DoorOpened, DoorClosed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DoorOpened.SetActive(false);
        DoorClosed.SetActive(true);
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
                    animator.SetBool("BossWalk", true);
                    characterScale.x = 1;
                }
                else if (transform.position.x < player.position.x)
                {
                    animator.SetBool("BossWalk", true);
                    characterScale.x = -1;
                }
                transform.localScale = characterScale;
            }
            else
            {
                animator.SetBool("BossWalk", false);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("BossWalk", true);
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
        animator.SetBool("BossAttack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("BossAttack", false);
    }

    public IEnumerator BossDeath()
    {
        speed = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        col.enabled = false;
        animator.SetBool("BossDeath", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        DoorClosed.SetActive(false);
        DoorOpened.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            StartCoroutine(BossDeath());
        }
    }
}
