using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float walkSpeed = 5;
    float runSpeed = 0;
    bool isRun;
    Rigidbody playerBody;
    Vector3 inputDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (isRun)
        {
            runSpeed = 2;
        }
        else
        {
            runSpeed = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        //transform.position += inputDirection * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            playerBody.AddForce(transform.forward * 15 * runSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerBody.AddForce(transform.right * -15 * runSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerBody.AddForce(transform.forward * -15 * runSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerBody.AddForce(transform.right * 15 * runSpeed);
        }
    }
}