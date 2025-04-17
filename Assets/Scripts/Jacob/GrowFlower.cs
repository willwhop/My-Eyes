using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFlower : MonoBehaviour {

    Vector3 min = Vector3.zero, max = new Vector3(1,1,1);

    bool canGrow, canShrink;

    // Update is called once per frame
    void Update() {
        if (canGrow == true && canShrink == false) {
            gameObject.transform.localScale = Vector3.Lerp(min, max, 1 * Time.deltaTime);
        }
        else {
            gameObject.transform.localScale = Vector3.Lerp(max, min, 1 * Time.deltaTime);
        }
    }

    public void Grow() {
        canGrow = true;
        canShrink = false;
    }

    public void Shrink() {
        canGrow = false;
        canShrink = true;
    }
}
