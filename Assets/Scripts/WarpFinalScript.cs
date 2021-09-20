using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarpFinalScript : MonoBehaviour
{
    [SerializeField] string nextScene;  //次のシーンの名前

    public bool hasAllItems, hasSta2Item, hasSta3Item;
    public Text notEnough;

    private float countTime = 0;
    private bool startCount;

    // Start is called before the first frame update
    void Start()
    {
        hasAllItems = false;
        hasSta2Item = false;
        hasSta3Item = false;
        startCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount == true)
        {
            countTime += Time.deltaTime;
        }
        if (countTime >= 3)
        {
            notEnough.gameObject.SetActive(false);
            startCount = false;
            countTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                if (other.gameObject.name == "ToStage2")
                {
                    //アイテムが揃ってる場合
                    if (hasSta2Item == true)
                    {
                        StartCoroutine("ChangeStage2");
                    }
                    //アイテムが揃ってない場合
                    if (hasSta2Item == false)
                    {
                        notEnough.gameObject.SetActive(true);
                        startCount = true;
                    }
                }
                if (other.gameObject.name == "ToStage3")
                {
                    //アイテムが揃ってる場合
                    if (hasSta3Item == true)
                    {
                        StartCoroutine("ChangeStage3");
                    }
                    //アイテムが揃ってない場合
                    if (hasSta3Item == false)
                    {
                        notEnough.gameObject.SetActive(true);
                        startCount = true;
                    }
                }
                if (other.gameObject.name == "ToFinalStage")
                {
                    //アイテムが揃ってる場合
                    if (hasAllItems == true)
                    {
                        StartCoroutine("ChangeLast");
                    }
                    //アイテムが揃ってない場合
                    if (hasAllItems == false)
                    {
                        notEnough.gameObject.SetActive(true);
                        startCount = true;
                    }
                }
            }
    }

    IEnumerator ChangeLast()
    {
        GetComponent<FadeInOut>().FadeStart();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("");

    }
    IEnumerator ChangeStage2()
    {
        GetComponent<FadeInOut>().FadeStart();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Stage_2");

    }
    IEnumerator ChangeStage3()
    {
        GetComponent<FadeInOut>().FadeStart();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Stage_3");

    }
}
