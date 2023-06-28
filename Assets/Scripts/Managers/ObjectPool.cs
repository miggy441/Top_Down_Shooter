using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance; // Dibuat menjadi single tone. 

    public int size; //berapa banyak bolt, bullet, dan explosion masing2 akan di instantiate
    public GameObject[] prefabs;

    [SerializeField] private List<PoolObject> poolObjects;
    
    private void Awake() // functionnya untuk mengecek apakah instancenya null atau tidak
    {
        if (instance == null) // jika null
        {
            instance = this; // instancenya diisi dengan instance yang sekarang
        }
        else
        {
            Destroy(gameObject); // menghancurkan gameObject dari instance yang ini
        }
    }

    void Start()
    {
        instantiateObjects();
    }

    private void instantiateObjects() //Tugasnya untuk mengintansiasi objek yang kita punya ; butuh prefab masing-masing dari bullet, bolt, dan explosion
    {
        poolObjects = new List<PoolObject>();

        for (int i = 0; i < size; i++)
        {
            foreach(GameObject go in prefabs)
            {
                poolObjects.Add(Instantiate(go, transform).GetComponent<PoolObject>());
            }
        }
    }

    public PoolObject requestObject(PoolObjectType type) //digunakan untuk mencari pada list yang kita punya dengan tipe tertentu, ada yang belom aktif, jika blom aktif maka akan dikembalikan
    {
        foreach (PoolObject po in poolObjects)
        {
            if (po.type == type && !po.isActive()) // tanda seru artinya invert / kebalikannya, maka tidak aktif
            {
                return po;
            }
        }
        return null;
    }
    
    public static ObjectPool GetInstance()
    {
        return instance;
    }

    public void deactivateAllObject()
    {
        foreach (PoolObject po in poolObjects)
        {
            po.deactivate();
        }
    }
}
