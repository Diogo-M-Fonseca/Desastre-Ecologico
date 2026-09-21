using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]private int duration = 60;
    [SerializeField]private int timeRemaining;
    [SerializeField]private bool isCountingDown = false;

    private void BeginTimer()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    private void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
        }
    }

    private void Start()
    {
        BeginTimer();
        if (timeRemaining <= 0)
        {
            FireStarter fireStarter = FindAnyObjectByType<FireStarter>();
            fireStarter.StartFire();
            Destroy(gameObject);
        }
    }
}
