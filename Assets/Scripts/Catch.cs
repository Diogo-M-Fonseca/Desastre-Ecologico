using System;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public event Action Extinguish;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out PlayerCollider limb))
        {
            Extinguish?.Invoke();
            AudioSource.PlayClipAtPoint(clip, transform.position);
            gameObject.SetActive(false);
        }
    }
}
