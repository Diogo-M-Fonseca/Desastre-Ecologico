using UnityEngine;
using System.Collections;

public class objectMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocityBreak;
    private Rigidbody _controller;
    private float _velocity;
    private float _rare;

    void Start()
    {
        _controller = GetComponent<Rigidbody>();
        _velocity = Random.Range(velocityBreak.x, velocityBreak.y);
        _rare = Random.Range(0, 100);
    }
    void Update()
    {
        if (_rare > 1)
            _controller.linearVelocity = _velocity * Vector3.forward * Time.deltaTime;
        else
            _controller.linearVelocity = 2000 * Vector3.forward * Time.deltaTime;
    }
}
