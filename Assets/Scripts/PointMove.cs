using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{
    public float downSpeed = 4f;


    void Update()
    {
        transform.Translate(Vector2.down * downSpeed * Time.deltaTime);
    }
}
