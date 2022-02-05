using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private string WALK_ANIMATION = "Walk";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        // Debug.Log("Time.deltaTime: " + Time.deltaTime);
    }

    void AnimatePlayer() {
        if ( movementX > 0 ) {  // moving to the right side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if ( movementX < 0 ) {   // moving to the left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {    // not moving
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}   // class
