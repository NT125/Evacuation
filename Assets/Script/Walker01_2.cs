using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Walker01_2 : MonoBehaviour
{
    public Tilemap tilemap;        // El Tilemap
    public TileBase tile;          // El tile 
    public Color color = new Color(0, 0, 1, 0.5f); // Color del caminante

    private Vector3Int pos;        // Posición actual del caminante
    private int tileLimit;         // Límite de tiles a colocar

    void Start()
    {
        tileLimit = Random.Range(50, 100);
        pos = new Vector3Int(0, 0, 0);

        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        int placedTiles = 0; // Contador de tiles colocados
        while (placedTiles < tileLimit)
        {
            int dir = Random.Range(0, 4); // 0: arriba, 1: derecha, 2: abajo, 3: izquierda
            Vector3Int newPos = pos;

            switch (dir)
            {
                case 0: newPos.y++; break; // Mover hacia arriba
                case 1: newPos.x++; break; // Mover hacia la derecha
                case 2: newPos.y--; break; // Mover hacia abajo
                case 3: newPos.x--; break; // Mover hacia la izquierda
            } 
            
            // Verificar si la nueva posición ya tiene un tile
            if (tilemap.GetTile(newPos) == null)
            {

                // Actualizar el Tilemap en la nueva posición
                tilemap.SetTile(newPos, tile);

                // Mover el caminante a la nueva posición
                pos = newPos;

                // Mostrar el caminante
                Display();

                // Incrementar el contador de tiles colocados
                placedTiles++;
            }

            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("Número de tiles colocados: " + tileLimit);
    }
    
    void Display()
    {
        // Colorear el tilemap en la posición actual del caminante
        // N: el Tilemap no soporta SetColor directamente, buscar otra forma
    }
}
