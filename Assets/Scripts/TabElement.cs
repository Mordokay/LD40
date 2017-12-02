using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabElement : MonoBehaviour {

    public int index;
    GameObject canvas;
    public GameObject openedWindow;
    public bool isSelected;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void Close()
    {
        canvas.GetComponent<TabManager>().CloseTab(index);
    }

    public void Select()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Debug.Log("selected tab : " + index);
        canvas.GetComponent<TabManager>().SelectTab(index);
    }
}
