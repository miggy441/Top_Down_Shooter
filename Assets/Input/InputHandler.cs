using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;// Agar dapat menggunakan unity action agar bisa menghubungkan script ini dengan script player Controller

//Script ini untuk menyambungkan antara script player controller dengan custom input yang dimiliki
// Berfungsi untuk handle input yang diterima dari input action dan menjalankan function on enable, on disable, dan OnSetDirection

[CreateAssetMenu(fileName = "Input Handler", menuName = "InputHandler")] // Karena sifat script ini Scriptable, maka perlu ditambahkan menu untuk menambahkan assetnya
                                                                         // Nanti muncul menu baru bernama Input Handler waktu klik kanan di di folder Input untuk add something new
public class InputHandler : ScriptableObject, CustomInput.IGameplayActions

//Input handler akan dibuat sebagai scriptable object, dimana nanti di playerController, cukup dibuat 1 
//variabel public kemudian bisa dimasukkan aset input handler ke player controller

{
    private CustomInput Input;

    public UnityAction<Vector2> OnMoveAction; //variabel yang menampung class, bukan variabel ; Setiap function yang subscribe ke Unity Action ini harus punya parameter Vector 2
    public UnityAction OnPauseAction;

    private void OnEnable()
    {
        if (Input == null)
        {
            Input = new CustomInput();
        }

        Input.Gameplay.SetCallbacks(this);

        Input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        Input.Gameplay.Disable();
    }

    

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnPauseAction?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("set direction " + context.ReadValue<Vector2>() + " " + context.phase);
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled){
            
            OnMoveAction?.Invoke(context.ReadValue<Vector2>()); // tanda tanya artinya kalo OnSetDirectionAction ada isinya, maka di invoke/dipanggil. Bila tidak ada isinya, maka tidak ada yang terjadi
                                                                        // Tipe data yang ingin  diread adalah Vector 2
        }
    }
}
