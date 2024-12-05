using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject camOffset;

    [SerializeField] private InputActionProperty crouch;
    [SerializeField] private InputActionProperty jump;

    private float normalHeight, crouchHeight;

    // Start is called before the first frame update
    void Start() {
       // camOffset.transform.position = normalHeight.transform.position;
    }

    // Update is called once per frame
    void Update() {
        //if (crouch.action.ReadValue<bool>() == true) {
        //    camOffset.transform.position = Vector3(0, 0, 0);
        //}
        //else {

        //}
    }
}
