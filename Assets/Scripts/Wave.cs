using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] public int remaining = 1;
    [SerializeField] float rate = 1f;
    [SerializeField] float speed = 5f;
    [SerializeField] int scoreValue = 1;
    [SerializeField] float delay = 0f;

    void Start() {
        StartCoroutine(EmitEnemies());
    }

    IEnumerator EmitEnemies() {
        while (remaining > 0) {
            GameObject enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
            EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();
            enemyController.speed = speed;
            enemyController.scoreValue = scoreValue;

            remaining--;

            yield return new WaitForSeconds(rate);
        }
    }
}
