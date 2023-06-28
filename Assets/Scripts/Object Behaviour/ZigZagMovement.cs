using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class ZigZagMovement : MonoBehaviour
{
    private Moveable moveable;
    public float speed = 1;
    float frequency = 10.0f; // Speed of sine movement
    float magnitude = 0.5f; //  Size of sine movement

    Vector3 pos;
    Vector3 axis;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
        pos = transform.position;
        axis = transform.right;

    }

    void Update()
    {
        pos += Vector3.down * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}