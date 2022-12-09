using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private float nextFire;
    private const float fireRate = 0.15f;

    private Player PlayerPrefab { get; set; }
    private GameObject BulletPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;
    [SerializeField] Transform bottomLine;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        BulletPrefab = Resources.Load<GameObject>("bullet");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(BulletPrefab, EnvironmentRef);
        }
    }

    public void StartGame()
    {
        Instantiate(PlayerPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        Bullet[] balls = FindObjectsOfType<Bullet>();
        foreach(Bullet b in balls)
        {
            Destroy(b.gameObject);
        }
    }
}