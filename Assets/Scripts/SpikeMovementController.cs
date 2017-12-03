using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovementController : MonoBehaviour {

    public float shift;
    public bool goingLeft;
    float originalX;
    public float spikeSpeed;
    GameObject canvas;

	void Start () {
        originalX = this.transform.position.x;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
	
	void Update () {
        if (canvas.GetComponent<TabManager>().homeTabSelected)
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
