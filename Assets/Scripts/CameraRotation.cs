using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 5.0f)
        {
            transform.Rotate(10.0f * -Time.deltaTime, 0f, 0f);
            transform.Translate(0, 0, -1);
        }
    }
}
