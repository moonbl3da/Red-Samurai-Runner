using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForwardSpeed = 10.0f;
    public float moveSideSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    private Rigidbody rb;
    public Animation anim;
    public AudioSource jumpAudio;
    public AudioSource runAudio;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        runAudio.Play();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * (moveForwardSpeed), Space.Self);
       
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.gameObject.transform.position.x > GameManager.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSideSpeed);
            }            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x < GameManager.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSideSpeed * -1);
            }
        }

        if(Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.Play("Jump");
            jumpAudio.Play();
            runAudio.Stop();
            isOnGround = false;
        }

        if(transform.position.y < -2.5)
        {
            GameManager.isGameOver = true;
            runAudio.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            anim.Play("Run");
            runAudio.Play();
            //Debug.Log("Collision");
            isOnGround = true;
        }    

        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.isGameOver = true;
            runAudio.Stop();
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Gate"))
        {
            GameManager.isGameOver = true;
            runAudio.Stop();
        }    
    }


}
