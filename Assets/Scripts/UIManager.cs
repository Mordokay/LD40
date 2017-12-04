using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject optionsPanel;
    public GameObject startPanel;
    public GameObject lavaLampPanel;
    public GameObject lavaLampPanel2;
    public GameObject lavaLampPanel3;

    public List<GameObject> starsUI;
    public Sprite starFilled;
    public List<bool> activatedStars;

    public Text muteButtonText;
    public GameObject Soundtrack;

    public void Start()
    {
        if (activatedStars.Count == 0)
        {
            activatedStars = new List<bool>();
            
            for (int i = 0; i < starsUI.Count; i++)
            {
                activatedStars.Add(false);
            }
            
        }
    }

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

    public void ActivateStar(int index)
    {
        starsUI[index].GetComponent<Image>().color = Color.yellow;
        activatedStars[index] = true;
    }

    public void ToggleMute()
    {
        if (Soundtrack.activeSelf)
        {
            PlayerPrefs.SetInt("Mute", 1);
            Soundtrack.SetActive(false);
            //AudioListener.volume = 1.0f;
            muteButtonText.text = "Unmute";
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
            Soundtrack.SetActive(true);
            //AudioListener.volume = 0.0f;
            muteButtonText.text = "Mute";
        }
    }

    public void ResetData()
    {
        PlayerPrefs.SetFloat("CheckpointX", 0.0f);
        PlayerPrefs.SetFloat("CheckpointY", 0.0f);
        PlayerPrefs.SetInt("Star1", 0);
        PlayerPrefs.SetInt("Star2", 0);
        PlayerPrefs.SetInt("Star3", 0);
        PlayerPrefs.SetInt("Star4", 0);
        PlayerPrefs.SetInt("Star5", 0);
        PlayerPrefs.SetInt("Star6", 0);
        PlayerPrefs.SetInt("Star7", 0);
        PlayerPrefs.SetInt("Star8", 0);
        PlayerPrefs.SetInt("Star9", 0);
    }

    void Update () {
		
	}
}
