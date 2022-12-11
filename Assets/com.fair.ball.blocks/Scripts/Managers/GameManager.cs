using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private float nextFire;
    private const float fireRate = 0.05f;

    public int destroyedBlockCount;
    private const int blockCount = 81;

    private Player PlayerPrefab { get; set; }
    private GameObject BulletPrefab { get; set; }
    private GameObject BlockPrefab { get; set; }
    private GameObject Level { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        BulletPrefab = Resources.Load<GameObject>("bullet");
        BlockPrefab = Resources.Load<GameObject>("block");
        Level = Resources.Load<GameObject>("level");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Start()
    {
        Block.OnDestroyAction += () =>
        {
            if(++destroyedBlockCount >= blockCount)
            {
                uiManager.OpenWindow(5);
                EndGame();
            }
        };
    }

    private void CreateLine()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach(Block b in blocks)
        {
            b.MoveDown();
        }
        
        float blockSize = 0.5f;
        float padding = 0.1f;

        float screenWorldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        int blockCount = Mathf.RoundToInt(screenWorldWidth * 2 / (blockSize + padding));
        float xStart = -screenWorldWidth + 0.4f;

        for(int i = 0; i < blockCount; i++)
        {
            Vector2 position = new Vector2(xStart + i * 0.6f, GameObject.Find("topBorder").transform.position.y - 0.2f);
            Instantiate(BlockPrefab, position, Quaternion.identity, EnvironmentRef);
        }
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
        InvokeRepeating(nameof(CreateLine), 0.0f, 1.0f);

        Instantiate(PlayerPrefab, EnvironmentRef);
        //Instantiate(Level, EnvironmentRef);
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

        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach(Bullet b in bullets)
        {
            Destroy(b.gameObject);
        }
    }
}