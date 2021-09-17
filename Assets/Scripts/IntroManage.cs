using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroManage : MonoBehaviour
{

    AudioSource audioSource;

    private float speed = 15;

    private bool col = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed;
        if (speed > 0)
        {
            speed -= 0.15f;
        }
        if (speed <= 0)
        {
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        col = true;
        Debug.Log("ok");
    }
}
