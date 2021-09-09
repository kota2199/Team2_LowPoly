using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroManage : MonoBehaviour
{

    [SerializeField]
    AudioClip[] ex_s;

    [SerializeField]
    AudioClip Jet, caution;

    [SerializeField]
    ParticleSystem ex1, ex2, smoke, fire;

    [SerializeField]
    GameObject[] effects;

    [SerializeField]
    GameObject[] cam;

    [SerializeField]
    GameObject cautionPanel;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * 0.5f;
        if (Input.GetKeyDown(KeyCode.A))
        {
            CamSwitch();
        }

    }

    void CamSwitch()
    {
        cam[0].SetActive(false);
        cam[1].SetActive(true);
        Invoke("explosion", 0.5f);
    }

    void explosion()
    {
        StartCoroutine("Cautioning");
        StartCoroutine("CautionSound");
        effects[0].SetActive(true);
        effects[1].SetActive(true);
        ex1.Play();
        ex2.Play();
        audioSource.PlayOneShot(ex_s[0]);
        audioSource.PlayOneShot(ex_s[1]);
        audioSource.PlayOneShot(ex_s[2]);
        audioSource.PlayOneShot(ex_s[3]);
        Invoke("StartFire", 1);
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

    private IEnumerator Cautioning()
    {
        while (true)
        {
            cautionPanel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            cautionPanel.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator CautionSound()
    {
        while (true)
        {
            audioSource.PlayOneShot(caution);
            yield return new WaitForSeconds(4);
        }
    }
}
