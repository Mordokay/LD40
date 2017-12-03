using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public LayerMask mouseShootLayerMask;
    public float bulletForce;
    public float bulletTimeOfLife;
    public float jumpForce;
    public bool canJump;
    public float horizontalVelocity;
    float timeSinceLastJump;

    GameObject canvas;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CheckpointX"))
        {
            PlayerPrefs.SetFloat("CheckpointX", 0.0f);
        }
        if (!PlayerPrefs.HasKey("CheckpointY"))
        {
            PlayerPrefs.SetFloat("CheckpointY", 0.0f);
        }

        this.transform.position = 
            new Vector3(PlayerPrefs.GetFloat("CheckpointX"), PlayerPrefs.GetFloat("CheckpointY"), 0.0f);

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canJump = false;
        timeSinceLastJump = 0.0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            canJump = true;
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            canJump = false;
        }
    }

    void Update()
    {
        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > 15.0f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(this.GetComponent<Rigidbody2D>().velocity.x,
                Mathf.Clamp(this.GetComponent<Rigidbody2D>().velocity.y, -15.0f, 15.0f), 0.0f);
        }

        if (canvas.GetComponent<TabManager>().homeTabSelected)
        {
            timeSinceLastJump += Time.deltaTime;

            //Debug.Log("Player velocity: " + this.GetComponent<Rigidbody2D>().velocity);
            Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10.0f);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (canJump && timeSinceLastJump > 0.3f)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
                    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
                    
                    timeSinceLastJump = 0.0f;
                }
            }

            float velocityX = 0;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                velocityX -= horizontalVelocity;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                velocityX += horizontalVelocity;
            }

            this.GetComponent<Rigidbody2D>().velocity = new Vector3(velocityX, this.GetComponent<Rigidbody2D>().velocity.y, 0.0f);

            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y),
                    Vector3.forward, mouseShootLayerMask);

                if (hit.collider != null)
                {
                    if (hit.collider.tag.Equals("Backround") || hit.collider.tag.Equals("Platform"))
                    {
                        GameObject myBullet = Instantiate(Resources.Load("Bullet") as GameObject, transform);
                        Vector2 dir = (hit.point - new Vector2(this.transform.position.x, this.transform.position.y)).normalized;
                        myBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletForce);
                        myBullet.transform.position = transform.position + new Vector3(dir.x * 0.5f, dir.y * 0.5f, 0.0f);
                        Destroy(myBullet, bulletTimeOfLife);
                    }
                }
            }
        }
    }
}
