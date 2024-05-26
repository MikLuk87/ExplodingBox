using UnityEngine;

public class Painter : MonoBehaviour
{
    private static System.Random s_random = new System.Random();

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

        return colors[s_random.Next(0, colors.Length)];
    }
}
