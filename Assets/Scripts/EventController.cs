using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventController : MonoBehaviour {

    public GameObject[] TabWindows;
    public GameObject[] Popups;

    float timeSinceLastTrigger;
    GameObject canvas;
    GameObject popupCanvasHolder;

    public int probabilityTabMin;
    public int probabilityTabMax;
    public int probabilityPopupMin;
    public int probabilityPopupMax;

    public float intervalBetweenEvents;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        popupCanvasHolder = GameObject.FindGameObjectWithTag("PopupHolder");

        timeSinceLastTrigger = Time.timeSinceLevelLoad;
        TabWindows = Resources.LoadAll<GameObject>("TabWindows");
        Popups = Resources.LoadAll<GameObject>("Popups");
    }

    public void SpawnRandomTab()
    {
        if (TabWindows.Length > 0 && canvas.GetComponent<TabManager>().openedTabsCount < 7)
        {
            canvas.GetComponent<TabManager>().instantiateTab(TabWindows[Random.Range(0, TabWindows.Length)]);
        }

        timeSinceLastTrigger = Time.timeSinceLevelLoad;
    }

    public void SpawnRandomPopup()
    {
        if (Popups.Length > 0)
        {
            GameObject myPopup = Instantiate(Popups[Random.Range(0, Popups.Length)], popupCanvasHolder.transform);
            myPopup.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, myPopup.transform.position.z);
            myPopup.transform.Translate(new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(-2.0f, 2.0f), 0.0f));
            //myPopup.transform.Rotate(0.0f, 0.0f, Random.Range(-180.0f, 180.0f));
        }
        timeSinceLastTrigger = Time.timeSinceLevelLoad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.timeSinceLevelLoad - timeSinceLastTrigger > intervalBetweenEvents)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                int randomPercentage = Random.Range(0, 101);
                if(randomPercentage >= probabilityTabMin && randomPercentage < probabilityTabMax)
                {
                    SpawnRandomTab();
                }
                else if(randomPercentage >= probabilityPopupMin && randomPercentage <= probabilityPopupMax)
                {
                    SpawnRandomPopup();
                }
            }
        }
    }
}