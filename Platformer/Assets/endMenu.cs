using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endUI;
    public PlayerMovement player;
    public GameObject boss;
    public UnityEngine.UI.Button endButton;
    private bool activated = false;
    void Start()
    {
        endUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!boss.activeSelf && !activated){
            activated = true;
            endUI.SetActive(true);
            player.DisableInput();
            endButton.Select();
        }
    }
}
