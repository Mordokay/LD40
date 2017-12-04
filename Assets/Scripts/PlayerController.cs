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

    public List<GameObject> starObjects;

    float PlayerInitialGravity;
    GameObject bulletBase;
    public bool isOnBullet;

    public bool doubleJumpActivated;

    GameObject canvas;

    private void Start()
    {
        doubleJumpActivated = false;
        isOnBullet = false;
        PlayerInitialGravity = this.GetComponent<Rigidbody2D>().gravityScale;

        if (!PlayerPrefs.HasKey("CheckpointX"))
        {
            PlayerPrefs.SetFloat("CheckpointX", 0.0f);
        }
        if (!PlayerPrefs.HasKey("CheckpointY"))
        {
            PlayerPrefs.SetFloat("CheckpointY", 0.0f);
        }
        if (!PlayerPrefs.HasKey("Star1")){PlayerPrefs.SetInt("Star1", 0);}
        if (!PlayerPrefs.HasKey("Star2")) { PlayerPrefs.SetInt("Star2", 0); }
        if (!PlayerPrefs.HasKey("Star3")) { PlayerPrefs.SetInt("Star3", 0); }
        if (!PlayerPrefs.HasKey("Star4")) { PlayerPrefs.SetInt("Star4", 0); }
        if (!PlayerPrefs.HasKey("Star5")) { PlayerPrefs.SetInt("Star5", 0); }
        if (!PlayerPrefs.HasKey("Star6")) { PlayerPrefs.SetInt("Star6", 0); }
        if (!PlayerPrefs.HasKey("Star7")) { PlayerPrefs.SetInt("Star7", 0); }
        if (!PlayerPrefs.HasKey("Star8")) { PlayerPrefs.SetInt("Star8", 0); }
        if (!PlayerPrefs.HasKey("Star9")) { PlayerPrefs.SetInt("Star9", 0); }

        this.transform.position = 
            new Vector3(PlayerPrefs.GetFloat("CheckpointX"), PlayerPrefs.GetFloat("CheckpointY"), 0.0f);

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canJump = false;
        timeSinceLastJump = 0.0f;

        InitializeStars();
    }

    void InitializeStars()
    {
        canvas.GetComponent<UIManager>().Start();

        if (PlayerPrefs.GetInt("Star1") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(0);
            canvas.GetComponent<UIManager>().activatedStars[0] = true;
            starObjects[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star2") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(1);
            canvas.GetComponent<UIManager>().activatedStars[1] = true;
            starObjects[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star3") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(2);
            canvas.GetComponent<UIManager>().activatedStars[2] = true;
            starObjects[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star4") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(3);
            canvas.GetComponent<UIManager>().activatedStars[3] = true;
            starObjects[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star5") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(4);
            canvas.GetComponent<UIManager>().activatedStars[4] = true;
            starObjects[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star6") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(5);
            canvas.GetComponent<UIManager>().activatedStars[5] = true;
            starObjects[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star7") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(6);
            canvas.GetComponent<UIManager>().activatedStars[6] = true;
            starObjects[6].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star8") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(7);
            canvas.GetComponent<UIManager>().activatedStars[7] = true;
            starObjects[7].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Star9") == 1)
        {
            canvas.GetComponent<UIManager>().ActivateStar(8);
            canvas.GetComponent<UIManager>().activatedStars[8] = true;
            starObjects[8].SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform") || collision.gameObject.tag.Equals("Breakable") ||
            collision.gameObject.tag.Equals("PointyBallBox") || collision.gameObject.tag.Equals("Cannon"))
        {
            canJump = true;
            doubleJumpActivated = false;
        }    
        else if (collision.gameObject.tag.Equals("CannonDriver"))
        {
            isOnBullet = true;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            bulletBase = collision.gameObject;
            //TOFO gravity and stuff
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            canJump = false;
        }
        if (collision.gameObject.tag.Equals("CannonDriver"))
        {
            isOnBullet = false;
            this.GetComponent<Rigidbody2D>().gravityScale = PlayerInitialGravity;
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
                if ((canJump || isOnBullet || !doubleJumpActivated) && timeSinceLastJump > 0.3f)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
                    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
                    
                    timeSinceLastJump = 0.0f;
                    if (!canJump && !doubleJumpActivated)
                    {
                        doubleJumpActivated = true;
                    }
                }
            }

            float velocityX;

            if (isOnBullet)
            {
                velocityX = bulletBase.GetComponent<Rigidbody2D>().velocity.x;
            }
            else
            {
                velocityX = 0;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                velocityX -= horizontalVelocity;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                velocityX += horizontalVelocity;
            }

            this.GetComponent<Rigidbody2D>().velocity = new Vector3(velocityX, this.GetComponent<Rigidbody2D>().velocity.y, 0.0f);

            //This is the shooting of bullets. Gonna disable for now

            /*
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
            */
        }
    }
}
