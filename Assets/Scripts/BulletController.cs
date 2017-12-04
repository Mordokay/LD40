using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag.Equals("Breakable") && this.gameObject.tag.Equals("PlayerBullet")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Platform") ||
            collision.gameObject.tag.Equals("Spike") ||
            collision.gameObject.tag.Equals("Breakable"))
        {
            Destroy(gameObject);
        }
    }
}
 
