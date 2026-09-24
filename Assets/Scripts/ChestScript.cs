using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private bool plate1Activated = false;
    private bool plate2Activated = false;
    private bool plate3Activated = false;
    private bool plate4Activated = false;

    public void ActivatePlate(int plateNumber)
    {
        switch (plateNumber)
        {
            case 1:
                plate1Activated = true;
                break;
            case 2:
                plate2Activated = true;
                break;
            case 3:
                plate3Activated = true;
                break;
            case 4:
                plate4Activated = true;
                break;
        }
        if (plate1Activated && plate2Activated && plate3Activated && plate4Activated)
        {
            OpenChest();
        }
    }

    public void DeactivatePlate(int plateNumber)
    {
        switch (plateNumber)
        {
            case 1:
                plate1Activated = false;
                break;
            case 2:
                plate2Activated = false;
                break;
            case 3:
                plate3Activated = false;
                break;
            case 4:
                plate4Activated = false;
                break;
        }
    }

    private void OpenChest()
    {
        gameObject.SetActive(false);
    }
}