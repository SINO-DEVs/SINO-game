using UnityEngine;
using System.Collections;

public class FPSManager : MonoBehaviour, IGameManager
{
	float deltaTime = 0.0f;

	public static FPSManager Instance = null;

	public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

	void Awake()
	{
		Instance = this;
	}

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.} fps", fps);
		GUI.Label(rect, text, style);
	}

    public void Startup()
    {
		_Status = ManagerStatus.INITIALIZING;
		_Status = ManagerStatus.STARTED;
	}
}