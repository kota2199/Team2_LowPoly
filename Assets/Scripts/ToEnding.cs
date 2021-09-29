using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<FadeInOut>().speed = 0.02f;
            other.GetComponent<FadeInOut>().FadeStart();
            Invoke("ToEndingScene", 8);
        }
    }

    void ToEndingScene()
    {
        SceneManager.LoadScene("Ending1");
    }
}
