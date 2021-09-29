using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManage : MonoBehaviour
{

    [SerializeField]
    GameObject messengers;

    [SerializeField]
    Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TutorialJudge",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(3);
        messageText.text = "あなたは、惑星探査に向かう途中に不時着してしまった宇宙船のパイロットです。";
        yield return new WaitForSeconds(5);
        messageText.text = "この星から脱出するには、船を修理しなければいけません。";
        yield return new WaitForSeconds(5);
        messageText.text = "まずは移動してみましょう。\nWとSキーで前進後退、AとDキーで左右に移動\nスペースキーでジャンプできます。";
        yield return new WaitForSeconds(5);
        messageText.text = "マウスを移動させると視点を移動できます。";
        yield return new WaitForSeconds(5);
        messageText.text = "そのまま目印まで移動してみましょう！";
    }

    public IEnumerator BattleTutorial()
    {
        Debug.Log("ok");
        yield return null;
        messageText.text = "モンスターが現れました！\n左クリックで攻撃できます！近づいて倒してみましょう！";
    }

    public IEnumerator NextTutorial()
    {
        messengers.SetActive(true);
        messageText.text = "モンスターを倒しました！\nモンスターを倒すと船の修理に必要なパーツや、武器などのアイテムを獲得できます。";
        yield return new WaitForSeconds(5);
        messageText.text = "また、モンスターを倒すとExpを獲得でき、\nゲージが満タンになるとレベルが上がります！";
        yield return new WaitForSeconds(5);
        messageText.text = "レベルが上がると防御力や攻撃力が上がり、より強いモンスターを倒すことが出来るようになります！";
        yield return new WaitForSeconds(5);
        messageText.text = "最後に、Escapeキーを押すとメニューが表示され、\nセーブをすることができます！";
        yield return new WaitForSeconds(5);
        messageText.text = "モンスターに倒されると最後にセーブした状態まで戻ってしまします。\nこまめなセーブを！";
        yield return new WaitForSeconds(5);
        messageText.text = "それでは、頑張ってパーツを集めてこの星から脱出しましょう！健闘を祈ります！";
        yield return new WaitForSeconds(5);
        messageText.text = "";
        messengers.SetActive(false);
        GameObject.Find("DetaSaver").GetComponent<DateHold>().Boot();
        GameObject.Find("Player").GetComponent<SaveSystem>().SaveButton();
    }

    void TutorialJudge()
    {
        if (GameObject.Find("DetaSaver").GetComponent<DateHold>().boots == 0)
        {
            Debug.Log("Start");
            messengers.SetActive(true);
            StartCoroutine("Tutorial");
        }
        else
        {
            messengers.SetActive(false);
        }
    }
}
