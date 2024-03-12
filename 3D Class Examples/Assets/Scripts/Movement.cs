using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMoving;
    public Vector3 direction;
    public float movementSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        isMoving = direction != Vector3.zero;
    }

    private void FixedUpdate()
    {

         rb.velocity = new Vector3(direction.x * movementSpeed, rb.velocity.y, direction.z * movementSpeed);
        if (isMoving)
            Rotation();
    }

    public virtual void Rotation()
    {
        Quaternion desiredRotation = Quaternion.Euler(0, Vector3.SignedAngle(Vector3.forward, new Vector3(direction.x, 0, direction.z), Vector3.up), 0);
        transform.rotation = desiredRotation;
    }

}
