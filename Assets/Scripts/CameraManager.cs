using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;


public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> cmCameras = new List<CinemachineVirtualCamera>();
    public CinemachineVirtualCamera currentCamera;
    public static CameraManager cameraManagerInstance;

    private void Awake()
    {
        cameraManagerInstance = this;
    }

    public void ActivateCamera(int cameraIndex)
    {
        foreach (var camera in cmCameras)
        {
            camera.gameObject.SetActive(false);
        }
        cmCameras[cameraIndex].gameObject.SetActive(true);
        currentCamera = cmCameras[cameraIndex];
    }

}
