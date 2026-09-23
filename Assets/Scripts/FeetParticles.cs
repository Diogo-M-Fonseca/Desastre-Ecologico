using UnityEngine;

public class FeetParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    void OnTriggerEnter(Collider collision)
    {
        particles.Play();
    }
}
