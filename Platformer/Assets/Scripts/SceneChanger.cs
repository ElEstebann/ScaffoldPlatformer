using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelChanger.FadeOut(levelToLoad);
        }
    }
}
