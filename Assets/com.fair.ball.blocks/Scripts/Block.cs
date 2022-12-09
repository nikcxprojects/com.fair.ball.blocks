using System;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private int health;
    private int Health
    {
        get => health;
        set
        {
            health = value;
            TextComponent.text = $"{health}";

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private Animation Animation { get; set; }

    private TextMeshPro TextComponent { get; set; }

    public static Action OnCollisionEnter { get; set; }
    public static Action OnDestroyAction { get; set; }

    private void Start()
    {
        Animation = GetComponent<Animation>();
        TextComponent = GetComponentInChildren<TextMeshPro>();
        Health = UnityEngine.Random.Range(3, 99);
    }

    private void OnDestroy()
    {
        OnDestroyAction.Invoke();
    }

    private void OnCollisionEnter2D()
    {
        if (Animation.isPlaying)
        {
            Animation.Stop();
        }

        Animation.Play();
        OnCollisionEnter?.Invoke();

        Health--;
    }
}
