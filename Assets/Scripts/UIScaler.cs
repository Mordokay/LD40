using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour {


    Vector3 initialScale;

    private void Start()
    {
        initialScale = this.GetComponent<RectTransform>().localScale;
    }

    void Update () {
        float proportionRatio = ((1080.0f * 100 / Screen.height) / 100);

        this.transform.localScale = 
            new Vector3((Screen.width / 1920.0f) * initialScale.x * proportionRatio, (Screen.height / 1080.0f) * initialScale.y * proportionRatio, 1.0f);
    }
}
