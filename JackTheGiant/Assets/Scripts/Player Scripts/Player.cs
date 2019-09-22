using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    //[SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    void Awake ()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player Script has started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }
    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs ( myBody.velocity.x);

        float h = Input.GetAxisRaw ("Horizontal");
        Vector3 temp = transform.localScale;
        if (h > 0)
        {
            //Debug.Log("right movment detected");
            if (vel < maxVelocity)
                forceX = speed;

            //seting the scale makes sure the sprite is facing the correct direction
            temp.x = 1.3f;
            transform.localScale = temp;

            //starts walk animation
            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            //Debug.Log("left movment detected");
            if (vel < maxVelocity)
                forceX = -speed;

            //set scale backwards
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);

        } else
        {
            anim.SetBool("Walk", false);
        }
        

        myBody.AddForce(new Vector2(forceX, 0));
    }
}
