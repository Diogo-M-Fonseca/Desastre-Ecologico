using System;
using System.Linq;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    private void OnCollisionEnter(Collision collision)
    {
        playerLogic.Death();
    }
}
