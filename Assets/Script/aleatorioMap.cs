using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class ProceduralTilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap; // El tileMap
    public TileBase tile;   // El tile

    void Start()
    {
        StartCoroutine(GenerateTilemap());
    }

    IEnumerator GenerateTilemap()
    {
        // Colocar un tile en una cuadrícula
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                tilemap.SetTile(position, tile);
                yield return new WaitForSeconds(0.5f); 
            }
        }

        // Colocar diferentes tiles en diferentes posiciones
        for (int i = 0; i < 10; i++)
        {
            Vector3Int position = new Vector3Int(i, i, 0);
            TileBase specificTile = (i % 2 == 0) ? tile : null;
            tilemap.SetTile(position, specificTile);
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
