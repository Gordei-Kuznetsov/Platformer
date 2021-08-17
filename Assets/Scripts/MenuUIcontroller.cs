using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button beginButton;
    public Text introText;
    void Start()
    {
        startButton.enabled = true;
        introText.enabled = false;
        startButton.onClick.AddListener(startTask);
        quitButton.onClick.AddListener(quitTask);
        beginButton.onClick.AddListener(beginTask);
    }

    void startTask(){
        startButton.enabled = false;
        introText.enabled = true;
    }
    void quitTask(){
        Application.Quit();
    }
    void beginTask(){
        SceneManager.LoadScene("Level1");
    }
}
