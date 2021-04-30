using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D rbpx;
    float HorizontalAxis, VerticalAxis;
   public float Speed = 20f;
    public float JumpForce = 2f;
    Animator PlayerAnim, PickAxeAnim;
    string CurrentOreArea;
    public float maxMoveSpeed = 5f;
    private bool isGrounded;
    AudioSource JumpSound,BlankSound;
    public AudioClip JumpSoundClip;
    bool Hitting = false;
    public bool Fading = false;
    // Start is called before the first frame update
    void Start()
    {
        JumpSound = GetComponent<AudioSource>();
        PickAxeAnim = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        rbpx = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<BoxCollider2D>();
       
    }


    private void FixedUpdate()
    {
        MovePlayer();
        JumpLogic();
        FlipCharacter();
        if (Input.GetKey(KeyCode.Space) && !Hitting)
        {
            Hitting = true;
            CollectOre();
        }
    }
    void MovePlayer()
    {
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(HorizontalAxis, 0.0f);
        rb.AddForce(movement * Speed,ForceMode2D.Force );
        if (rb.velocity.x > maxMoveSpeed )
        {
            rb.velocity = new Vector2(maxMoveSpeed, rb.velocity.y);
        }
        if (rb.velocity.x <0 && rb.velocity.x< -maxMoveSpeed)
        {
            rb.velocity = new Vector2(-maxMoveSpeed, rb.velocity.y);
        }
        if (HorizontalAxis != 0)
        {
            PlayerAnim.SetBool("Walking", true);
        }
        else
        {
            PlayerAnim.SetBool("Walking", false);
        }

    }
    private void JumpLogic()
    {
        if (isGrounded && (Input.GetAxis("Jump") > 0))
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            JumpSound.Play();
        }
    }
    void CollectOre()
    {
        rbpx.isTrigger = false;
        PickAxeAnim.SetBool("Hitting", true);
        StartCoroutine("UndoHit");
      
     
    }
    void FlipCharacter()
    {
        if (HorizontalAxis < 0)
        {
            transform.localScale = new Vector3(-7, transform.localScale.y);
        }
        else if (HorizontalAxis > 0)
        {
            transform.localScale = new Vector3(7, transform.localScale.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ore")
        {
            CurrentOreArea = collision.name;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CurrentOreArea = null;
    }
    IEnumerator UndoHit()
    {
        Hitting = false;
        yield return new WaitForSeconds (0.5f);
        rbpx.isTrigger = true;
       
        PickAxeAnim.SetBool("Hitting", false);
        yield return null;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpate(collision, true);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision2D collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}
