using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{

    [SerializeField]
    GameObject saver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<FadeInOut>().FadeStart();
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
}
