using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player")]
    public GameObject player;
    public Rigidbody2D rb;
    //private float speed = 3.5f;
    private float jump = 350;
    float dirX;
    float dirY;
    float moveSpeed = 20f;


    [Header("Player Dies")]
    public GameObject GameOver;
    public GameObject Player;
    public SpikeScript InstantiatedGameObject;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOver.SetActive(false);
    }

    void Update()
    {
        //rb.velocity = new Vector2(speed += 0.0000015f, 0);
        dirX = Input.acceleration.x * moveSpeed;
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -10.2f, 7.5f), transform.position.y);

        //if there is no player available, do nothing
        if (player == null)
        {
            return;
        }
        //if there is no rigidbody, do nothing...
        if (rb == null)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            InstantiatedGameObject.Destroyed();
            GameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jump);
    }

    
}
