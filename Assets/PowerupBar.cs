using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBar : MonoBehaviour {

    [SerializeField] int power = 0;
    [SerializeField] int powerLimit = 100;
    [SerializeField] int powerLevel = 0;
    GameObject cube;
    PlayerController playerController;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        cube = gameObject.transform.GetChild(0).gameObject;
        UpdateTheCube();
    }

    private void Update() {
        UpdateTheCube();
    }

    public void Reset() {
        playerController = FindObjectOfType<PlayerController>();
        power = 0;
        powerLevel = 0;
        powerLimit = 100;
    }

    public void powerUp(int additionalPower) {
        power += additionalPower;

        if (power >= powerLimit) {
            powerLevel++;
            powerLimit = (powerLimit * 2) * powerLevel;
            print("powerLimit: " + powerLimit);
            power = 0;
            playerController.PowerUp(powerLevel);

            // TODO - particle effect fun thing and satisfying sfx
        }
    }

    private void UpdateTheCube() {
        float powerPercentage = (float)power / (float)powerLimit * 100f;

        cube.transform.localScale = new Vector3(powerPercentage / 10f, 1f, 0.3f);
    }
}
