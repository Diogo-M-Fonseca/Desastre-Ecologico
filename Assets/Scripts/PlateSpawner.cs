using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platePrefabs;
    [SerializeField] private Collider floor;
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField, Min(1)] private int maxAttempts = 30;
    [SerializeField] private float heightOffset = 0f;
    [SerializeField] private bool alignToGround = false;
    [SerializeField] private bool randomYaw = true;
    [SerializeField] private PlayerLogic player;

    private int _manyPressed = 0;

    private void Start()
    {
        if (spawnOnStart)
            SpawnRandom();
    }

    public List<GameObject> SpawnRandom()
    {
        List<GameObject> spawned = new List<GameObject>();

        if (floor == null)
            return spawned;

        foreach (GameObject prefab in platePrefabs)
        {
            if (prefab == null) continue;
            if (!TryGetRandomGroundPoint(out RaycastHit hit)) continue;

            Vector3 position = hit.point + hit.normal * heightOffset;

            Quaternion rotation = alignToGround
                ? Quaternion.FromToRotation(Vector3.up, hit.normal)
                : Quaternion.identity;

            if (randomYaw)
                rotation *= Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);

            GameObject newPlate = Instantiate(prefab, position, rotation, transform);
            spawned.Add(newPlate);
            PlateScript script = newPlate.GetComponent<PlateScript>();
            script.IsPressed += VerifyComplete;
            script.IsUnpressed += RemoveComplete;
        }

        return spawned;
    }

    private void VerifyComplete()
    {
        _manyPressed++;
        Debug.Log($"Pressed {_manyPressed} of {platePrefabs.Length}");

        if (_manyPressed == platePrefabs.Length)
        {
            player.GameFinished();
        }
    }

    private void RemoveComplete()
    {
        _manyPressed--;
    }

    private bool TryGetRandomGroundPoint(out RaycastHit hit)
    {
        Bounds b = floor.bounds;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 origin = new Vector3(
                UnityEngine.Random.Range(b.min.x, b.max.x),
                b.max.y + 1f,
                UnityEngine.Random.Range(b.min.z, b.max.z));

            if (floor.Raycast(new Ray(origin, Vector3.down), out hit, b.size.y + 2f))
                return true;
        }

        hit = default;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        if (floor == null) return;

        Gizmos.color = new Color(0f, 1f, 0.3f, 0.6f);
        Gizmos.DrawWireCube(floor.bounds.center, floor.bounds.size);
    }
}