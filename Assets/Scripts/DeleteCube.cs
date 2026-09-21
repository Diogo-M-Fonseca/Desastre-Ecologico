using UnityEngine;

public class DeleteCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == FindAnyObjectByType<SwordSpawner>().gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
