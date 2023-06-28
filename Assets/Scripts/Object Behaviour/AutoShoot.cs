using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script ini digunakan untuk mengendalikan weapon dan menembakkan weapon tersebut

public class AutoShoot : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        foreach (Weapon w in GetComponentsInChildren<Weapon>()) // Mengambil komponen di anak dari gameObject EnemyBig, yaitu weapon ; getcomponents, artinya yang direturn berupa array ; Setiap komponen Weapon, misal pada enemy big, ada 3 weapon, maka ketika dipangggil fungsi ini, ketiga weapon tersebut akan menembak
        {
            w.shoot(); // akan dipanggil shootnya. 
        }
    }
}
