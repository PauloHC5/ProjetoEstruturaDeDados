using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Browser : MonoBehaviour
{
    [SerializeField] private TMP_InputField _urlInput;
    [SerializeField] private Button _backButtom;
    [SerializeField] private Button _forwardButtom;

    private Stack<string> _backStack = new Stack<string>();
    private Stack<string> _forwardStack = new Stack<string>();
    private string _currentUrl;

    private void Awake()
    {
        _urlInput.onSubmit.AddListener(OnNavigateRequest);
    }

    private void Start()
    {
        _currentUrl = "www.google.com";
        UpdateUI();
    }

    public void OnNavigateRequest(string value)
    {
        string newUrl = _urlInput.text.Trim();
        
        if(!string.IsNullOrEmpty(newUrl) && newUrl != _currentUrl)
        {
            if(!string.IsNullOrEmpty(_currentUrl))
            {
                _backStack.Push(newUrl);
            }
            _currentUrl = newUrl;
            _forwardStack.Clear();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        _urlInput.text = _currentUrl;
        _backButtom.interactable = !_backStack.IsEmpty();
        _forwardButtom.interactable = !_forwardStack.IsEmpty();
    }

    public void GoBack()
    {
        if(!_backStack.IsEmpty())
        {
            _forwardStack.Push(_currentUrl);
            _currentUrl = _backStack.Pop();
            UpdateUI();
        }
    }

    public void GoForward()
    {
        if(!_forwardStack.IsEmpty())
        { 
            _backStack.Push(_currentUrl);
            _currentUrl = _forwardStack.Pop();
            UpdateUI();
        }
    }
}
