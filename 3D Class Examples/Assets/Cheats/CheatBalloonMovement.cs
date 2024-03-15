using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatBalloonMovement : Movement
{
    public override void MovementBehaviour()
    {
        rb.AddForce(new Vector3(direction.x * movementSpeed, rb.velocity.y, direction.z * movementSpeed), ForceMode.VelocityChange);
    }
}
