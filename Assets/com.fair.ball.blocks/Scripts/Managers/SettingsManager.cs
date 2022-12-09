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
        loop.mute = sfx.mute = true;

        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = !loop.mute;

            string status = loop.mute ? "OFF" : "ON";
            soundBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";
        });


        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = !sfx.mute;

            string status = sfx.mute ? "OFF" : "ON";
            sfxBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";
        });

        vibroBtn.onClick.AddListener(() =>
        {
            VibraEnable = !VibraEnable;

            string status = VibraEnable ? "OFF" : "ON";
            vibroBtn.transform.GetChild(0).GetComponent<Text>().text = $"{status}";
        });

        soundBtn.onClick.Invoke();
        sfxBtn.onClick.Invoke();
        vibroBtn.onClick.Invoke();
    }
}
