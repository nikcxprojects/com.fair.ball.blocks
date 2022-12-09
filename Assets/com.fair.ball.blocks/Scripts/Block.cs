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

            if(Animation.isPlaying)
            {
                Animation.Stop();
            }

            Animation.Play();
            OnCollisionEnter?.Invoke();

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private Animation Animation { get; set; }

    private TextMeshPro TextComponent { get; set; }

    public static Action OnCollisionEnter { get; set; }

    private void Start()
    {
        Animation = GetComponent<Animation>();
        TextComponent = GetComponentInChildren<TextMeshPro>();
        Health = UnityEngine.Random.Range(10, 99);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health--;
    }
}
