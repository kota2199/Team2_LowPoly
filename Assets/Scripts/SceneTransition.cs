using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField]
    int waitTime;

    [SerializeField]
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ToNextScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ToNextScene()
    {
        yield return new WaitForSeconds(waitTime);
        //GetComponent<FadeInOut>().FadeStart();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
