using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject panel_help;
    public AudioSource aud;
    public Text text_score;
    private int score;
    private int max_score;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
            score = 0;


        if (PlayerPrefs.HasKey("max_score"))
        {
            max_score = PlayerPrefs.GetInt("max_score");
        }
        else
        {
            max_score = 0;
        }
        if (score > max_score)
        {
            text_score.text = "Best Score: " + score.ToString();
            PlayerPrefs.SetInt("max_score", score);

        }
        else
            text_score.text = "Best Score: " + max_score.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click_help()
    {
        panel_help.SetActive(true);
        aud.Play();
    }
    public void Clock_help()
    {
        panel_help.SetActive(false);
        aud.Play();
    }
    public void Click_play()
    {
        Application.LoadLevel(1);
    }
}
