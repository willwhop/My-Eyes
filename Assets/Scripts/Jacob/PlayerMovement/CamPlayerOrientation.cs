using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CamPlayerOrientation: MonoBehaviour {

    [Header("References")]
    public InputActionProperty leftJoystick;

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {

        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        Vector2 LJoyInput = leftJoystick.action.ReadValue<Vector2>();
        Vector3 inputDir = orientation.forward * LJoyInput.y + orientation.right * LJoyInput.x;

        if (inputDir != Vector3.zero) {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotSpeed);
        }
    }
}
