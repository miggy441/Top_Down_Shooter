using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Supaya semua object yang ingin digerakkan bisa bergerak, ditambahkan component Script ini

public class Moveable : MonoBehaviour
{

    public float speed;
    
    private Vector3 direction; // semua objek yang punya script moveable, akan ada "direction"nya:

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    private void updatePosition()
    {
        transform.position = getNextPosition();   
    }

    public Vector3 getNextPosition() //Function ini bisa digunakan di kelas lain, misalnya di boundary
    {
        return transform.position + newPosition();
    }

    public Vector3 newPosition()
    {
        return direction * Time.deltaTime * speed;
    }

    internal void setXDirection(float v)
    {
        direction.x = v;
    }

    internal void setYDirection(float v)
    {
        direction.y = v;
    }

    internal void setDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }

    public void setDirection(Vector3 value)
    {
        direction = value; // kelas lain bisa mengakses kelas moveable dan bisa memanggil function setDirection
    }

    public void setDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;
    }
}
