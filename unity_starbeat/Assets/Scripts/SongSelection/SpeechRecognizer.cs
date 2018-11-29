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
    public Text inputText;
    
    public GameObject icon;
    Texture2D readyImage;
    Texture2D loadingImage ;
    Texture2D completedImage;
    
    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            inputText.text = text;
            icon.getComponent<RawImage>().textTure = completedImage;
            //add done icon
            //perform searching

        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            inputText.text = text;
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

        readyImage = Resources.Load<Texture2D>("readyImage");
        loadingImage = Resources.Load<Texture2D>("loadingImage");
        completedImage = Resources.Load<Texture2D>("completedImage");

        button = GameObject.Find("ButtonSpeech").GetComponent<Button>();
        input = GameObject.Find("InputSongSearch");
        inputText = GameObject.Find("PlaceholderSongSearch").GetComponent<Text>();
        icon = GameObject.Find("IconSpeech");
        icon.getComponent<RawImage>().textTure = readyImage;
        button.onClick.AddListener(OnClick);
    }

    void update()
    {
            //m_DictationRecognizer.Stop();
    }

    void OnClick()
    {
        m_DictationRecognizer.Start();
        icon.getComponent<RawImage>().textTure = loadingImage;
        //Add loading icon
    }
}
