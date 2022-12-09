using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private Player playerPrefab { get; set; }

    private Ball BallPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;
    [SerializeField] Transform bottomLine;

    private void Awake()
    {
        playerPrefab = Resources.Load<Player>("player");

        BallPrefab = Resources.Load<Ball>("ball");
        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void StartGame()
    {
        Instantiate(playerPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        Ball[] balls = FindObjectsOfType<Ball>();
        foreach(Ball b in balls)
        {
            Destroy(b.gameObject);
        }
    }
}