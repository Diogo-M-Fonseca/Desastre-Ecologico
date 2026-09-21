using UnityEngine;

public class WandLogic : MonoBehaviour
{
    [SerializeField, Min(1)] private int shakesToFullCharge = 10;

    [SerializeField] private float minShakeDistance = 0.1f;

    [SerializeField] private float chargeSpeed = 3f;

    [SerializeField] private ParticleSystem chargeParticles;
    [SerializeField] private float maxEmissionRate = 80f;
    [SerializeField] private float maxEffectScale = 1.5f;
    [SerializeField] private Light chargeLight;
    [SerializeField] private float maxLightIntensity = 5f;

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireballSpeed = 15f;
    [SerializeField] private float fireballLifetime = 5f;

    [SerializeField] private FireStarter fireStarter;

    private float shakes;
    private float charge;
    private float lastY;
    private int direction;
    private float distance;
    private bool counted;
    private bool fired;

    private void Start()
    {
        lastY = transform.position.y;
        if (chargeParticles != null) chargeParticles.Play();
        UpdateEffects();
    }

    private void Update()
    {
        if (fired) return;

        DetectShake();

        float target = Mathf.Clamp01(shakes / shakesToFullCharge);
        charge = Mathf.MoveTowards(charge, target, chargeSpeed * Time.deltaTime);

        UpdateEffects();

        if (charge >= 1f)
            Fire();
    }

    private void DetectShake()
    {
        float y = transform.position.y;
        float delta = y - lastY;
        lastY = y;

        if (Mathf.Approximately(delta, 0f)) return;

        int newDirection = delta > 0f ? 1 : -1;

        if (newDirection != direction)
        {
            direction = newDirection;
            distance = 0f;
            counted = false;
        }

        distance += Mathf.Abs(delta);

        if (!counted && distance >= minShakeDistance)
        {
            counted = true;
            shakes++;
        }
    }

    private void UpdateEffects()
    {
        if (chargeParticles != null)
        {
            var emission = chargeParticles.emission;
            emission.rateOverTime = maxEmissionRate * charge;
            chargeParticles.transform.localScale = Vector3.one * (maxEffectScale * charge);
        }

        if (chargeLight != null)
        {
            chargeLight.enabled = charge > 0f;
            chargeLight.intensity = maxLightIntensity * charge;
        }
    }

    private void Fire()
    {
        fired = true;

        Transform origin = firePoint != null ? firePoint : transform;

        if (fireballPrefab != null)
        {
            GameObject ball = Instantiate(fireballPrefab, origin.position, origin.rotation);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb == null) rb = ball.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(origin.forward * fireballSpeed, ForceMode.VelocityChange);

            FireBall fb = ball.GetComponent<FireBall>();
            if (fb == null) fb = ball.AddComponent<FireBall>();
            fb.Init(fireballLifetime, fireStarter);
        }
        else
        {
            Debug.LogWarning("Falta atribuir o Fireball Prefab.", this);
        }

        Destroy(gameObject);
    }
}