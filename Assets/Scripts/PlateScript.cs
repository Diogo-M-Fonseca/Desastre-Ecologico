using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private int plateNumber;
    private PlateSpawner plateSpawner;
    private bool _isPressed;

    private void Start()
    {
        plateSpawner = GetComponentInParent<PlateSpawner>();

        plateSpawner.LevelDone += Pressing;
        plateSpawner.LevelDone += Unpressing;
    }

    private void Pressing() => _isPressed = true;
    private void Unpressing() => _isPressed = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider _))
        {
            FindAnyObjectByType<ChestScript>().ActivatePlate(plateNumber);
            Debug.Log("Plate " + plateNumber + " activated.");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider _))
        {
            FindAnyObjectByType<ChestScript>().DeactivatePlate(plateNumber);
            Debug.Log("Plate " + plateNumber + " deactivated.");
        }
    }
}
