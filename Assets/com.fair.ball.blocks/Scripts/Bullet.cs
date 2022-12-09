using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float force = 30;
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = FindObjectOfType<Player>().transform.position;
        Rigidbody.velocity = Player.Velocity * force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 inDirection = (collision.GetContact(0).point - (Vector2)transform.position).normalized;
        Vector2 normal = collision.GetContact(0).normal;

        Rigidbody.velocity = Vector2.Reflect(inDirection, normal).normalized * force;
    }
}
