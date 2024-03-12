using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Movement mov;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponentInParent<Movement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Walking", mov.isMoving);
    }
}
