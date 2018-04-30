using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float countdown = 2f;
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if (countdown <= 0) {
            // Should use singleton instead
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Debug.Log("BOOOM!");
            Destroy(gameObject);
        }
	}
}
