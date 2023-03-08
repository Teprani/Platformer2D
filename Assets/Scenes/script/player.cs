using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    CapsuleCollider2D cap;
    Rigidbody2D rb;
    SpriteRenderer sr;
    //Animator animController;
    float horizontal_value;
    Vector2 ref_velocity = Vector2.zero;

    float jumpForce = 12f;

    [SerializeField] TrailRenderer tr;
    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool grounded = false;
    [SerializeField] bool is_crouching = false;
    [Range(0, 1)] [SerializeField] float smooth_time = 0.5f;

     [SerializeField] int CountJump = 2;
    private int LastPressedJumpTime = 0;
    private int LastOnGroundTime = 0;



    bool CheckSphere;
    private Vector2 aidepose;
    [SerializeField] GameObject aide;

    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //animController = GetComponent<Animator>();
        //Debug.Log(Mathf.Lerp(current, target, 0));
        rb.gravityScale = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal_value = Input.GetAxis("Horizontal");

        if (horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;

        //animController.SetFloat("Speed", Mathf.Abs(horizontal_value));

        if (Input.GetKeyDown(KeyCode.Space) && CountJump > 0)
        {
            Jump();

        }
    }

 void Jump()
    {
        // Garantit que nous ne pouvons pas appeler Jump plusieurs fois � partir d'une seule pression
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        CountJump -= 1;
        

        // On augmente la force appliqu�e si on tombe
        // Cela signifie que nous aurons toujours l'impression de sauter le m�me montant
        float force = jumpForce;
        if (rb.velocity.y < 0)
            force -= rb.velocity.y;


        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

    }

    void FixedUpdate()
    {
       

        //if (Input.GetButton("Vertical") && grounded) ;
        //{
        //    Crouch();
        //}


        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);
        /*if (rb.velocity != Vector2.zero)
        {
            animController.SetBool("Run", true);
        }
        else animController.SetBool("Run", false);*/

    }
    /*private void Crouch()
    {
        if (Input.GetButton("Vertical") && grounded)
        {
            aidepose = new Vector2(aide.transform.position.x, aide.transform.position.y);
            CheckSphere = Physics2D.OverlapCircle(aidepose, 0.1f);
            is_crouching = true;
            moveSpeed_horizontal = 200f;
            cap.offset = new Vector2(0.1f, -0.6f);
            cap.size = new Vector2(1.1f, 0.8f);
            cap.direction = CapsuleDirection2D.Horizontal;
            animController.SetBool("Crouching", true);
        }
        else
        {
            aidepose = new Vector2(aide.transform.position.x, aide.transform.position.y);
            CheckSphere = Physics2D.OverlapCircle(aidepose, 0.1f);
            if (CheckSphere == false)
            {
                is_crouching = false;
                moveSpeed_horizontal = 400f;
                cap.offset = new Vector2(0f, -0.35f);
                cap.size = new Vector2(1f, 1.3f);
                cap.direction = CapsuleDirection2D.Vertical;
                animController.SetBool("Crouching", false);
            }
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //animController.SetBool("Jumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountJump = 2;
        grounded = true ;
        //animController.SetBool("Jumping", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false ;
        //animController.SetBool("Jumping", false);
    }

}
