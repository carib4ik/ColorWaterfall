using System.Collections;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private int gridSize;
    [SerializeField] private float spacing;
    [SerializeField] private float spawnDelay;

    public GameObject[,] Grid { get; private set; }

    private void Awake()
    {
        Grid = new GameObject[gridSize, gridSize];
        
        StartCoroutine(SpawnGrid());
    }

    private IEnumerator SpawnGrid()
    {
        for (var y = 0; y < gridSize; y++)
        {
            for (var x = 0; x < gridSize; x++)
            {
                var spawnPosition = new Vector3(transform.position.x + x * spacing,
                    transform.position.y - y * spacing, 0);
                
                Grid[y, x] = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}