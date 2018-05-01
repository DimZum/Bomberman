using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {

    public Tilemap tilemap;

    Tile tile;
    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionPrefab;

    public void Explode(Vector2 worldPos) {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
        // Top cell
        if (ExplodeCell(originCell + new Vector3Int(1, 0, 0))) {
            // Explode the next cell
        }

        // Right cell
        if (ExplodeCell(originCell + new Vector3Int(0, 1, 0))) {
            // Explode the next cell
        }

        // Bottom cell
        if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0))) {
            // Explode the next cell
        }

        // Left cell
        if (ExplodeCell(originCell + new Vector3Int(0, -1, 0))) {
            // Explode the next cell
        }

    }

    bool ExplodeCell(Vector3Int cell) {
        Tile tile = tilemap.GetTile<Tile>(cell);

        if (tile == wallTile) {
            return false;
        }

        if (tile == destructibleTile) {
            // Remove the tile
            tilemap.SetTile(cell, null);
        }

        // Create an explosion
        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, pos, Quaternion.identity);

        return true;
    }
}
