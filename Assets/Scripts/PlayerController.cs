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
    AudioSource audioSource;
    [SerializeField]
    AudioClip walking, running, jumping;

    bool walksound, runsound = true;

    float walk_s_length, running_s_length;

    bool canJump = true;

    public bool stopWalk = false;

    [SerializeField]
    ParticleSystem footsmoke;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.Space) && canJump && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            playerBody.AddForce(new Vector3(0, 80, 0), ForceMode.Impulse);
            audioSource.PlayOneShot(jumping);
            animator.SetBool("jump", true);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            isRun = true;
            animator.SetInteger("run", 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            walksound = false;
            StopWalkingSound();
            if (runsound)
            {
                RunningSound();
                running_s_length = running.length;
                runsound = false;
            }
            running_s_length -= Time.deltaTime;
            if (running_s_length <= 0)
            {
                RunningSound();
                running_s_length = running.length;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            runsound = false;
            walksound = true;
            isRun = false;
            animator.SetInteger("run", 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position += transform.forward * walkSpeed * runSpeed;
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position += transform.forward * walkSpeed * runSpeed;
            animator.SetInteger("walk", 1);
            if (walksound)
            {
                WalkingSound();
                walk_s_length = walking.length;
                walksound = false;
            }
            walk_s_length -= Time.deltaTime;
            if (walk_s_length <= 0)
            {
                WalkingSound();
                walk_s_length = walking.length;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            StopWalkingSound();
            animator.SetInteger("walk", 0);
            animator.SetInteger("run", 0);
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.S) && !GetComponent<BattleSystem>().isDeath)
        {
            transform.position -= transform.forward * walkSpeed * runSpeed;
            animator.SetInteger("walk", 1);
            if (walksound)
            {
                WalkingSound();
                walk_s_length = walking.length;
                walksound = false;
            }
            walk_s_length -= Time.deltaTime;
            if (walk_s_length <= 0)
            {
                WalkingSound();
                walk_s_length = walking.length;
            }
        }
        if (Input.GetKeyUp(KeyCode.S) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            StopWalkingSound();
            animator.SetInteger("walk", 0);
            animator.SetInteger("run", 0);
            audioSource.Stop();
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
        if (playerBody.velocity.magnitude > 0.1f)
        {
            if (!footsmoke.isEmitting)
            {
                footsmoke.Play();
            }
        }
        else
        {
            if (footsmoke.isEmitting)
            {
                footsmoke.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("jump",false);
        }
    }

    void WalkingSound()
    {
        audioSource.PlayOneShot(walking);
        audioSource.loop = true;
    }

    void RunningSound()
    {
        audioSource.PlayOneShot(running);
        audioSource.loop = true;
    }

    void StopWalkingSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        walksound = true;
    }

    void StopRunningSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        runsound = true;
    }
}
