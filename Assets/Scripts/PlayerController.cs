using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 3f;

    [SerializeField] int health = 5;
    [SerializeField] int healthLimit = 10;
    [SerializeField] float spinSpeedFactor = 10f;
    [SerializeField] float spinSpeedBound = 500f;

    [SerializeField] GameObject gunSlotTop = null;
    [SerializeField] GameObject gunSlotBottom = null;

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parentForFX;

    GameObject gunTop = null;
    GameObject gunBottom = null;
    GameObject gunBlueV1;
    GameObject gunGreenV1;

    bool isControlEnabled = true;
    float spin = 0f;
    ScoreBoard scoreBoard;
    PowerupBar powerupBar;
    LevelManager levelManager;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PowerUp(int level) {
        switch (level) {
            case 0:
                gunSlotTop = gunBlueV1;
                gunSlotBottom = null;
                break;
            case 1:
                gunSlotTop = gunBlueV1;
                gunSlotBottom = gunBlueV1;
                break;
            case 2:
                gunSlotTop = gunGreenV1;
                gunSlotBottom = gunBlueV1;
                break;
            case 3:
                gunSlotTop = gunGreenV1;
                gunSlotBottom = gunGreenV1;
                break;

        }

        SetGunTop();
        SetGunBottom();
    }

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.SetHealth(health);

        gunBlueV1 = Resources.Load("Gun Blue v1") as GameObject;
        gunGreenV1 = Resources.Load("Gun Green v1") as GameObject;

        SetGuns();

        //gunSlotBottom = Resources.Load("Gun Green v1") as GameObject;
        //Invoke("SetGunBottom", 2f);

        powerupBar = FindObjectOfType<PowerupBar>();
        powerupBar.ReloadPlayerObject();

        levelManager = FindObjectOfType<LevelManager>();
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
        scoreBoard.SetHealth(health);
        if (isControlEnabled) {
            ProcessRotation();
        }
    }

    void OnPlayerHit() { // called by string reference
        health--;
        scoreBoard.SetHealth(health);

        if (health < 1) {
            isControlEnabled = false;
            Invoke("ReloadGame", levelLoadDelay);
            KillPlayer();
        }
    }

    public void PlayerHealthUp() {
        health++;

        if (health > healthLimit) {
            health = healthLimit;
        }

        scoreBoard.SetHealth(health);
    }

    void KillPlayer() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentForFX;

        transform.Translate(Vector3.down * 90);
    }

    void ReloadGame() {
        levelManager.LoadFirstScene();
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
