using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapRandomSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] spawnableTiles;
    public GameObject[] prefabsToSpawn;
    public int maxObjectsToSpawn = 10;

    private void Awake()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        int objectsSpawned = 0;

        while (objectsSpawned < maxObjectsToSpawn)
        {
            int randomX = Random.Range(bounds.min.x, bounds.max.x);
            int randomY = Random.Range(bounds.min.y, bounds.max.y);

            Vector3Int randomPosition = new Vector3Int(randomX, randomY, 0);
            TileBase tile = allTiles[randomPosition.x - bounds.xMin + (randomPosition.y - bounds.yMin) * bounds.size.x];

            if (tile != null && IsTileInLayer(tile))
            {
                GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
                Instantiate(prefabToSpawn, tilemap.CellToWorld(randomPosition), Quaternion.identity);
                objectsSpawned++;
            }
        }
    }

    private bool IsTileInLayer(TileBase tile)
    {
        foreach (TileBase spawnableTile in spawnableTiles)
        {
            if (tile == spawnableTile)
            {
                return true;
            }
        }
        return false;
    }
}