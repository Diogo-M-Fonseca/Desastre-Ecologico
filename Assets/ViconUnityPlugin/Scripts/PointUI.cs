using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Update()
    {
        PlayerLogic playerLogic = FindAnyObjectByType<PlayerLogic>();
        if (playerLogic != null)
        {
            textMesh.text = "Points: " + playerLogic.Points;
        }
    }
}
