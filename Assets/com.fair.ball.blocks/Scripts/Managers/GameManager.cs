using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private float nextFire;
    private const float fireRate = 0.05f;

    private int destroyedBlockCount;
    private const int blockCount = 81;

    private Player PlayerPrefab { get; set; }
    private GameObject BulletPrefab { get; set; }
    private GameObject Level { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        BulletPrefab = Resources.Load<GameObject>("bullet");
        Level = Resources.Load<GameObject>("level");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Start()
    {
        Block.OnDestroy += () =>
        {
            if(++destroyedBlockCount >= blockCount)
            {
                uiManager.OpenWindow(5);
                EndGame();
            }
        };
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
        destroyedBlockCount = 0;

        Instantiate(PlayerPrefab, EnvironmentRef);
        Instantiate(Level, EnvironmentRef);
    }

    public void EndGame()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        if (GameObject.Find("level(Clone)"))
        {
            Destroy(GameObject.Find("level(Clone)"));
        }

        Bullet[] balls = FindObjectsOfType<Bullet>();
        foreach(Bullet b in balls)
        {
            Destroy(b.gameObject);
        }
    }
}