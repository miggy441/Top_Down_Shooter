 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScrollingBackground : MonoBehaviour
{
    public Transform[] background;

    private Vector3 direction;

    public float speed;

    public int index2;


    // Start is called before the first frame update
    void Start()
    {
        
        direction = new Vector3(0, -1, 0); // arah gerak kamera keatas, berarti sumbu y turun sebesar -1
    }

    // Update is called once per frame
     void Update()
     {
        
        positionUpdate();
        checkPosition();
     }

    private void checkPosition()
    {
        if (background[0].position.y <= -10f)
        {
            movetoTop(0);
        }
        if (background[1].position.y <= -10f)
        {
            movetoTop(1);
        }
        if (background[2].position.y <= -10f)
        {
            movetoTop(2);
        }
        if (background[3].position.y <= -10f)
        {
            movetoTop(3);
        }
    }

    private void movetoTop(int index)
    {
        //index2 = UnityEngine.Random.Range(0, background.Length);
        //Random();
        RandomNumber();
        
        if (index == 0)
        {
            background[0].position = background[3].position + new Vector3(0, 10, 0);
            

        }

        if (index == 1)
        {
            background[1].position = background[0].position + new Vector3(0, 10, 0);
            
        }
        
        if (index == 2)
        {
            background[2].position = background[1].position + new Vector3(0, 10, 0);
            
        }
        
        if (index == 3)
        {
            background[3].position = background[2].position + new Vector3(0, 10, 0);
            
        }
        
    }


    private void positionUpdate() //untuk merubah posisi dari environment 1 ke 2
    {
        background[0].position += direction * Time.deltaTime * speed;
        background[1].position += direction * Time.deltaTime * speed;
        background[2].position += direction * Time.deltaTime * speed;
        background[3].position += direction * Time.deltaTime * speed;
    }

    private void RandomNumber()
    {
        int indexNumber = UnityEngine.Random.Range(0, background.Length);
    }

    private void RandomNumber2()
    {

    }
}