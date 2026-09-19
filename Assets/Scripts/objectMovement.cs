using UnityEngine;
using System.Collections;

public class objectMovement : MonoBehaviour
{
    private Rigidbody _controller;
    [SerializeField] private float _velocity;
    private float _rare;

    void Start()
    {
        _controller = GetComponent<Rigidbody>();
        _rare = Random.Range(0, 100);
    }
    void FixedUpdate()
    {
        if (_rare > 1)
            _controller.linearVelocity = _velocity * Vector3.forward * Time.fixedDeltaTime;
        else
            _controller.linearVelocity = 2000 * Vector3.forward * Time.fixedDeltaTime;
    }
}
