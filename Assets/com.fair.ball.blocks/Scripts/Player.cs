using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private const float RotSpeed = 10.0f;

    private Camera _camera;
    public static Action BallCollected { get; set; } = delegate { };

    private void Awake()
    {
        _camera = Camera.main;
        transform.position = new Vector2(0, FindObjectOfType<UIManager>().border.position.y + 0.95f);
    }

    private void Update()
    {
        if(Time.timeScale < 1)
        {
            return;
        }

        Vector2 toInput = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        toInput.Normalize();

        toInput.x = Mathf.Clamp(toInput.x, -1, 1);
        toInput.y = Mathf.Clamp(toInput.y, 0.2f, 1);

        transform.GetChild(0).up = toInput;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(SettingsManager.VibraEnable)
        {
            Handheld.Vibrate();
        }

        BallCollected?.Invoke();
        Destroy(collider.gameObject);
        GameManager.Instance.uiManager.UpdateScore();
    }
}
