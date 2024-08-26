using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class Walker01_1 : MonoBehaviour
{
    public Tilemap tilemap;        // El Tilemap
    public TileBase tile;          // El tile 
    public Color color = new Color(0, 0, 1, 0.5f); // Color del caminante

    private Vector3Int pos;        // Posición actual del caminante
    private int tileLimit = 20;    // Cantidad de elementos no cero

    void Start()
    {
        pos = new Vector3Int(0, 0, 0);

        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        int moves = 0;
        while (moves < tileLimit)
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

                // Actualizar el Tilemap en la nueva posición
                tilemap.SetTile(newPos, tile);

                // Mover el caminante a la nueva posición
                pos = newPos;

                // Mostrar el caminante
                Display();

                // Incrementar el contador de movimientos
                moves++;

            yield return new WaitForSeconds(0.2f);
        }

        Debug.Log("Número objetivo de tiles colocados: " + tileLimit);
    }

    void Display()
    {
        // Colorear el tilemap en la posición actual del caminante
        // N: el Tilemap no soporta SetColor directamente, buscar otra forma
    }

}
