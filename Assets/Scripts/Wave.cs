using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] int remaining = 1;
    [SerializeField] float rate = 1f;

    void Start() {
        StartCoroutine(EmitEnemies());
    }

    IEnumerator EmitEnemies() {
        while (remaining > 0) {
            GameObject asdf = Instantiate(enemy, transform.position, Quaternion.identity);
            EnemyController thing = asdf.GetComponent<EnemyController>();

            //thing.speed = 2f;

            remaining--;
            yield return new WaitForSeconds(rate);
        }
    }
}
