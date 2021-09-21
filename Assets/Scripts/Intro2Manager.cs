using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro2Manager : MonoBehaviour
{

    [SerializeField]
    AudioClip exp1, exp2, caution;

    [SerializeField]
    ParticleSystem expl1, expl2, smoke;

    [SerializeField]
    GameObject cam1, cam2 ,cams;

    AudioSource aS;

    bool camMove = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Explosion");
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camMove)
        {
            cams.transform.position -= new Vector3(0, 0, 0.8f);
        }
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(5);
        cam1.SetActive(false);
        cam2.SetActive(true);
        aS.PlayOneShot(exp1);
        expl1.Play();
        //aS.PlayOneShot(caution);
        yield return new WaitForSeconds(0.2f);
        aS.PlayOneShot(exp2);
        expl2.Play();
        smoke.Play();
        yield return new WaitForSeconds(5);
        camMove = true;
    }
}
