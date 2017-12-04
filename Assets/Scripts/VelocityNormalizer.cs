using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityNormalizer : MonoBehaviour {

    public bool ToX;
    public bool ToY;
    public float normalizeValueX;
    public float normalizeValueY;

	void Update () {
        Vector3 myVelocity = this.GetComponent<Rigidbody2D>().velocity;
        //Debug.Log("myVelocity.y: " + myVelocity.y + " normalizeValueY " + normalizeValueY);
        if (ToX && (myVelocity.x > normalizeValueX || myVelocity.x < -normalizeValueX))
        {
            this.GetComponent<Rigidbody2D>().velocity =
                new Vector3(Mathf.Clamp(myVelocity.x, -normalizeValueX, normalizeValueX), myVelocity.y, myVelocity.z);
        }
        if (ToY && (myVelocity.y > normalizeValueY || myVelocity.y < -normalizeValueY))
        {
            this.GetComponent<Rigidbody2D>().velocity =
                new Vector3(myVelocity.x, Mathf.Clamp(myVelocity.y, -normalizeValueY, normalizeValueY), myVelocity.z);
        }
	}
}
