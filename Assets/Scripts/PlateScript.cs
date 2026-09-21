using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private int plateNumber;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == FindAnyObjectByType<PlayerLogic>().gameObject)
        {
            FindAnyObjectByType<ChestScript>().ActivatePlate(plateNumber);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == FindAnyObjectByType<PlayerLogic>().gameObject)
        {
            FindAnyObjectByType<ChestScript>().DeactivatePlate(plateNumber);
        }
    }
}
