using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SecondPlayerScript : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Rigidbody2D rb;
    //private float speed = 3.5f;
    private float jump = 350;
    float dirX;
    float dirY;
    Vector3 New;
    float moveSpeed = 20f;


    [Header("Player Dies")]
    public GameObject GameOver;
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
        dirY = Input.acceleration.y;

        //if there is no rigidbody, do nothing...
        if (rb == null && player == null)
        {
            return;
        }

        transform.Translate(Input.acceleration.x, -Input.acceleration.y, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, 0f);
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
