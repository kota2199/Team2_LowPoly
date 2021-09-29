using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;

    [SerializeField] float walkSpeed;

    float runSpeed = 1.2f;

    bool isRun = false;

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
        //walk_forward
        if (Input.GetKeyDown(KeyCode.W) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            animator.SetInteger("walk", 1);
        }
        if (Input.GetKey(KeyCode.W) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position += transform.forward * walkSpeed * Time.deltaTime;
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
            animator.SetInteger("walk", 0);
            audioSource.Stop();
            StopWalkingSound();
        }

        if (Input.GetKeyDown(KeyCode.S) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            animator.SetInteger("walk", 1);
        }
        if (Input.GetKey(KeyCode.S) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position -= transform.forward * walkSpeed * Time.deltaTime;
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
            animator.SetInteger("walk", 0);
            audioSource.Stop();
            StopWalkingSound();
        }

        //run_switch
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            isRun = true;
            animator.SetInteger("run", 1);
            runsound = true;
            walksound = false;
            StopWalkingSound();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            isRun = false;
            animator.SetInteger("run", 0);
            runsound = false;
            walksound = true;
            StopRunningSound();
        }

        //running
        //forward
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position += transform.forward * walkSpeed * runSpeed * Time.deltaTime;
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

        //back
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            transform.position -= transform.forward * walkSpeed * runSpeed * Time.deltaTime; if (runsound)
            if(runsound)
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

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            playerBody.AddForce(new Vector3(0, 120, 0), ForceMode.Impulse);
            audioSource.PlayOneShot(jumping);
            animator.SetBool("jump", true);
            canJump = false;
        }

        //right
        if (Input.GetKey(KeyCode.A) && !GetComponent<BattleSystem>().isDeath)
        {
            transform.position -= transform.right * walkSpeed * Time.deltaTime;
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
        if (Input.GetKeyUp(KeyCode.A) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            StopWalkingSound();
            animator.SetInteger("walk", 0);
            animator.SetInteger("run", 0);
            audioSource.Stop();
        }

        //left
        if (Input.GetKey(KeyCode.D) && !GetComponent<BattleSystem>().isDeath)
        {
            transform.position += transform.right * walkSpeed * Time.deltaTime;
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
        if (Input.GetKeyUp(KeyCode.D) && !GetComponent<BattleSystem>().isDeath && !stopWalk)
        {
            StopWalkingSound();
            animator.SetInteger("walk", 0);
            animator.SetInteger("run", 0);
            audioSource.Stop();
        }

        if (playerBody.velocity.magnitude > 0.03f)
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
