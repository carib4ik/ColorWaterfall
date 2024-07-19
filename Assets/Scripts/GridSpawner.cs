using System.Collections;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject squarePrefab; // Префаб квадрата
    public int gridSize; // Размер сетки
    public float spacing; // Расстояние между квадратами
    public float spawnDelay; // Задержка между спавнами

    private void Awake()
    {
        StartCoroutine(SpawnGrid());
    }

    private IEnumerator SpawnGrid()
    {
        for (var y = 0; y < gridSize; y++)
        {
            for (var x = 0; x < gridSize; x++)
            {
                // Рассчитываем позицию для нового квадрата
                var spawnPosition = new Vector3(transform.position.x + x * spacing, transform.position.y - y * spacing, 0);
                // Создаем новый квадрат
                Instantiate(squarePrefab, spawnPosition, Quaternion.identity);
                // Ждем перед созданием следующего квадрата
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}