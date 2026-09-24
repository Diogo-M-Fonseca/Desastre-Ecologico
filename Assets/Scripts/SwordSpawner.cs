using UnityEngine;

public class SwordSpawner : MonoBehaviour
{
    [SerializeField] private GameObject swordPrefab;
    public void SpawnSword()
    {
       swordPrefab.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCollider _))
        {
            SpawnSword();
        }
    }
}
