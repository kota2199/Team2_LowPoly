using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField]
    int weaponId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (weaponId == 2)
            {
                other.GetComponent<WeaponGet>().GetWeapon2(this.gameObject);

            } else if (weaponId == 3)
            {
                other.GetComponent<WeaponGet>().GetWeapon3(this.gameObject);

            } else if (weaponId == 4)
            {
                other.GetComponent<WeaponGet>().GetBomb(this.gameObject);
            }
        }
    }
}
