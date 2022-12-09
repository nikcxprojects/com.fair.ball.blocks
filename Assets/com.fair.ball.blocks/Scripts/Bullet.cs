using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float force = 100;
    Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody.velocity = Player.Velocity * force;
    }
}
