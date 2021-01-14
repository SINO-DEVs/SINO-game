using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour, IGameManager
{
    public static ExitManager Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    // Start is called before the first frame update
    public void Startup()
    {
        _Status = ManagerStatus.INITIALIZING;
        //
        _Status = ManagerStatus.STARTED;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Levels.Instance.displayMenu();
        }
    }
}
