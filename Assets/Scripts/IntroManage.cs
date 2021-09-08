using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManage : MonoBehaviour
{
    public GameObject cam;

    [SerializeField]
    AudioClip[] ex_s;

    [SerializeField]
    AudioClip Jet;

    [SerializeField]
    ParticleSystem ex1, ex2, smoke, fire;

    [SerializeField]
    GameObject[] effects;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * 0.1f;
        if (Input.GetKeyDown(KeyCode.A))
        {
            explosion();
        }
    }

    void explosion()
    {
        effects[0].SetActive(true);
        effects[1].SetActive(true);
        ex1.Play();
        ex2.Play();
        audioSource.PlayOneShot(ex_s[0]);
        audioSource.PlayOneShot(ex_s[1]);
        audioSource.PlayOneShot(ex_s[2]);
        audioSource.PlayOneShot(ex_s[3]);
        Invoke("StartFire", 0.5f);
        Invoke("DestroyExpl",2);
    }

    void StartFire()
    {
        effects[2].SetActive(true);
        effects[3].SetActive(true);
        smoke.Play();
        fire.Play();
    }
    void DestroyExpl()
    {
        effects[0].SetActive(false);
        effects[1].SetActive(false);
    }
}
