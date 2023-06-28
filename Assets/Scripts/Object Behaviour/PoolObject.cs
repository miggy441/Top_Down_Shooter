using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PoolObjectType // masing2 objek diberikan enum sesuai dengan jenisnya
{
    BULLET, BOLT, EXPLOSION
}

public class PoolObject : MonoBehaviour
{
    public PoolObjectType type;

    void Start()
    {
        deactivate();
    }

    public void activate(Vector3 position, Quaternion rotation) //Function untuk mengaktifkan dan menonaktifkan
    {
        gameObject.SetActive(true);

        transform.position = position;
        transform.rotation = rotation;
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    internal bool isActive()
    {
        return gameObject.activeInHierarchy;
    }
}
