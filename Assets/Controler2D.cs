using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler2D : MonoBehaviour
{
    //variable 
    Rigidbody2D rb;
    SpriteRenderer sr;

    float moveSpeedHorizontal = 400f;
    //float moveSpeedVertical =3f;
    float horizontalValue;
    float verticalValue;
    float jumpForce = 5f;
    [SerializeField]bool isJumping = false;
    [SerializeField] bool canJump = false;
    [Range(0,1)] [SerializeField] float smoothtime = 0.5f;

    float current = 50;
    float target = 300;
    Vector2 refVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // regarde si on a un rigidbody dans la scène si oui on fait
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        sr = GetComponent<SpriteRenderer>();
        //float test= Mathf.Lerp(current, target, 0);
        Debug.Log(Mathf.Lerp(current, target, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
       horizontalValue = Input.GetAxis("Horizontal");
       verticalValue = Input.GetAxis("Vertical");

       sr.flipX = horizontalValue < 0;
        
       if(Input.GetButtonDown("Jump"))
        {

            isJumping = true;
        }
        
            
        
        //*Debug.Log(horizontalValue);*//
    }
    
    void FixedUpdate()
    {   
        if(isJumping && canJump)
        {
            canJump = false;
            isJumping = false; 
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        Vector2 targetVelocity = new Vector2(horizontalValue * moveSpeedHorizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, smoothtime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    canJump = true;
        //Debug.Log(collision.gameObject.tag);
    }
 


}
