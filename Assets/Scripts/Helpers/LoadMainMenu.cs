using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    private bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !isClicked)
        {
            Load();
        }
    }

    public void Load()
    {
        isClicked = false;
        SceneSwitcher.Instance.LoadMainMenu();
    }
}
