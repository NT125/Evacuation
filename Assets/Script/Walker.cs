using UnityEngine;
using UnityEngine.Tilemaps;

public class Walker : MonoBehaviour
{
    public Tilemap tilemap;        // El TileMap
    public TileBase tile;          // El tile 
    public Color color = new Color(0, 0, 1, 0.39f); // Color del caminante 

    private Vector3Int pos;        // Posicion actual del caminante
    private int indexNonZero = 0;  // cantidad de elementos no cero

    void Start()
    {
        pos = new Vector3Int(0, 0, 0); // Posicion dentro del tilemap
        tilemap.SetColor(pos, color);  // Establecer el color , no funciona aun
    }

    void Update()
    {
        Move();
    }

    void Move()
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

            // Actualizar el tilemap en la nueva posición
            tilemap.SetTile(newPos, tile);

            // Mover el caminante a la nueva posición
            pos = newPos;

            // Mostrar el caminante
            //Display();

            // Verificar el conteo de tiles no nulos NO FUNSIONA
            // if (ContadorNoCeros() >= indexNonZero)
            // {
            //     Debug.Log("Matriz completada con " + CountNonZeroTiles() + " elementos diferentes de cero.");
            //     // Opcional: Desactivar el script o realizar alguna acción adicional
            //     this.enabled = false;
            // }
        
    }

    void Display()
    {
        // Colorear el tilemap en la posición actual del caminante
        // tilemap.SetColor(pos, color);
    }

    int ContadorNoCeros()
    {
        int count = 0;
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        foreach (TileBase tile in allTiles)
        {
            if (tile != null)
            {
                count++;
            }
        }

        return count;
    }
}
