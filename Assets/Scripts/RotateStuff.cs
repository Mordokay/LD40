using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStuff : MonoBehaviour {

    public List<GameObject> thingsToRotate;
    public float speedOfRotation;

	void Update () {
		foreach(GameObject obj in thingsToRotate)
        {
            obj.transform.Rotate(Vector3.forward * Time.deltaTime * speedOfRotation);
        }
	}
}
