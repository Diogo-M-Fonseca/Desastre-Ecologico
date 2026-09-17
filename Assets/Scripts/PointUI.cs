using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    [SerializeField] private Text pointText;

    private void Update()
    {
        PlayerLogic playerLogic = FindAnyObjectByType<PlayerLogic>();
        if (playerLogic != null)
        {
            pointText.text = "Points: " + playerLogic.Points.ToString();
        }
    }   
}
