using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject titleMenu;
    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button backButton;
    public UnityEngine.UI.Button creditsButton;
    

    public static bool inTitle = true;
    public static bool inCredits = false;
    // Start is called before the first frame update
    void Start()
    {
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && inCredits){
        ShowTitle();
        }
    }

    public void StartGame(){
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("Stage1");
    }

    public void ShowCredits(){
        titleMenu.SetActive(false);
        creditsMenu.SetActive(true);
        inCredits = true;
        inTitle = false;
        backButton.Select();
    }

    public void ShowTitle(){
        titleMenu.SetActive(true);
        creditsMenu.SetActive(false);
        inCredits = false;
        inTitle = true;
        creditsButton.Select();

    }

    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();

    }
}
