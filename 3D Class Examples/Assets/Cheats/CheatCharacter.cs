using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCharacter : MonoBehaviour
{
    public int health;

    public void TakeHit()
    {
        health--;

        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
