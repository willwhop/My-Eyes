using UnityEngine;
using UnityEngine.InputSystem;

public class CamPlayerOrientation : MonoBehaviour {

    [SerializeField] private InputActionProperty leftJoystick;

    [SerializeField] private Transform player, playerObj, orientation;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float rotSpeed;

    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
        if (rb != null) {
            rb = rb.GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (rb != null) {
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
}
