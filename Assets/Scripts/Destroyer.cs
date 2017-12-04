using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    GameObject canvas;
    public int index;

    void Start () {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            canvas.GetComponent<UIManager>().ActivateStar(index);
            Destroy(gameObject);
        }
    }
}
