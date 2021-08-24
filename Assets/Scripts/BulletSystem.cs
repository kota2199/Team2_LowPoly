using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{

    public GameObject mother;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(mother.transform.forward * 40 + new Vector3(0, 2, 0), ForceMode.Impulse);
        Invoke("AutoDestroy", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<BattleSystem>().ArrowDamaged();
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

    void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
