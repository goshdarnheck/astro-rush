using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBar : MonoBehaviour {

    [SerializeField] int power = 0;
    [SerializeField] int powerLimit = 100;
    [SerializeField] int powerLevel = 0;
    GameObject cube;
    Transform parentForFX;
    [SerializeField] GameObject powerFX;
    PlayerController playerController;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        cube = gameObject.transform.GetChild(0).gameObject;
        parentForFX = FindObjectOfType<RuntimeSpawn>().transform;
        UpdateTheCube();
    }

    private void Update() {
        UpdateTheCube();
    }

    public void Reset() {
        power = 0;
        powerLevel = 0;
        powerLimit = 100;
    }

    public void ReloadPlayerObject() {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void PowerUp(int additionalPower) {
        power += additionalPower;

        if (power >= powerLimit) {
            powerLevel++;
            powerLimit = (powerLimit * 2) * powerLevel;
            power = 0;
            playerController.PowerUp(powerLevel);

            var position = transform.localPosition + transform.right * 5f;
            GameObject fx = Instantiate(powerFX, position, Quaternion.identity);
            fx.transform.parent = parentForFX;
        }
    }

    private void UpdateTheCube() {
        float powerPercentage = (float)power / (float)powerLimit * 100f;

        cube.transform.localScale = new Vector3(powerPercentage / 10f, 1f, 0.3f);
    }
}
