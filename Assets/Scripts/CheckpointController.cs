using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    bool isActivated;
    float timeSinceLastLock;
    UIManager uiManager;

    private void Start()
    {
        isActivated = false;
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (isActivated)
        {
            timeSinceLastLock += Time.deltaTime;
            if(timeSinceLastLock > 10.0f)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.GetComponent<CapsuleCollider2D>().enabled = true;
                isActivated = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetFloat("CheckpointX", this.transform.position.x);
            PlayerPrefs.SetFloat("CheckpointY", this.transform.position.y);
            if (uiManager.activatedStars[0]) { PlayerPrefs.SetInt("Star1", 1); }
            if (uiManager.activatedStars[1]) { PlayerPrefs.SetInt("Star2", 1); }
            if (uiManager.activatedStars[2]) { PlayerPrefs.SetInt("Star3", 1); }
            if (uiManager.activatedStars[3]) { PlayerPrefs.SetInt("Star4", 1); }
            if (uiManager.activatedStars[4]) { PlayerPrefs.SetInt("Star5", 1); }
            if (uiManager.activatedStars[5]) { PlayerPrefs.SetInt("Star6", 1); }
            if (uiManager.activatedStars[6]) { PlayerPrefs.SetInt("Star7", 1); }
            if (uiManager.activatedStars[7]) { PlayerPrefs.SetInt("Star8", 1); }
            if (uiManager.activatedStars[8]) { PlayerPrefs.SetInt("Star9", 1); }
            
            //Debug.Log("Saved new checkpoint!!!");
            this.GetComponent<SpriteRenderer>().color = Color.green;
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            isActivated = true;
            timeSinceLastLock = 0.0f;
        }
    }
}
