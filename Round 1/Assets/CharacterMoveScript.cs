using UnityEngine;
using System.Collections;

public class CharacterMoveScript : MonoBehaviour {

    public float maxSpeed = 50;
    public float jumpforce = 10;

    Rigidbody2D charBody;

    

    Vector2 currentVelocity;

    bool faceRight = true;

	// Use this for initialization
	void Start ()
    {
        charBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        currentVelocity = charBody.velocity;
        charBody.velocity = new Vector2(movement * maxSpeed, currentVelocity.y);
        Debug.Log("this is your current vel: " + currentVelocity);
        if ((movement > 0 && !faceRight) || movement <0 && faceRight)
        {
            Turn();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping with this much force: " + jumpforce);
            charBody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    void Turn()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
