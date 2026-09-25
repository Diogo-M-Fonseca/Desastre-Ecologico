using System;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private int plateNumber;
    public event Action IsPressed;
    public event Action IsUnpressed;
    private PlayerCollider playerLimb;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider limb) && playerLimb == null)
        {
            playerLimb = limb; 
            IsPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerCollider limb))
        {
            if (limb == playerLimb)
            {
                IsUnpressed.Invoke();
                playerLimb = null;
            }
        }
    }
}
