using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//When Cancel is pressed it toggles GameIsPaused
//When GameIsPaused, Time.timeScale is set to 0 by calling Pause()
//Resume() is called to set the game back to 1
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject volumeSlider;
    public UnityEngine.UI.Button resumeButton;
    public PlayerMovement player;

    void Start()
    {
        
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(GameIsPaused){
                Resume();
                
                
            }
            else{
                Pause();
                
            }
        }
    }

    public void Resume(){
        resumeButton.Select();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        player.EnableInput();
        GameIsPaused = false;
    }

    public void LoadTitle(){
        Debug.Log("Loading Menu");
        Time.timeScale = 1;
        GameIsPaused = false;
        player.EnableInput();

        SceneManager.LoadScene("TitleScreen");
    }

    public void VolumeUpdate(float multiplier){
        
        Debug.Log("Changing Volume to " + multiplier + " [Unimplemented]");
    }

    void Pause(){
        resumeButton.Select();
        pauseMenuUI.SetActive(true);
        player.DisableInput();
        
        
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
