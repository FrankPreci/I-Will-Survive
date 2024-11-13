using UnityEngine;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab of the tile
    public Vector2 tileSize = new Vector2(1, 1); // Size of each tile
    private Camera mainCamera;
    private HashSet<Vector2Int> generatedTiles = new HashSet<Vector2Int>();

    void Start()
    {
        mainCamera = Camera.main;
        GenerateTilesInView();
    }

    void Update()
    {
        GenerateTilesInView();
    }

    void GenerateTilesInView()
    {
        // Get camera boundaries in world coordinates
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Calculate the range of tiles based on tile size
        int startX = Mathf.FloorToInt(bottomLeft.x / tileSize.x);
        int endX = Mathf.CeilToInt(topRight.x / tileSize.x);
        int startY = Mathf.FloorToInt(bottomLeft.y / tileSize.y);
        int endY = Mathf.CeilToInt(topRight.y / tileSize.y);

        // Generate tiles only within the camera's view
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                Vector2Int tilePosition = new Vector2Int(x, y);

                // Check if tile has already been generated
                if (!generatedTiles.Contains(tilePosition))
                {
                    GenerateTile(tilePosition);
                    generatedTiles.Add(tilePosition);
                }
            }
        }
    }

    void GenerateTile(Vector2Int gridPosition)
    {
        // Calculate world position of the tile
        Vector3 worldPosition = new Vector3(gridPosition.x * tileSize.x, gridPosition.y * tileSize.y, 0);

        // Instantiate the tile at the calculated world position
        Instantiate(tilePrefab, worldPosition, Quaternion.identity, transform);
    }
}
