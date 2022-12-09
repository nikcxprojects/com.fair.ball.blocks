using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float force = 30;
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Debug.Log(Rigidbody);
    }

    private void Start()
    {
        transform.position = FindObjectOfType<Player>().transform.position;
        Rigidbody.velocity = Player.Velocity * force;
    }
}
