using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(1);
        }
        if(this.gameObject.tag.Equals("Weight") && (collision.gameObject.tag.Equals("Platform") || 
            collision.gameObject.tag.Equals("Breakable") || 
            collision.gameObject.tag.Equals("PointyBallBox")))
        {
            Destroy(gameObject , 2.0f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (this.gameObject.tag.Equals("CannonBullet") && collision.gameObject.tag.Equals("Platform"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Cloud") && gameObject.tag.Equals("CloudKiller"))
        {
            Destroy(collision.gameObject);
        }
    }
}