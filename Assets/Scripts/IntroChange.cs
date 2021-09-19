using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("change",28);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change()
    {
        SceneManager.LoadScene("Introduction2");
    }
}
