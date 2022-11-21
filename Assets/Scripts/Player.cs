using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float jump = 400;
    public bool doubleJump;
    public bool isCurrentlyColliding;
    public GameObject restartMenu;

    private float initX;
    private float jumpTimer = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        doubleJump=false;
        initX = this.transform.position.x;
    }

    //game over condition
    void OnBecameInvisible()
    {
        if (this.transform.position.y<0){
            Time.timeScale = 0f;
            Instantiate(restartMenu); 
        }
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        isCurrentlyColliding = true;
        transform.eulerAngles = new Vector3 (0, 0, 0);
    }
    
    void OnCollisionExit2D(Collision2D col) {
        isCurrentlyColliding = false;
    }

    void Update()
    {
        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }

        if (doubleJump && isCurrentlyColliding){
                doubleJump = false;
            }


        //rotate when jumping    
        if (!isCurrentlyColliding){
            if (playerRigidbody.velocity.y>0.1){
                transform.eulerAngles = new Vector3 (0, 0, 20);
            }
            else if (playerRigidbody.velocity.y<-0.1){
                transform.eulerAngles = new Vector3 (0, 0, -20);
            }
            else {
                transform.eulerAngles = new Vector3 (0, 0, 0);
            }
        }

        //move toward initial position of screen
        if (!isCurrentlyColliding && this.transform.position.x>initX){
            this.transform.position += 0.01f*Vector3.left;
        }
        else if (!isCurrentlyColliding && this.transform.position.x<initX){
            this.transform.position += 0.01f*Vector3.right;
        }
 
        
        //jump
        if (Input.GetMouseButtonDown(0) && jumpTimer<=0)
        {
            jumpTimer = 0.1f;
            if (isCurrentlyColliding){
                playerRigidbody.AddForce(Vector2.up * jump * playerRigidbody.mass*(playerRigidbody.gravityScale/2));
            }
            else if (!doubleJump){
                playerRigidbody.AddForce(1.2f*Vector2.up * jump * playerRigidbody.mass*(playerRigidbody.gravityScale/2));
                doubleJump = true;
            }
            
             

        }
    }
}
