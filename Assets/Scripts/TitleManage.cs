using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{

    [SerializeField]
    GameObject saver;

    [SerializeField]
    GameObject[] cam;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip startSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CamSwitch");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<FadeInOut>().FadeStart();
            audioSource.PlayOneShot(startSound);
            Invoke("ToNext", 2);
        }
    }

    void ToNext()
    {
        if (saver.GetComponent<DateHold>().boots == 0)
        {
            SceneManager.LoadScene("Intro1");
        }
        if (saver.GetComponent<DateHold>().boots > 0)
        {
            SceneManager.LoadScene("Stage_1");
        }
    }

    private IEnumerator CamSwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            cam[0].GetComponent<Camera>().enabled = false;
            cam[1].GetComponent<Camera>().enabled = true;
            yield return new WaitForSeconds(7);
            cam[1].GetComponent<Camera>().enabled = false;
            cam[2].GetComponent<Camera>().enabled = true;
            yield return new WaitForSeconds(7);
            cam[2].GetComponent<Camera>().enabled = false;
            cam[0].GetComponent<Camera>().enabled = true;
        }
    }
}
