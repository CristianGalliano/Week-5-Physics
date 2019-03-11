using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameController controller;
    private Rigidbody2D rb;
    public float jumpSpeed;
    public float moveSpeed;
    private bool jumping = false;
    private bool moving = false;
    private bool grounded = true;

    public Image healthBarIMG;
    private SpriteRenderer thisSR;
    public Sprite[] sprites;

    public float health = 100;
    public GameObject loseScreen;
    private int jumpCount = 2;

    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        thisSR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount == 0)
        {
            jumping = true;
        }
        changeHealthBar();
        death();
    }

    private void FixedUpdate()
    {
        if (controller.gameOver == false)
        {
            playerMovement();
        }
    }

    private void playerMovement()
    {
        switch (playerNumber)
        {
            case 1:
                if (jumping == false)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                        jumpCount -= 1;
                        grounded = false;
                    }
                }
                if (moving == false)
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        rb.AddForce(Vector2.left * moveSpeed);
                        thisSR.flipX = true;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        rb.AddForce(Vector2.right * moveSpeed);
                        thisSR.flipX = false;
                    }
                }
                if (grounded == false)
                {
                    thisSR.sprite = sprites[1];
                }
                else
                {
                    thisSR.sprite = sprites[0];
                }
                break;
            case 2:
                if (jumping == false)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                        jumpCount -= 1;
                        grounded = false;
                    }
                }
                if (moving == false)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        rb.AddForce(Vector2.left * moveSpeed);
                        thisSR.flipX = true;
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        rb.AddForce(Vector2.right * moveSpeed);
                        thisSR.flipX = false;
                    }
                }
                if (grounded == false)
                {
                    thisSR.sprite = sprites[1];
                }
                else
                {
                    thisSR.sprite = sprites[0];
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumping = false;
        jumpCount = 2;
        if (collision.tag == "Ground" || collision.tag == "Water")
        {
            grounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
        jumpCount = 2;
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Water" )
        {
            grounded = true;
        }
        if (collision.collider.tag == "Platform")
        {
            grounded = true;
            Rigidbody2D groundRB = collision.collider.GetComponent<Rigidbody2D>();
            groundRB.gravityScale = 1.0f;
            groundRB.constraints = RigidbodyConstraints2D.None;
        }
        if (collision.collider.tag == "Enemy")
        {
            health -= 10;
            rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }
        if (collision.collider.tag == "Player")
        {
            Rigidbody2D enemyRB = collision.collider.GetComponent<Rigidbody2D>();
            //Vector2 velocityDifference = enemyRB.velocity - rb.velocity;
            //PV.RPC("DealDamage", RpcTarget.All, (Mathf.Abs(velocityDifference.magnitude) * boatDamageMultiplier));
            rb.AddForce(new Vector2 (enemyRB.velocity.x,0), ForceMode2D.Impulse);
            Debug.Log("collided with player:" + collision.collider.name);
        }
        if (collision.collider.tag == "Spike")
        {
            health = 0;
        }
    }

    private void changeHealthBar()
    {
        healthBarIMG.rectTransform.sizeDelta = new Vector2(health * 10, healthBarIMG.rectTransform.sizeDelta.y);
    }

    private void death()
    {
        if (health <= 0)
        {
            //loseScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        health -= 0.25f;
    }
}
