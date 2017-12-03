using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject optionsPanel;

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
