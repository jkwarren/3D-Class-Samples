using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatBalloon : CheatCharacter
{

    Transform target;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        BalloonBehaviour();
    }


    private void BalloonBehaviour()
    {
        Vector3 walkDirection = (target.position - transform.position).normalized;
        movement.direction = walkDirection;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            CheatCharacter character = collision.gameObject.GetComponent<CheatCharacter>();
            if (character != null)
            {
                character.TakeHit();
                Death();
            }
        }
    }
}
