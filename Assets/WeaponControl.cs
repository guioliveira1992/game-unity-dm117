using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

    public GameObject weaponBall;
    public GameObject weaponHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(weaponBall, weaponHead.transform.position, weaponHead.transform.rotation);
        }
    }
}
