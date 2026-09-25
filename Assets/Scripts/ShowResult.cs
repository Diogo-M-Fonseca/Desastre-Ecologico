using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private RunData run;
    [SerializeField] private float timeUntilDisappear = 5f;
    private float _timer;
    private Image _renderer;

    private void Start()
    {
        _renderer = GetComponent<Image>();

        switch (run.CalculateScore())
        {
            case <=0.2:
                _renderer.sprite = sprites[0];
                break;
            case <=0.4:
                _renderer.sprite = sprites[1];
                break;
            case <=0.6:
                _renderer.sprite = sprites[2];
                break;
            case <=0.8:
                _renderer.sprite = sprites[3];
                break;
            default:
                _renderer.sprite = sprites[4];
                break;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= timeUntilDisappear)
            gameObject.SetActive(false);
    }
}
