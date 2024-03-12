using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public enum CameraMode { TopDown, TopDownFollow, ThirdPerson}
    public CameraMode cameraMode;
    public GameObject topDownVCam;
    public GameObject topDownFollowVCam;
    public GameObject thirdPersonVCam;


    private void Start()
    {
        ChangeCameraMode(cameraMode);
    }

    private void OnValidate()
    {
        ChangeCameraMode(cameraMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCameraMode(CameraMode.TopDown);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCameraMode(CameraMode.TopDownFollow);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCameraMode(CameraMode.ThirdPerson);
        }

    }

    void ChangeCameraMode(CameraMode mode)
    {
        topDownVCam.SetActive(false);
        topDownFollowVCam.SetActive(false);
        thirdPersonVCam.SetActive(false);

        switch (mode)
        {
            case CameraMode.TopDown:
                topDownVCam.SetActive(true);
                break;
            case CameraMode.TopDownFollow:
                topDownFollowVCam.SetActive(true);
                break;
            case CameraMode.ThirdPerson:
                thirdPersonVCam.SetActive(true);
                break;
            default:
                break;
        }
    }
}
