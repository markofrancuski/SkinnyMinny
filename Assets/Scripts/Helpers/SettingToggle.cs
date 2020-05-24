using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingToggle : MonoBehaviour
{
    public SETTINGTYPE type;
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TextMeshProUGUI _valueDisplayText;

    public float SettingValue;

    // Start is called before the first frame update
    void Start()
    {
        float newValue = 1;

        switch (type)
        {
            case SETTINGTYPE.MUSIC:
                if (PlayerPrefs.HasKey("Music")) newValue = PlayerPrefs.GetFloat("Music");
                break;
            case SETTINGTYPE.SOUND:
                if (PlayerPrefs.HasKey("Sound")) newValue = PlayerPrefs.GetFloat("Sound");
                break;
            default:
                break;
        }
        _slider.value = newValue;
        _valueDisplayText.SetText(newValue.ToString("F2"));
    }

    public void OnValueChanged(float newValue)
    {
        //Debug.Log(newValue);
        _valueDisplayText.SetText(newValue.ToString("F2"));
        switch (type)
        {
            case SETTINGTYPE.MUSIC:
                AudioManager.Instance.UpdateMusicVolume(newValue);
                break;
            case SETTINGTYPE.SOUND:
                AudioManager.Instance.UpdateSoundVolume(newValue);
                break;
            default:
                break;
        }
    }

}

public enum SETTINGTYPE
{
    MUSIC,
    SOUND
}

