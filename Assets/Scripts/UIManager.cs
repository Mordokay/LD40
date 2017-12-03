using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject optionsPanel;
    public GameObject startPanel;
    public GameObject lavaLampPanel;
    public GameObject lavaLampPanel2;
    public GameObject lavaLampPanel3;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

	public void ToggleOptions()
    {
        if (optionsPanel.activeSelf)
        {
            optionsPanel.SetActive(false);
        }
        else
        {
            optionsPanel.SetActive(true);
        }
    }

    public void ToggleStartPanel ()
    {
        if (startPanel.activeSelf)
        {
            startPanel.SetActive(false);
        }
        else
        {
            startPanel.SetActive(true);
        }
    }

    public void ShowLavalampPanel(int number)
    {
        switch (number)
        {
            case 1:
                lavaLampPanel.SetActive(true);
                break;
            case 2:
                lavaLampPanel2.SetActive(true);
                break;
            case 3:
                lavaLampPanel3.SetActive(true);
                break;
        }
    }

    public void CloselavaLamps()
    {
        lavaLampPanel.SetActive(false);
        lavaLampPanel2.SetActive(false);
        lavaLampPanel3.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetCheckpointPos()
    {
        PlayerPrefs.SetFloat("CheckpointX", 0.0f);
        PlayerPrefs.SetFloat("CheckpointY", 0.0f);
    }

    void Update () {
		
	}
}
