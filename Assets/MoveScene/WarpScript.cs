using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpScript : MonoBehaviour
{
    [SerializeField] string nextScene;  //次のシーンの名前
    [SerializeField] GameObject fadeManager;
    FadeInOut fadeInOut;

    // Start is called before the first frame update
    void Start()
    {
        //fadeInOut = fadeCanvas.GetComponent<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine("ChangeScene");
            }
        }
    }

    IEnumerator ChangeScene()
    {
        //fadeInOut.FadeOut();
        fadeManager.GetComponent<FadeInOut>().FadeStart();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextScene);

    }
}
