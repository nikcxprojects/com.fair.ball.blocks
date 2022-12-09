using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private Camera _camera;
    public static Action BallCollected { get; set; } = delegate { };

    private void Awake()
    {
        _camera = Camera.main;
        transform.position = new Vector2(0, FindObjectOfType<UIManager>().border.position.x + 1);
    }

    private void Update()
    {
        if(Time.timeScale < 1)
        {
            return;
        }
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
