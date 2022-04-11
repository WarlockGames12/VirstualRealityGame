using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SecondPlayerScript : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Rigidbody2D rb;
    //private float speed = 3.5f;
    private float jump = 10;
    private bool isJumping = false;
    float dirX;
    float dirY;
    float moveSpeed = 5f;

    float lowPassFilterFactor;
    Vector3 acceleratorDir;


    [Header("Player Dies")]
    public GameObject GameOver;
    public SpikeScript InstantiatedGameObject;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOver.SetActive(false);

        acceleratorDir = Input.acceleration;
    }

    void Update()
    {
        //rb.velocity = new Vector2(speed += 0.0000015f, 0);
        dirX = -Input.acceleration.x * moveSpeed;
        dirY = Input.acceleration.z;

        acceleratorDir.x = -Input.acceleration.z;
        acceleratorDir.z = Input.acceleration.x * moveSpeed;

        //if there is no rigidbody, do nothing...
        if (rb == null && player == null)
        {
            return;
        }

        transform.Translate(Input.acceleration.x, 0, 0);
        

        Vector3 acceleration = Input.acceleration;
        acceleratorDir = Vector3.Lerp(acceleratorDir, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - acceleratorDir;

        Debug.Log(deltaAcceleration.y);
        Debug.Log(acceleration);
        Debug.Log(acceleratorDir);



        if(acceleratorDir.sqrMagnitude > 1 && !isJumping)
        {
            Jump();
            if (rb.velocity.y == 0.2f)
            {
                isJumping = true;
            }
            Debug.Log("Shake event detected at time " + Time.time);
        }
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
        rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
