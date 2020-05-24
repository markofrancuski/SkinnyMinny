using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{ 
    public string SceneName;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneSwitcher.Instance.LoadLevel(SceneName);
    }



}
