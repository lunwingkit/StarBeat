using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    public Slider GeneralVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SoundEffectSlider;
    public Slider NoteSpeedSlider;
    public Text GeneralVolumeDisplay;
    public Text MusicVolumeDisplay;
    public Text SoundEffectDisplay;
    public Text NoteSpeedDisplay;
    public Image GeneralVolumeIcon;
    public Image MusicVolumeIcon;
    public Image SoundEffectVolumeIcon;
    public Sprite VolumeHighIcon;
    public Sprite VolumeMediumIcon;
    public Sprite VolumeLowIcon;
    public Sprite VolumeMuteIcon;

    private void Update()
    {
        GeneralVolumeDisplay.text = GeneralVolumeSlider.value.ToString();
        MusicVolumeDisplay.text = MusicVolumeSlider.value.ToString();
        SoundEffectDisplay.text = SoundEffectSlider.value.ToString();

        ChangeVolumeIcon(GeneralVolumeSlider, GeneralVolumeIcon);
        ChangeVolumeIcon(MusicVolumeSlider, MusicVolumeIcon);
        ChangeVolumeIcon(SoundEffectSlider, SoundEffectVolumeIcon);

        NoteSpeedDisplay.text = NoteSpeedSlider.value.ToString();
    }

    void ChangeVolumeIcon(Slider slider, Image icon)
    {
        if (slider.value == 0.0)
            icon.sprite = VolumeMuteIcon;
        else if (slider.value < 35.0)
            icon.sprite = VolumeLowIcon;
        else if (slider.value >= 75.0)
            icon.sprite = VolumeHighIcon;
        else
            icon.sprite = VolumeMediumIcon;
    }
}
