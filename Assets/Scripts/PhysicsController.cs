using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{

    public float ShakeForceMultiplier;
    public Rigidbody2D Player;

    public void ShakeRigidBodies(Vector3 deviceAcceleration)
    {
        Player.AddForce(deviceAcceleration * ShakeForceMultiplier, ForceMode2D.Impulse);
    }
    
}
