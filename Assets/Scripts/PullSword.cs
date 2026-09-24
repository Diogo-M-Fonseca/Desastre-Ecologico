using UnityEngine;

public class PullSword : MonoBehaviour
{
    [SerializeField] private PlayerLogic player;
    private int _manyHolding;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCollider _))
        {
            _manyHolding++;

            if (_manyHolding == 2)
            {
                transform.SetParent(other.transform);
                transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PlayerCollider _))
        {
            _manyHolding--;
        }
        else player.GameFinished();
    }
}
