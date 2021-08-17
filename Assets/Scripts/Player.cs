using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0, 7 * Time.deltaTime);
            //transform.position += Vector3.forward * 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-7 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -7 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(7 * Time.deltaTime, 0, 0);
        }
    }
}