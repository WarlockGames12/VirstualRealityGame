using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player")]
    public GameObject player;
    public Rigidbody2D rb;
    public LayerMask whatIsGround;
    private float speed = 3.5f;
    private float jump = 5000;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed += 0.0000015f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jump);
        }
        Debug.Log(speed);
    }
}
