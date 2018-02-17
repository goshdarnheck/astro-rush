using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupWave : MonoBehaviour {

    [SerializeField] GameObject powerup;
    [SerializeField] public int remaining = 1;
    [SerializeField] float rate = 1f;
    [SerializeField] float delay = 0f;
    [SerializeField] float lifeTime = 5f;

    void Start() {
        StartCoroutine(EmitPowerups());
    }

    IEnumerator EmitPowerups() {
        yield return new WaitForSeconds(delay);

        while (remaining > 0) {
            GameObject powerupInstance = Instantiate(powerup, transform.position, Quaternion.identity);
            Powerup powerupScript = powerupInstance.GetComponent<Powerup>();
            powerupScript.lifeTime = lifeTime;

            remaining--;

            yield return new WaitForSeconds(rate);
        }
    }
}
