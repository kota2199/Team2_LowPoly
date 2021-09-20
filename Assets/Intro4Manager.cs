using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro4Manager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    float speed;

    bool col = false;

    [SerializeField]
    ParticleSystem explo1, explo2;

    [SerializeField]
    AudioClip explo;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col && speed >= 0)
        {
            speed -= 0.15f;
        }
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        col = true;
        StartCoroutine("Explosion");
    }

    private IEnumerator Explosion()
    {
        explo1.Play();
        audioSource.PlayOneShot(explo);
        yield return new WaitForSeconds(1);
        explo2.Play();
        audioSource.PlayOneShot(explo);
    }
}
