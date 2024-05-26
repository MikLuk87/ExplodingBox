using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        var colors = new[] {
             Color.blue,
             Color.red,
             Color.green,
             Color.yellow};

        return colors[Random.Range(0, colors.Length)];
    }
}
