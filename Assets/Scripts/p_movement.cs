using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_movement : MonoBehaviour
{

    Rigidbody player;
    public float speed;
    public float jumpForce;
    public float rotSensitivity;
    bool isGrounded;
    bool canJumpAgain;
    bool jumpKey;
    float leftAxis;
    float rightAxis;
    //   bool faceLeftKey;
    //  bool faceRightKey;
    Vector3 pos;
    public GameObject scriptCarrier;
    Dont_collide GunScript;



    // Use this for initialization
    void Start()
    {
        
        GunScript = scriptCarrier.GetComponent<Dont_collide>();
        speed = 5;
        jumpForce = 400;
        rotSensitivity = 600;
        //Basic movment vars
        player = GetComponent<Rigidbody>();
        //Bools that manage the double jump mechanic
        isGrounded = true;
        canJumpAgain = false;
    }

    // Update is called once per frame
    void Update()
    {
        // pos is the vector that stores the player position
        pos = transform.position;
        


        //Storing Keys on bool values every frames
        seeKeysPressed();

        //Assining move() and rotate to Keys
        if (leftAxis < -0.3)
        {
            move("left");
        }
        if (rightAxis > 0.3)
        {
            move("right");
        }
        if (jumpKey) move("jump");
    }

    //Movement Handler
    void move(string dir)
    {



        if (dir == "left")
        {

            pos.z += speed * leftAxis * Time.deltaTime;
            if (GunScript.canrotate == true)
            {
                //While moving the char create the rotation of the gun
                transform.Rotate(Vector3.right * leftAxis * rotSensitivity * Time.deltaTime);

            }

        }


        if (dir == "right")
        {
            pos.z += speed * rightAxis * Time.deltaTime;
            //While moving the char create the rotation of the gun
            if (GunScript.canrotate == true)
            {
                transform.Rotate(Vector3.right * rightAxis * rotSensitivity * Time.deltaTime);
            }
        }


        //Jumping
        if (dir == "jump")
        {
            if (isGrounded)
            {
                player.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
                canJumpAgain = true;
            }
            else
            {
                if (canJumpAgain && jumpKey)
                {
                    Debug.Log("double");
                    //jumpForce/2 cause the double jump has less force than the first jump
                    player.AddForce(new Vector3(0, jumpForce / 2, 0));
                    canJumpAgain = false;
                }
            }


            //TODO can aply raycast to make the falling of the object more smooth/hard
        }
        transform.position = pos;
    }
    //Reseting the isGrounded var
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    //Storing Keys on bool values
    void seeKeysPressed()
    {
        jumpKey = Input.GetButtonDown("AButton");
        leftAxis = Input.GetAxis("LeftJoyHorizontal");
        rightAxis = Input.GetAxis("LeftJoyHorizontal");
        // faceLeftKey = Input.GetKey(KeyCode.A);
        //faceRightKey = Input.GetKey(KeyCode.D);
    }

    //While moving the char create the rotation of the gun
    void rotate(string dir)
    {
        if (dir == "left")
        {
            transform.Rotate(Vector3.right * rotSensitivity * Time.deltaTime);
        }
        if (dir == "right")
        {
            transform.Rotate(Vector3.left * rotSensitivity * Time.deltaTime);
        }
    }
}
