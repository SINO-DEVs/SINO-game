using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour, IGameManager
{
    public static WinScreenManager Instance = null;

    private GameObject[] stillGrabbable;

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
        stillGrabbable = GameObject.FindGameObjectsWithTag("Collectable_0");

        // There's no gameObjects still grabbable
        if (stillGrabbable == null || stillGrabbable.Length == 0)
        {
            ScoreRepositoryManager.Instance.updateScoreIfGreater(SceneManager.GetActiveScene().name, ScoreManager.Instance.Score);
            Debug.Log(ScoreRepositoryManager.Instance.loadBestScoreFor(SceneManager.GetActiveScene().name));
            Levels.Instance.displayWinScreen();
        }
    }
}
