using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script untuk pergerakkan coin agar bergerak ke arah player

[RequireComponent(typeof(Moveable))] //Untuk memastikan setiap menambahkan MoveTowardsPlayer, harus ada component Movable

public class MoveTowardsPlayer : MonoBehaviour
{
    private Moveable moveable;
    
    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }
    void Start()
    {
        moveable.setDirection(getDirection());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getDirection()
    {
        Vector3 dir;
        dir = GameManager.GetInstance().getPlayerPosition() - transform.position;
        dir = dir.normalized;

        return dir;
    }
}
