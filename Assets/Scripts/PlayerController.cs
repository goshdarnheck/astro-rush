using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField] float spinSpeedFactor = 10f;
    [SerializeField] float spinSpeedBound = 500f;

    [SerializeField] GameObject gunSlotTop = null;
    [SerializeField] GameObject gunSlotBottom = null;

    GameObject gunTop = null;
    GameObject gunBottom = null;

    bool isControlEnabled = true;
    float spin = 0f;

    void Start () {
        SetGuns();

        //gunSlotBottom = Resources.Load("Gun Purple v1") as GameObject;
        //Invoke("SetGunBottom", 2f);
    }

    private void SetGuns() {
        SetGunTop();
        SetGunBottom();
    }

    private void SetGunBottom() {
        Destroy(gunBottom);

        if (gunSlotBottom != null) {
            var position = transform.localPosition + transform.forward * -0.65f;
            var rotation = transform.rotation * Quaternion.Euler(0, 180, 0);

            gunBottom = Instantiate(gunSlotBottom, position, rotation, gameObject.transform) as GameObject;
        }
    }

    private void SetGunTop() {
        Destroy(gunTop);

        if (gunSlotTop != null) {
            var position = transform.localPosition + transform.forward * 0.65f;

            gunTop = Instantiate(gunSlotTop, position, transform.rotation, gameObject.transform) as GameObject;
        }
    }

    void Update () {
        if (isControlEnabled) {
            ProcessRotation();
        }
    }

    void OnPlayerDeath() { // called by string reference
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
