using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour {

    public GameObject HomeTab;
    public List<GameObject> tabs;
    public GameObject WindowHolder;
    public int openedTabsCount;
    public bool homeTabSelected = true;
    GameObject popupCanvasHolder;

    void Start () {
        popupCanvasHolder = GameObject.FindGameObjectWithTag("PopupHolder");
        SelectTab(-1);
        disableAllWindows();
    }

    public void instantiateTab(GameObject windowObject)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        openedTabsCount += 1;
        tabs[openedTabsCount].SetActive(true);
        GameObject myWindow = Instantiate(windowObject, WindowHolder.transform);
        tabs[openedTabsCount].GetComponent<TabElement>().openedWindow = myWindow;
        SelectTab(openedTabsCount - 1);
    }

    public void CloseTab(int index)
    {
        //Destroys window
        Destroy(WindowHolder.transform.GetChild(index).gameObject);

        //Shifts all tabs to the left and removes the last one
        for (int i = index + 1; i < tabs.Count - 1; i++)
        {
            tabs[i].GetComponent<TabElement>().openedWindow = 
                tabs[i + 1].GetComponent<TabElement>().openedWindow;
        }
        tabs[tabs.Count - 1].GetComponent<TabElement>().openedWindow = null;
        tabs[openedTabsCount].SetActive(false);
        openedTabsCount -= 1;

        //Debug.Log("Closing Tab " + index);

        //If I close the selected tab and its not the last one


        if (!HomeTab.GetComponent<TabElement>().isSelected)
        {
            //Debug.Log("index " + index + " openedTabsCount: " + openedTabsCount);
            if (index == openedTabsCount)
            {
                //Debug.Log("banana1234");
                tabs[index].GetComponent<TabElement>().isSelected = true;
                tabs[index].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                tabs[index].GetComponent<TabElement>().isSelected = false;

                if (index != -1 && index != 0)
                {
                    WindowHolder.transform.GetChild(index - 1).gameObject.SetActive(true);
                }
                else if (openedTabsCount == 0)
                {
                    SelectTab(-1);
                    homeTabSelected = true;
                }
            }
            else if (index < openedTabsCount)
            {
                //tabs[index].GetComponent<TabElement>().isSelected = true;
                //tabs[index].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                //tabs[index].GetComponent<TabElement>().isSelected = false;


                SelectTab(index);

                foreach (GameObject tab in tabs)
                {
                    if (tab.GetComponent<TabElement>().isSelected && tab.GetComponent<TabElement>().index != -1)
                    {
                        tab.GetComponent<TabElement>().openedWindow.SetActive(true);
                    }
                }
            }
            else if (HomeTab.GetComponent<TabElement>().isSelected)
            {
                disableAllWindows();
                SelectTab(-1);
            }
        }
    }

    public void SelectTab(int index)
    {
        disableAllWindows();
        //Check if it is the home tab
        if (index == -1)
        {
            //Debug.Log("Selecting Home Tab");
            foreach (GameObject tab in tabs)
            {
                tab.transform.GetChild(0).GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
                tab.GetComponent<TabElement>().isSelected = false;
            }
            HomeTab.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            HomeTab.GetComponent<TabElement>().isSelected = true;
            homeTabSelected = true;
            popupCanvasHolder.SetActive(true);
        }
        else
        {
            popupCanvasHolder.SetActive(false);
            homeTabSelected = false;
            //Debug.Log("Selecting Tab " + index);
            WindowHolder.transform.GetChild(index).gameObject.SetActive(true);
            foreach (GameObject tab in tabs)
            {
                tab.transform.GetChild(0).GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
                tab.GetComponent<TabElement>().isSelected = false;
            }
            tabs[index + 1].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            tabs[index + 1].GetComponent<TabElement>().isSelected = true;
        }
    }

    public void disableAllWindows()
    {
        foreach(Transform window in WindowHolder.transform)
        {
            window.gameObject.SetActive(false);
        }
    }
}
