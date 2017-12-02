using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {

    public void ClosePopup()
    {
        Debug.Log("Closing plopup!!!");
        Destroy(transform.parent.gameObject);
    }
}
