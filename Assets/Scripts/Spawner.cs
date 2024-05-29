using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _reduction = 2f;

    private int _minQuantity = 2;
    private int _maxQuantity = 7;
    private readonly int _maxRandom = 100;

    public void Split(Box box)
    {
        GameObject newBox;
        Exploder exploder = new Exploder();

        if (Random.Range(0, _maxRandom) <= box.GetSpawnChance())
        {
            box.transform.localScale /= _reduction;
            box.SetSpawnChance(box.GetSpawnChance() / _reduction);

            for (int i = 0; i < Random.Range(_minQuantity, _maxQuantity); i++)
            {
                newBox = Instantiate(box.gameObject, box.transform.position, box.transform.rotation);
                exploder.SetExplosionBoxes(newBox.GetComponent<Rigidbody>());
            }

            exploder.Explode();
        }
    }
}