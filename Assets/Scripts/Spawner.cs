using UnityEngine;

public class Spawner : MonoBehaviour
{
    private readonly int _maxRandom = 100;
    private int _minQuantity = 2;
    private int _maxQuantity = 7;

    public void Spawn(Box box)
    {
        Exploder exploder = new Exploder();

        if (Random.Range(0, _maxRandom) <= box.SpawnChance())
        {
            for (int i = 0; i < Random.Range(_minQuantity, _maxQuantity); i++)
            {
                Instantiate(box.gameObject, box.transform.position, box.transform.rotation);
            }

            exploder.Explode();
        }
    }
}