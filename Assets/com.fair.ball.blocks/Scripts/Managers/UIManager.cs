using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score ;

    private GameObject _last = null;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;
    [SerializeField] GameObject top;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;

    public Transform border;

    private void Awake()
    {
        OpenWindow(0);
    }

    private void Start()
    {
        Block.OnCollisionEnter += () =>
        {
            scoreText.text = finalScoreText.text = $"{++score}";
        };
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && game.activeSelf && !pause.activeSelf)
        {
            OpenMenu();
        }
    }

    public void UpdateScore()
    {
        scoreText.text = $"{++score}";
        finalScoreText.text = scoreText.text;
    }

    public void OpenMenu()
    {
        score = 0;

        OpenWindow(0);
        game.SetActive(false);

        GameManager.Instance.EndGame();
    }

    public void StartGameOnClick()
    {
        scoreText.text = $"{score}";
        GameManager.Instance.StartGame();

        OpenWindow(3);
    }

    public void OpenWindow(int windowIndex)
    {
        if(_last && windowIndex != 4)
        {
            _last.SetActive(false);
        }

        switch(windowIndex)
        {
            case 0: _last = menu; break;
            case 1: _last = options; break;
            case 2: _last = top; break;
            case 3: _last = game; break;
            case 4: _last = pause;break;
            case 5: _last = result; break;
        }

        _last.SetActive(true);
        Time.timeScale = windowIndex == 4 ? 0 : 1;
    }
}