using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetFloat("CheckpointX", this.transform.position.x);
            PlayerPrefs.SetFloat("CheckpointY", this.transform.position.y);
            //Debug.Log("Saved new checkpoint!!!");
            this.GetComponent<SpriteRenderer>().color = Color.green;
            this.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
