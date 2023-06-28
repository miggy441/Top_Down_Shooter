using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float playerSpeed;
    public 
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontal_input * playerSpeed, body.velocity.y);

        
        if (horizontal_input > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontal_input < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        float vertical_input = Input.GetAxis("Vertical");

        body.velocity = new Vector2(horizontal_input * playerSpeed, vertical_input * playerSpeed);

        
        if (vertical_input > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(vertical_input < -0.01f)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}