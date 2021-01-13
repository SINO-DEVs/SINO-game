using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchManager : MonoBehaviour, IGameManager
{
    [SerializeField] private Camera firstP = null;
    [SerializeField] private Camera thirdP = null;

    public static CameraSwitchManager Instance = null;

    public bool ThirdPActive = false;

    void Awake()
    {
        Instance = this;
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    public void Startup()
    {
        _Status = ManagerStatus.INITIALIZING;
        checkCameraStatus();
        _Status = ManagerStatus.STARTED;
    }

    void Update()
    {
        if (!LifeManager.Instance.Alive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ThirdPActive = !ThirdPActive;
        }
        checkCameraStatus();

    }

    private void checkCameraStatus()
    {
        thirdP.enabled = ThirdPActive;
        thirdP.GetComponent<OrbitCamera>().enabled = ThirdPActive;

        firstP.enabled = !ThirdPActive;
        firstP.GetComponent<FirstPCamera>().enabled = !ThirdPActive;
    }

}
