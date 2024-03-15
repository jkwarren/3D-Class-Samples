using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMoving;
    public Vector3 direction;
    public float movementSpeed;
    protected Rigidbody rb;
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
        MovementBehaviour();
        RotationBehaviour();
    }

    public virtual void MovementBehaviour()
    {
        rb.velocity = new Vector3(direction.x * movementSpeed, rb.velocity.y, direction.z * movementSpeed);
    }

    public virtual void RotationBehaviour()
    {
        //if (CameraManager.Instance.cameraMode == CameraManager.CameraMode.FirstPerson)
        //{
        //    Vector3 camDirection = Camera.main.transform.forward;
        //    Quaternion desiredRotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        //    transform.rotation = desiredRotation;
        //}
        //else
        {
            if (isMoving)
            {
                Quaternion desiredRotation = Quaternion.Euler(0, Vector3.SignedAngle(Vector3.forward, new Vector3(direction.x, 0, direction.z), Vector3.up), 0);
                transform.rotation = desiredRotation;
            }
        }
    }
}
