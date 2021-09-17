using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float walkSpeed;
    float runSpeed = 0;
    bool isRun;
    Rigidbody playerBody;
    Vector3 inputDirection;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (isRun)
        {
            runSpeed = 1.5f;
        }
        else
        {
            runSpeed = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
            animator.SetBool("jump", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRun = true;
            animator.SetInteger("run", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRun = false;
            animator.SetInteger("run", 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * walkSpeed * runSpeed;
            animator.SetInteger("walk", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("walk", 0);
            animator.SetInteger("run", 0);
        }
        /*else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * walkSpeed * runSpeed;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * walkSpeed * runSpeed;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * walkSpeed * runSpeed;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, 0);
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("jump",false);
        }
    }
}
