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
    private Vector2 movement;
    public float movementSpeed = 10;


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

        movement = new Vector2(Input.acceleration.x, Input.acceleration.y) * movementSpeed;
        rb.AddForce(movement);
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
