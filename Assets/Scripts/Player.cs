using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;
    private float moveX, moveY;
    public float MoveSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 MoveDirection;
    [SerializeField] GameObject Sword;
    [SerializeField] PolygonCollider2D col;
    
    private int LevelAdder = 1;
    
    void Awake()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().UpdateLevel(+LevelAdder);
    }

    void Update()
    {
        MoveInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    public IEnumerator Timing()
    {
        animator.SetBool("PlayerAttack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("PlayerAttack", false);
    }

    void MoveInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(moveX, moveY).normalized;
        Vector3 characterScale = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetFloat("PlayerMove", 1);
            characterScale.x = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetFloat("PlayerMove", 1);
            characterScale.x = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetFloat("PlayerMove", 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetFloat("PlayerMove", 0);
        }
        transform.localScale = characterScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Timing());
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    public void PlayerDeath()
    {
        StartCoroutine(PlayerDeathScene());
    }

    public IEnumerator PlayerDeathScene()
    {
        FindObjectOfType<SFXManager>().Play("PlayerDeath");
        MoveSpeed = 0;
        Sword.SetActive(false);
        col.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetBool("PlayerDeath", true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
