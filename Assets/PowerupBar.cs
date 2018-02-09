using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBar : MonoBehaviour {

    [SerializeField] int power = 1;
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

    public void powerUp(int additionalPower) {
        power += additionalPower;

        if (power >= powerLimit) {
            powerLevel++;
            power = 1;
            // TODO - particle effect fun thing and satisfying sfx
            print("Powered up!");
            playerController.PowerUp(powerLevel);
        }
    }

    private void UpdateTheCube() {
        cube.transform.localScale = new Vector3(power / 10f, 1f, 0.3f);
    }
}
