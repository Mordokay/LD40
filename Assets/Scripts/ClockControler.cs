using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockControler : MonoBehaviour {

	void Update () {

        if (DateTime.Now.Hour > 12)
        {
            if(DateTime.Now.Minute < 10)
            {
                this.GetComponentInChildren<Text>().text = DateTime.Now.Hour - 12 + ":0" + DateTime.Now.Minute + " PM" +
                Environment.NewLine + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            }
            else
            {
                this.GetComponentInChildren<Text>().text = DateTime.Now.Hour - 12 + ":" + DateTime.Now.Minute + " PM" +
                Environment.NewLine + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            }
            
        }
        else
        {
            if (DateTime.Now.Minute < 10)
            {
                this.GetComponentInChildren<Text>().text = DateTime.Now.Hour + ":0" + DateTime.Now.Minute + " AM" +
                Environment.NewLine + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            }
            else
            {
                this.GetComponentInChildren<Text>().text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + " AM" +
                Environment.NewLine + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            }
        }
        
    }
}
