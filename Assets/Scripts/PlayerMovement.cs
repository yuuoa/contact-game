using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float MoveSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 MoveDirection;
    public bool KeyAcquired;
    public GameObject KeyObject;

    // Start is called before the first frame update
    void Start()
    {
        KeyAcquired = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        Debug.Log(KeyAcquired);
    }

    void FixedUpdate()
    {
        Move();
    }

    public IEnumerator Timing()
    {
        MoveSpeed = 0;
        yield return new WaitForSeconds(0.2f);
        animator.SetFloat("PlayerMove", 0);
        MoveSpeed = 5;
    }

    void MoveInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(moveX, moveY).normalized;

        if (MoveSpeed != 0)
            animator.SetFloat("PlayerMove", 1);
        else 
            animator.SetFloat("PlayerMove", 0);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") < 0)
            characterScale.x = -1;
        if (Input.GetAxisRaw("Horizontal") > 0)
            characterScale.x = 1;
        transform.localScale = characterScale;

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Timing());
    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            KeyAcquired = true;
            DestroyImmediate (KeyObject, true);
        }
    }
}
