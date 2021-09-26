using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleMoveEnding : MonoBehaviour
{
    float speed;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + Time.deltaTime + Time.deltaTime;
        timer = timer + Time.deltaTime;


        if (timer < 1.5f)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (timer >= 1.5f)
        {
            transform.position += transform.forward * speed;
        }
    }
}
