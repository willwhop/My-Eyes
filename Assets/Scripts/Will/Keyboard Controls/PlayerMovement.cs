using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Made by William Hopton
public class PlayerMovement : MonoBehaviour
{
    public Transform Player;
    private float speed = 10;
    Rigidbody rb;
    public Camera cam1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetButtonDown("Shift")) {
        //    speed = 20;
        //}
        //else {
        //    speed = 100;
        //}
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Vector3 Movement =Player.forward * Vertical + Player.right * Horizontal;
        if (cam1.enabled == true) {
            rb.AddForce(Movement - rb.velocity);
        }
        
    }
}
