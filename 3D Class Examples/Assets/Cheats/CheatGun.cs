using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatGun : MonoBehaviour
{
    public float gunRange = 10;
    public float gunImpactForce = 10;
    public LayerMask gunMask;
    public GameObject gunDecal;
    public GameObject gunSFX;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        Instantiate(gunSFX, transform.position, Quaternion.identity);

        if (Physics.Raycast(ray, out RaycastHit hit, gunRange, gunMask))
        {
            if (hit.collider)
            {
                Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject decal = Instantiate(gunDecal, hit.point, hitRotation);
                decal.transform.parent = hit.transform;

                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition((hit.point - transform.position).normalized * gunImpactForce, hit.point);

                }

                CheatCharacter character = hit.collider.GetComponentInParent<CheatCharacter>();
                if (character != null)
                {
                    character.TakeHit();
                }
            }
        }
    }
}
