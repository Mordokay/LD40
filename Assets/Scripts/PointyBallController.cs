using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyBallController : MonoBehaviour {


    public bool hasLanded;
    public GameObject PointyBall;
    public float force;
    public float minIntervalBetweenJumps;
    public float maxIntervalBetweenJumps;

    float countdown;

    private void Start()
    {
        countdown = Random.Range(minIntervalBetweenJumps, maxIntervalBetweenJumps);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PointyBall"))
        {
            //Debug.Log("Collision!!!!");
            hasLanded = true;
            countdown = Random.Range(minIntervalBetweenJumps, maxIntervalBetweenJumps);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PointyBall"))
        {
            hasLanded = false;
        }
    }

    void Update () {
        if (hasLanded)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0.0f)
            {
                PointyBall.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);

            }
        }
	}
}
