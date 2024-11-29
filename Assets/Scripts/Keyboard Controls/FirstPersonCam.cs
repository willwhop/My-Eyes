using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public Camera cam;
    public Transform character;
    public Transform rotTransform;
    public float speed;
    private float Yrot;
    private float Xrot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = character.position;

        float mousex = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        Xrot -= mousey;
        Yrot += mousex;
        Xrot = Mathf.Clamp(Xrot, 0, 0);
        rotTransform.rotation = Quaternion.Euler(0, Yrot, 0);
        cam.transform.rotation = Quaternion.Euler(Xrot, Yrot, 0);
    }
}
