using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerLogic player;

    public PlayerLogic Player => player;

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLogic>() == false
            && collision.gameObject.GetComponent<Catch>() == false)
        {
            Player.Death();
        }
    }*/
}
