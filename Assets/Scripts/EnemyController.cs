using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float speed = 5f;

	void Start() {
        
    }
	
	void Update() {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void OnParticleCollision(GameObject other) {
        var distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        if (distance < 30f) {
            KillEnemy();
        }
    }

    void KillEnemy() {
        Destroy(gameObject);
    }
}
