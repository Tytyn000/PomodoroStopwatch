using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SettingsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SettingsPanel.activeSelf == true)
            {
                SettingsPanel.SetActive(false);
            }
            else
            {
                SettingsPanel.SetActive(true);
            }
        }
    }
    public void QuitApplicationButton()
    {
        Application.Quit();
    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }
}
