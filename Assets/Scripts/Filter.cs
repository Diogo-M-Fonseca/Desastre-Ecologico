using TMPro;
using UnityEngine;

public class Filter : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLogic>() == false)
        {
            playerLogic.PointUp();
            textMeshPro.text = playerLogic.Points.ToString();
            other.gameObject.SetActive(false);
        }
    }
}