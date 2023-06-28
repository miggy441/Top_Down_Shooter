using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script yang menggerakkan player

[RequireComponent(typeof(Moveable))] //Untuk memastikan setiap menambahkan playerController, harus ada component Movable
public class PlayerController : MonoBehaviour
{
    public InputHandler inputHandler; //mengakses inputHandler script dengan menggunakan Unity Action
    
    private Moveable moveable;

    void Awake()
    {
        moveable = GetComponent<Moveable>(); // Script Moveable diakses seperti ini karena Script Player Controller dan Moveable berada pada gameObject yang sama yaitu Ship
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSetDirection (Vector2 direction)
    {
        //Debug.Log("Test 123" + direction);
        moveable.setDirection(direction );
    }

    private void OnEnable() //setiap player controller diaktifkan
    {
        inputHandler.OnMoveAction += OnSetDirection;
        //inputHandler.OnSetDirectionAction += OnSetDirection; //Kelas ini akan mengsubscribe function test123 ke dalam unit action OnSetDirectionAction
    }

    private void OnDisable() //kalo player controller dinonatifkan
    {
        inputHandler.OnMoveAction -= OnSetDirection; //Function test123 tidak dipanggil sehingga tidak terjadi nol
    }

}
