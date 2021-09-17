using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroManage : MonoBehaviour
{

    AudioSource audioSource;

    private float speed = 10;

    private bool col = false;

    [SerializeField]
    GameObject exp_1, exp_2;

    [SerializeField]
    AudioClip explo;

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
        audioSource.Stop();
        col = true;
        exp_1.SetActive(true);
        audioSource.PlayOneShot(explo);
        Invoke("NextExp",2);
    }
    void NextExp()
    {
        exp_2.SetActive(true);
        audioSource.PlayOneShot(explo);
    }
}
