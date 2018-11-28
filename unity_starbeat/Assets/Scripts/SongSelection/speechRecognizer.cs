using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class speechRecognizer : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;
    public Button button;
    public GameObject input;
    public Text inputText;

    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            inputText.text = text;
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


        button = GameObject.Find("ButtonSpeech").GetComponent<Button>();
        input = GameObject.Find("InputSongSearch");
        inputText = GameObject.Find("PlaceholderSongSearch").GetComponent<Text>();
        button.onClick.AddListener(OnClick);
    }

    void update()
    {
            //m_DictationRecognizer.Stop();
    }

    void OnClick()
    {
        m_DictationRecognizer.Start();
        //Add loading icon
    }
}