using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void addComponentToObject(GameObject go)
    {
        go.AddComponent<WeaponUpgrade>();
        go.GetComponent<WeaponSetController>().weaponUpgradeCheck();
    }
}
