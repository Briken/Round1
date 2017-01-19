using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

    public int playerNum = 1;
    Transform enemy;

    Rigidbody2D rig2d;
    Animator anim;

    float horizontal;
    float vertical;

    public float maxSpeed = 25;

    Vector3 movement;

    bool crouch;
    bool lPunch;
    bool hPunch;
    bool kick;
    bool jump;
    bool falling;
    bool onGround;


    public float jumpForce = 20;
    public float jumpDuration = .1f;
    float jmpDur;
    float jmpFrc;
    
    // Use this for initialization
    void Start ()
    {
        rig2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();	
	}

    void Update()
    {
        UpdateAnimator();
    }
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal" + playerNum.ToString());
        vertical = Input.GetAxis("Vertical" + playerNum.ToString());

        movement = new Vector3(horizontal, 0, 0);

        crouch = (vertical < -0.1f);

        if (vertical > 0.1f)
        { }

        if (!crouch)
        {
            rig2d.AddForce(movement * maxSpeed);
        }
        else
        {
            rig2d.velocity = Vector3.zero;
        }
	}

    void UpdateAnimator()
    {
        anim.SetBool("OnGround", this.onGround);
        anim.SetBool("HeavyPunch", this.hPunch);
        anim.SetBool("LightPunch", this.lPunch);
        anim.SetBool("Kick",this.kick);
        anim.SetBool("Jump", this.jump);
        anim.SetBool("Falling", this.falling);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = false;
        }
    }
}
