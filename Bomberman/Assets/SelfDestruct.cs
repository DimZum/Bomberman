using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    float countdownTimer = .5f;
	
    // Update is called once per frame
	void Update () {
        countdownTimer -= Time.deltaTime;

        if (countdownTimer <= 0) {
            Destroy(gameObject);
        }
	}
}
