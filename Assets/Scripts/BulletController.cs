using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            Destroy(gameObject);
            // Debug.Log("I Hit the platform!!!");
        }
    }
    
    void Update () {
		
	}
}
