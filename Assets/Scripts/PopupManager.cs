using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour {

    public GameObject[] Popups;
    GameObject popupCanvasHolder;
    public GameObject yesAnswerButton;
    public GameObject noAnswerButton;
    public bool isMultipleAnswerSwitch;
    public bool isIncrement;
    float timeSinceSwitch;

    public int counterDownClick;
    public Text counterText;

    private void Start()
    {
        if (isIncrement)
        {
            counterDownClick = Random.Range(10, 20);
            counterText.text = counterDownClick.ToString();
        }
        timeSinceSwitch = 0.0f;
        popupCanvasHolder = GameObject.FindGameObjectWithTag("PopupHolder");;
        Popups = Resources.LoadAll<GameObject>("Popups");
    }

    public void DecrementCounter()
    {
        Debug.Log("Decrement counter");
        counterDownClick -= 1;
        if(counterDownClick == 0)
        {
            ClosePopup();
        }
        else
        {
            this.GetComponent<AudioSource>().Play();
            counterText.text = counterDownClick.ToString();
        }
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
    }

    public void ClosePopup()
    {
        Debug.Log("Closing plopup!!!");
        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if (isMultipleAnswerSwitch)
        {
            timeSinceSwitch += Time.deltaTime;
            if(timeSinceSwitch > 0.6f)
            {
                Vector3 posYes = yesAnswerButton.transform.position;
                yesAnswerButton.transform.position = noAnswerButton.transform.position;
                noAnswerButton.transform.position = posYes;
                timeSinceSwitch = 0.0f;
            }
            
        }
    }
}
