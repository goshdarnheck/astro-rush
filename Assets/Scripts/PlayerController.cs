using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField] float spinSpeedFactor = 10f;
    [SerializeField] float spinSpeedBound = 500f;

    bool isControlEnabled = true;
    float spin = 0f;

    void Start () {
		
	}

    void Update () {
        if (isControlEnabled) {
            ProcessRotation();
        }
    }

    private void OnPlayerDeath() { // called by string reference
        isControlEnabled = false;
    }

    void ProcessRotation() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        spin += xThrow * spinSpeedFactor;

        if (spin > spinSpeedBound) {
            spin = spinSpeedBound;
        } else if (spin < -Mathf.Abs(spinSpeedBound)) {
            spin = -Mathf.Abs(spinSpeedBound);
        }

        transform.Rotate(new Vector3(0, spin, 0), Mathf.Abs(spin) * Time.deltaTime);
    }
}
