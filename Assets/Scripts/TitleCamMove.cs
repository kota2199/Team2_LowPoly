using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamMove : MonoBehaviour
{
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.9f * Time.deltaTime, 0));
    }
}
