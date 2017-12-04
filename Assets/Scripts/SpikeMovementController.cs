using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovementController : MonoBehaviour {

    public float shift;
    float originalX;
    float originalY;
    public float spikeSpeed;
    GameObject canvas;

    public bool isVertical;
    public bool goingLeft;
    public bool goingUp;

    void Start () {
        originalX = this.transform.position.x;
        originalY = this.transform.position.y;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
	
	void Update () {
        if (canvas.GetComponent<TabManager>().homeTabSelected)
        {
            if (isVertical)
            {
                if (goingUp)
                {
                    this.transform.Translate(Vector3.up * Time.deltaTime * spikeSpeed);
                    //Debug.Log("Go Up");
                    if ((this.transform.localPosition.y - originalY) > shift)
                    {
                        goingUp = false;
                    }
                }
                else
                {
                    this.transform.Translate(-Vector3.up * Time.deltaTime * spikeSpeed);
                    //Debug.Log("Go Down");
                    if ((originalY - this.transform.position.y) > shift)
                    {
                        goingUp = true;
                    }
                }
            }
            else
            {
                if (goingLeft)
                {
                    this.transform.Translate(-Vector3.right * Time.deltaTime * spikeSpeed);
                    if ((originalX - this.transform.position.x) > shift)
                    {
                        goingLeft = false;
                    }
                }
                else
                {
                    this.transform.Translate(Vector3.right * Time.deltaTime * spikeSpeed);
                    if ((this.transform.position.x - originalX) > shift)
                    {
                        goingLeft = true;
                    }
                }
            }
        }
	}
}
