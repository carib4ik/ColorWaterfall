using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] private float colorChangeDelay;
    [SerializeField] private float transitionDuration;

    public void ChangeColor()
    {
        StartCoroutine(ChangeColors());
    }

    private IEnumerator ChangeColors()
    {
        var newColor = GetRandomColor();

        for (var y = 0; y < _gridSpawner.Grid.GetLength(1); y++)
        {
            for (var x = 0; x < _gridSpawner.Grid.GetLength(0); x++)
            {
                var renderer = _gridSpawner.Grid[y, x].GetComponent<Renderer>();
                // renderer.material.color = newColor;

                StartCoroutine(ColorChanging(renderer, newColor));
                
                yield return new WaitForSeconds(colorChangeDelay);
            }
        }
    }

    private IEnumerator ColorChanging(Renderer renderer, Color newColor)
    {
        var initialColor = renderer.material.color;
        var elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            renderer.material.color = Color.Lerp(initialColor, newColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}