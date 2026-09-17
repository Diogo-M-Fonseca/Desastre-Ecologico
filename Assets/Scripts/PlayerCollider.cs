using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerLogic player;

    public PlayerLogic Player => player;
}
