using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtn;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtn;

    [Space(10)]
    [SerializeField] Button vibroBtn;

    public static bool VibraEnable { get; set; } = true;

    private void Start()
    {
        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = true;
        });


        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = false;
        });

        vibroBtn.onClick.AddListener(() =>
        {
            VibraEnable = false;
        });

        soundBtn.onClick.Invoke();
        sfxBtn.onClick.Invoke();
        vibroBtn.onClick.Invoke();
    }
}
