using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public Vector3 pos;
    public Vector3 vel_x = new Vector3(1, 0, 0);
    public Vector3 vel_y = new Vector3(0, 1, 0);

    public Tilemap tilemap;
    public Tile wallTile;
    public Tile destructibleTile;

    // Update is called once per frame
    void Update () {
        pos = transform.position;

        // UP
		if (Input.GetKeyDown(KeyCode.W)) {
            if (HandleMoveAttempt(pos, vel_y)) {
                pos += vel_y;
            }
        }

        // LEFT
        if (Input.GetKeyDown(KeyCode.A)) {
            if (HandleMoveAttempt(pos, -vel_x)) {
                pos -= vel_x;
            }
        }

        // DOWN
        if (Input.GetKeyDown(KeyCode.S)) {
            if (HandleMoveAttempt(pos, -vel_y)) {
                pos -= vel_y;
            }
        }

        // RIGHT
        if (Input.GetKeyDown(KeyCode.D)) {
            if (HandleMoveAttempt(pos, vel_x)) {
                pos += vel_x;
            }
        }

        transform.SetPositionAndRotation(pos, Quaternion.identity);
    }

    // Collision detection
    bool HandleMoveAttempt(Vector3 pos, Vector3 dir) {
        Vector3Int cell = tilemap.WorldToCell(pos + dir);
        Tile tile = tilemap.GetTile<Tile>(cell);

        if (tile == wallTile) {
            return false;
        }

        if (tile == destructibleTile) {
            return false;
        }

        return true;
    }
}
