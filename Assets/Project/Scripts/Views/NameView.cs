using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NameView : MonoBehaviour
{
    public Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        Messenger<string>.AddListener(SettingsEvent.NAME_CHANGED, OnNameChanged);
        OnNameChanged(GameManager.Instance.PlayerName);
    }

    private void OnNameChanged(string name)
    {
        nameText.text = name;
    }

    void OnDestroy()
    {
        Messenger<string>.RemoveListener(SettingsEvent.NAME_CHANGED, OnNameChanged);
    }
}
