using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleMoveEnding1 : MonoBehaviour
{

    [SerializeField]
    float speed;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += transform.forward * speed;
        if (timer >= 2.5f)
        {
            speed += Time.deltaTime;
        }
    }
}
