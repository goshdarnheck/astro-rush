using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    enum Speed { stopped, slooow, sloow, slow, normal, fast, faster, fasterer };

    [SerializeField] GameObject enemy;
    [SerializeField] public int remaining = 1;
    [SerializeField] float rate = 1f;
    [SerializeField] Speed speed = Speed.slow;
    [SerializeField] int scoreValue = 1;
    [SerializeField] float delay = 0f;

    void Start() {
        StartCoroutine(EmitEnemies());
    }

    IEnumerator EmitEnemies() {
        yield return new WaitForSeconds(delay);

        while (remaining > 0) {
            GameObject enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
            EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();
            enemyController.speed = ConvertSpeedFloat(speed);
            enemyController.scoreValue = scoreValue;

            remaining--;

            yield return new WaitForSeconds(rate);
        }
    }

    private float ConvertSpeedFloat(Speed speed) {
        switch (speed) {
            case Speed.stopped: {
                    return 0f;
                }
            case Speed.slooow: {
                    return 1f;
                }
            case Speed.sloow: {
                    return 2f;
                }
            case Speed.slow: {
                    return 4f;
                }
            case Speed.normal: {
                    return 6f;
                }
            case Speed.fast: {
                    return 8f;
                }
            case Speed.faster: {
                    return 10f;
                }
            case Speed.fasterer: {
                    return 12f;
                }
        }

        return 1f;
    }
}
