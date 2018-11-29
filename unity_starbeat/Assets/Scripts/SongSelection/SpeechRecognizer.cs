using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognizer : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;
    public Button button;
    public GameObject input;
    public GameObject inputText;
    
    public Button buttonTextSearch;
    
    public GameObject icon;
    //Texture2D readyImage;
    Texture2D loadingImage ;
    Texture2D completedImage;
    
    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            inputText.GetComponent<InputField>().text = text;
            icon.GetComponent<RawImage>().texture = completedImage;
            m_DictationRecognizer.Stop();
            if (text.Equals("all"))
                SongPlateManager.instance.showAllSongs();
            else
                SongPlateManager.instance.searchSong(text);
            //add done icon
            //perform searching


        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            inputText.GetComponent<InputField>().text = text;
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        //readyImage = Resources.Load<Texture2D>("readyImage"); //Create ar
        loadingImage = Resources.Load<Texture2D>("loadingImage"); //Create ar
        completedImage = Resources.Load<Texture2D>("completedImage"); //Create ar

        button = GameObject.Find("ButtonSpeech").GetComponent<Button>();
        //buttonTextSearch = GameObject.Find("ButtonTextSearch").GetComponent<Button>();
        input = GameObject.Find("InputSongSearch");
        inputText = GameObject.Find("InputSongSearch"); //This inputText should not be placeholder
        icon = GameObject.Find("IconSpeech"); //Create ar
        icon.SetActive(false);
        //icon.GetComponent<RawImage>().texture = readyImage;
        button.onClick.AddListener(OnClick);
        inputText.GetComponent<InputField>().onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        print("textSR");
    }

    void update()
    {
            //m_DictationRecognizer.Stop();
    }

    void OnClick()
    {
        print("clicked");
        m_DictationRecognizer.Start();
        icon.SetActive(true);
        icon.GetComponent<RawImage>().texture = loadingImage;
        //Add loading icon
    }
    
    public void ValueChangeCheck()
    {
        print("activated");
        if(inputText.GetComponent<InputField>().text == "")
        {
        //show all song
            SongPlateManager.instance.showAllSongs();
        }
        else
        {
            SongPlateManager.instance.searchSong(inputText.GetComponent<InputField>().text);
        }
    }
}
