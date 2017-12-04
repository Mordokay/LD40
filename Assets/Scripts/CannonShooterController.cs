using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooterController : MonoBehaviour {

    public bool shootLeft;
    public float bulletForce;
    GameObject cannonBullet;
    GameObject cannonBulletDriver;

    public bool allowDriving;
    public float shootTimeInterval;

    float timeSinceLastBulletShoot;

	void Start () {
        cannonBullet = Resources.Load<GameObject>("CannonBullet");
        cannonBulletDriver = Resources.Load<GameObject>("CannonBulletDriver");
        timeSinceLastBulletShoot = 0.0f;
	}
	
	void Update () {
        timeSinceLastBulletShoot += Time.deltaTime;
        if(timeSinceLastBulletShoot > shootTimeInterval)
        {
            GameObject myCannonBullet;
            if (!allowDriving)
            {
                myCannonBullet = Instantiate(cannonBullet) as GameObject;
            }
            else
            {
                myCannonBullet = Instantiate(cannonBulletDriver) as GameObject;
            }
            myCannonBullet.transform.position = this.transform.position;
            myCannonBullet.transform.parent = this.transform;
            if (shootLeft)
            {
                myCannonBullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * bulletForce);
                timeSinceLastBulletShoot = 0.0f;
            }
            else
            {
                myCannonBullet.transform.localScale = 
                    new Vector3(myCannonBullet.transform.localScale.x * -1, 
                    myCannonBullet.transform.localScale.y, myCannonBullet.transform.localScale.z);
                myCannonBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * bulletForce);
                timeSinceLastBulletShoot = 0.0f;
            }
        }
    }
}
