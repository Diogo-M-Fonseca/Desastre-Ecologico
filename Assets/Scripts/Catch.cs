using System;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public event Action Extinguish;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out PlayerCollider limb))
        {
            Extinguish?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
