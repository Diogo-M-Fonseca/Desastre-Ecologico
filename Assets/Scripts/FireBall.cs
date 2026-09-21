using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float lifetime = 5f;
    private FireStarter fireStarter;

    public void Init(float lifetime, FireStarter fireStarter)
    {
        this.lifetime = lifetime;
        this.fireStarter = fireStarter;
    }

    private void Start()
    {
        Invoke(nameof(EndOfLife), lifetime);
    }

    private void EndOfLife()
    {
        if (fireStarter != null)
            fireStarter.StartFire();

        Destroy(gameObject);
    }
}
