using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(0);
        }
        if(this.gameObject.tag.Equals("Weight") && collision.gameObject.tag.Equals("Platform"))
        {
            Destroy(gameObject);
        }
        if (this.gameObject.tag.Equals("CannonBullet") && collision.gameObject.tag.Equals("Platform"))
        {
            Destroy(gameObject);
        }
    }
}