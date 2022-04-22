using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    private Scene scene;
    public float Health, PlayerMoveSpeed;
    private float MaxHealth = 100f;
    public Text InfoHealth;
    public GameObject GameOverUI;
    public Rigidbody2D rb;
    public GameObject Sword;
    void Start()
    {
        PlayerMoveSpeed = GetComponent<PlayerMovement>().MoveSpeed;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            Health = MaxHealth;
        }
        else if (scene.name == "Level2" || scene.name == "Level3")
        {
            Health = PlayerPrefs.GetFloat("Health");
        }
        InfoHealth = GameObject.Find("UIHealth").GetComponent<Text>();
    }

    void Update()
    {
        InfoHealth.text = "Health : " + Health.ToString();
        PlayerPrefs.SetFloat("Health", Health);
    }
    
    public void UpdateHealth(float mod)
    {
        Health += mod;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        else if (Health <= 0f) 
        {
            Health = 0f;
            StartCoroutine(PlayerDeath());
            GameOverUI.SetActive(true);
        }
    }

    public IEnumerator PlayerDeath()
    {
        PlayerMoveSpeed = 0;
        Sword.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetBool("PlayerDeath", true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            scene = SceneManager.GetActiveScene();
            if (scene.name == "Level1" || scene.name == "Level2")
            {
                PlayerPrefs.SetFloat("Health", Health);
            }
        }
    }
}
