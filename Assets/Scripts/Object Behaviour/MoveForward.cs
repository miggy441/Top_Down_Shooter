using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Untuk memberitahu kepada Script Movable, arah dan direction dari gameObject yang dimasukkan script ini

[RequireComponent(typeof(Moveable))] //Untuk memastikan setiap menambahkan MoveForward, harus ada component Movable

public class MoveForward : MonoBehaviour
{
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
        moveable.setDirection(transform.up);//Arah geraknya keatas sumbu y ; transform artinya nilai up nya akan tergantung arah hadap objek (garis hijau)
    }
}
