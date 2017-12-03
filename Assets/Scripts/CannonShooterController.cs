using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooterController : MonoBehaviour {

    public bool shootLeft;
    public float bulletForce;
    GameObject cannonBullet;

    float timeSinceLastBulletShoot;

	void Start () {
        cannonBullet = Resources.Load<GameObject>("CannonBullet");
        timeSinceLastBulletShoot = 0.0f;
	}
	
	void Update () {
        timeSinceLastBulletShoot += Time.deltaTime;
        if(timeSinceLastBulletShoot > 2.5f)
        {
            GameObject myCannonBullet = Instantiate(cannonBullet) as GameObject;
            myCannonBullet.transform.position = this.transform.position;
            myCannonBullet.transform.parent = this.transform;
            if (shootLeft)
            {
                myCannonBullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * bulletForce);
                timeSinceLastBulletShoot = 0.0f;
            }
            else
            {
                myCannonBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * bulletForce);
                timeSinceLastBulletShoot = 0.0f;
            }
        }
    }
}
