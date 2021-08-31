using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSystem : MonoBehaviour
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
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyBattle>().damagedHp = 5;
            other.GetComponent<EnemyBattle>().GunDamaged();
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
