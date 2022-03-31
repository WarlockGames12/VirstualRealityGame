using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampositionStuff : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPos;
    public Vector3 camPos;

    public float maxDistance = 5;

    void Start()
    {
        camPos.y = playerPos.y + 8.6f;
        camPos.z = playerPos.z - 1;
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;
        camPos.x = gameObject.transform.position.x;

        if (camPos.x <= playerPos.x - maxDistance)
        {
            camPos.x = playerPos.x - maxDistance;
        }

        if (camPos.x >= playerPos.x + maxDistance)
        {
            camPos.x = playerPos.x + maxDistance;
        }

        gameObject.transform.position = camPos;

        /*  Get player position.X
            Get Camera position.X 
            if distance between both <= 5 then move camera to player position -5
            if distance between both >= -5 then move camera to player position +5
        */


    }
}
