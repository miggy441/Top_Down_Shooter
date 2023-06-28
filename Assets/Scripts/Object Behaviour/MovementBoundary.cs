using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Moveable))]//Untuk memastikan setiap menambahkan MovementBoundary, harus ada component Movable

//Script ini digunakan untuk membatasi semua object yang menggunakan script Moveable

public class MovementBoundary : MonoBehaviour
{
    public Rect boundary; //digunakan untuk mengecek player selanjutnya ada dimana

    private Moveable moveable;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (isXOutOfBoundary())
        {
            moveable.setXDirection(0f);
        }

        if (isYOutOfBoundary())
        {
            moveable.setYDirection(0f);
        } 
    }

    private bool isYOutOfBoundary()
    {
        return moveable.getNextPosition().y < boundary.yMin || moveable.getNextPosition().y > boundary.yMax;
    }

    private bool isXOutOfBoundary() //kalo player berada di luar boundary
    {
        return moveable.getNextPosition().x < boundary.xMin || moveable.getNextPosition().x > boundary.xMax; //untuk cek posisi selanjutnya ada di luar
    }
}
