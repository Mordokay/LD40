using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletController : MonoBehaviour {

    public Vector3 initialVelocity;

    float timeSinceCreated;
    bool initializedVelocity;
    private void Start()
    {
        timeSinceCreated = 0.0f;
    }

    void FixedUpdate () {
        timeSinceCreated += Time.deltaTime;
        if (timeSinceCreated > 0.1f && !initializedVelocity)
        {
            initialVelocity = this.GetComponent<Rigidbody2D>().velocity;
            initializedVelocity = true;
        }
        if (initializedVelocity) {
            //Keep the same velocity
            this.GetComponent<Rigidbody2D>().velocity = initialVelocity;
        }
    }
}
