using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fungsi ini adalah untuk destroy semua object yang mungkin untuk di destroy1

public class Destroyable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
