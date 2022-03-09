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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //rb.velocity = new Vector2(speed += 0.0000015f, 0);

    }

    public void Jump()
    {
        rb.AddForce(transform.up * jump);
    }
}
