using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header("CompletePanel")]
    [SerializeField] private GameObject CompletePanel;
    [SerializeField] private Button NextButton;
    [Header("FailPanel")]
    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Button RetryButton;
    [Header("GameStartPanel")]
    [SerializeField] private GameObject GameStartPanel;
    [SerializeField] private Button TapToButton;
    [Header("InGamePanel")]
    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private TMP_Text LevelText;
    [SerializeField] private Button RestartButton;
    [SerializeField] private ObjectSpawner objectSpawner;



    private void Awake()
    {
        DontDestroyOnLoad(this);
        GameManager.Instance.ObjectSpawner = objectSpawner;
    }
    void Start()
    {
        TapToButton.onClick.AddListener(TapToStatus);
        RestartButton.onClick.AddListener(RestartStatus);
        RetryButton.onClick.AddListener(RestartStatus);
        GameManager.WinEvent += WinStatus;
        GameManager.FailEvent += FailStatus;
    }

    private void OnDisable()
    {
        TapToButton.onClick.RemoveListener(TapToStatus);
        RestartButton.onClick.RemoveListener(RestartStatus);
        RetryButton.onClick.RemoveListener(RestartStatus);
        GameManager.WinEvent -= WinStatus;
        GameManager.FailEvent -= FailStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TapToStatus()
    {
        GameStartPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }
    private void RestartStatus()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinStatus()
    {
        InGamePanel.SetActive(false);
        CompletePanel.SetActive(true);
    }

    public void FailStatus()
    {
        InGamePanel.SetActive(false);
        FailPanel.SetActive(true);
    }

}
