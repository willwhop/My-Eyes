using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera3rdPersonRotating : MonoBehaviour
{
    public Transform InvisRota;
    public Camera cam;
    private float speed = 100;
    Vector3 Rotating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A)) {
            //rotates camera around the character in 3rd person
            Rotating.y = 10;
            InvisRota.Rotate(Rotating, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            Rotating.y -= 10;
            InvisRota.Rotate(Rotating, speed * Time.deltaTime);
        }
    }
}
