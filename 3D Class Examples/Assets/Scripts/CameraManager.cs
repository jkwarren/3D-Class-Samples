using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; } 
    public enum CameraMode { TopDown, TopDownFollow, ThirdPerson, FirstPerson}
    public CameraMode cameraMode;
    public GameObject topDownVCam;
    public GameObject topDownFollowVCam;
    public GameObject thirdPersonVCam;
    public GameObject firstPersonVCam;

    private void Awake()
    {
        Instance = this;
    }

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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeCameraMode(CameraMode.FirstPerson);
        }
    }

    void ChangeCameraMode(CameraMode mode)
    {
        cameraMode = mode;
        topDownVCam.SetActive(false);
        topDownFollowVCam.SetActive(false);
        thirdPersonVCam.SetActive(false);
        firstPersonVCam.SetActive(false);

        switch (cameraMode)
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
            case CameraMode.FirstPerson:
                firstPersonVCam.SetActive(true);
                break;
            default:
                break;
        }
    }
}
