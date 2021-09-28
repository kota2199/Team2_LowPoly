using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossBattle : MonoBehaviour
{

    [SerializeField]
    GameObject lastBoss;

    [SerializeField]
    AudioClip battleBGM;

    bool isLastBattle;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<WarpFinalScript>().hasAllItems)
        {
            lastBoss.SetActive(true);
            audioSource.Play();
        }
    }
}
