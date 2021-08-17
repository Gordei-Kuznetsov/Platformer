using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIcontroller : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button beginButton;
    public Text introText;
    void Start()
    {
        startButton.gameObject.SetActive(true);
        introText.gameObject.SetActive(false);
        beginButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(startTask);
        quitButton.onClick.AddListener(quitTask);
        beginButton.onClick.AddListener(beginTask);
    }

    void startTask(){
        startButton.gameObject.SetActive(false);
        introText.gameObject.SetActive(true);
        beginButton.gameObject.SetActive(true);
    }
    void quitTask(){
        Application.Quit();
    }
    void beginTask(){
        SceneManager.LoadScene("Level1");
    }
}
