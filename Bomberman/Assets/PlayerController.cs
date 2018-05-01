using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public Vector3 pos;
    public float vel = .05f;

    public Tilemap tilemap;
    public Tile cell;

	// Update is called once per frame
	void Update () {
        pos = transform.position;

		if (Input.GetKey(KeyCode.W)) {
            pos.y += vel;
        }

        if (Input.GetKey(KeyCode.A)) {
            pos.x -= vel;
        }

        if (Input.GetKey(KeyCode.S)) {
            pos.y -= vel;
        }

        if (Input.GetKey(KeyCode.D)) {
            pos.x += vel;
        }

        transform.SetPositionAndRotation(pos, Quaternion.identity);
    }
}
