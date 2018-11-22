using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameplay : MonoBehaviour {
    public GameObject panel;
    public GameObject panelAdvancedSetting;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        panelAdvancedSetting = GameObject.Find("Canvas").transform.Find("PanelAdvancedSetting").gameObject;
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickExit()
    {
        SceneManager.LoadScene("SongSelection");
    }

    public void onClickPanel()
    {
        Audio.isPaused = true;
        audioSource.Pause();
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void onClickReplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void onClickAdvancedSetting()
    {
        panelAdvancedSetting.SetActive(true);
    }

    public void onClickResume()
    {
        Time.timeScale = 1f;
        Audio.isPaused = false;
        audioSource.UnPause();
        panel.SetActive(false);
    }

    public void onClickReturn()
    {
        panelAdvancedSetting.SetActive(false);
    }

    public void onClickSave()
    {
        panelAdvancedSetting.SetActive(false);
    }
}
