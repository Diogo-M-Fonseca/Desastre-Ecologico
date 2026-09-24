using System;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private int plateNumber;
    public event Action IsPressed;
    public event Action IsUnpressed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider _))
        {
            FindAnyObjectByType<ChestScript>().ActivatePlate(plateNumber);
            Debug.Log("Plate " + plateNumber + " activated.");

            IsPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider _))
        {
            FindAnyObjectByType<ChestScript>().DeactivatePlate(plateNumber);
            Debug.Log("Plate " + plateNumber + " deactivated.");

            IsUnpressed.Invoke();
        }
    }
}
