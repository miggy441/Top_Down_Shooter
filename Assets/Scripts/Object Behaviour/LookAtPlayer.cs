using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script ini dibuat supaya weaponnya otomatis berotasi ke arah player
// Fungsi script ini merotasi object yang ditempel script ini agar selalu mengarah ke arah player

public class LookAtPlayer : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        LookAt();
    }

    private void LookAt()
        {
            if (GameManager.GetInstance().activePlayer != null) // jika activePlayernya ada
            {
            transform.up = GameManager.GetInstance().activePlayer.transform.position - transform.position; // transform.up artinya mengatur sumbu y (warna hijau) // isinya adalah posisi player sekarang dikurang posisi object saat ini
            }
        }
}
