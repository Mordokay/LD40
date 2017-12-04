using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabElement : MonoBehaviour {

    public int index;
    GameObject canvas;
    public GameObject openedWindow;
    public bool isSelected;

    public GameObject backroundBrowser;
    public float timeSinceLastFlicker;
    public bool isFlickeringBackround;

    public bool hasConfirmationPanel;
    public GameObject confirmationPanel;

    /*
    GameObject backroundBrowser; = GameObject.FindGameObjectWithTag("BrowserBackround");

    void Start()
    {
        timeSinceLastFlicker = 0.0f;
        backroundBrowser = GameObject.FindGameObjectWithTag("BrowserBackround");
    }
    */
    void Update()
    {
        if (isFlickeringBackround)
        {
            timeSinceLastFlicker += Time.deltaTime;
            if (timeSinceLastFlicker > 1.0f)
            {
                backroundBrowser.GetComponent<Image>().color =
                    new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            }

        }
    }

    public void confirmSure(int response)
    {
        confirmationPanel.SetActive(false);
        if (response == 1)
        {
            canvas.GetComponent<TabManager>().CloseTab(index);
        }
    }

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void Close()
    {
        if (hasConfirmationPanel)
        {
            confirmationPanel.SetActive(true);
        }
    }

    public void Select()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Debug.Log("selected tab : " + index);
        canvas.GetComponent<TabManager>().SelectTab(index);
    }
}
