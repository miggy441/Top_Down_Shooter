using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fungsi utama script ini adalah untuk menembakkan peluru, untuk siapa yang menembak tugasnya script controller stiap unit yang kita punya.
//misalnya player, yang menentukan player menembak atau tidak, bisa saja melalui button atau menggunakan script untuk menembak secara otomatis.

public class Weapon : MonoBehaviour
{
    public float fireRate; // Untuk mengontrol seberapa sering weapon ini menembakkan senjatanya.

    

    // misal. fire rate nya 1, maka setiap 1 detik akan menembakkan peluru

    public List<float> fireRateModifiers;
    public PoolObjectType type;

    private float timer = 0;

    void Start()
    {
        fireRateModifiers = new List<float>();
    }

    void Update()
    {
        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f; // Pertama dicek dulu jika timer dikurangi time.deltaTime lebih dari nol (ditandai dengan tanda tanya), maka akan dilakukan hal yang sama / akan diulangi lagi timer - Time.deltaTime
                                                                         // Jika tidak lebih dari nol, maka akan diisi dengan nol (ditandai dengan tanda titik dua)
    }

    internal void addFireRateModifier(float modifier)
    {
        fireRateModifiers.Add(modifier);
    }

    internal void clearModifier()
    {
        fireRateModifiers.Clear();
    }

    internal void removeFireRateModifier(float modifier)
    {
        fireRateModifiers.Remove(modifier);
    }

    public void shoot()
    {
        if (timer == 0f) //Jika timernya nol
        {
            //Debug.Log("Tembak");
            ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
            timer = fireRate / getFireRateModifier(); //Baru diperbolehkan untuk menembak
        }
    }

    private float getFireRateModifier()
    {
        float mod = 1;

        foreach(float f in fireRateModifiers)
        {
            mod += f;
        }

        return mod;
    }
    
}
