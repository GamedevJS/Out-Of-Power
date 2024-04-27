using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    public TextMeshProUGUI scoreTXT;
    public TextMeshProUGUI soreGameOver;
    public TextMeshProUGUI bestScore;

    private int score;

    float timer;

    public AudioSource powerDown;

    private bool alreadyPlayed = false;
    private void Start()
    {
        PlayerPrefs.SetInt("LightsOn", 0);
        PlayerPrefs.SetInt("WhichDoor", 0);
        PlayerPrefs.SetInt("HasKey", 0);
        PlayerPrefs.SetInt("AlreadyUnlocked", 0);
        PlayerPrefs.SetInt("HasScrewdriver", 0);
        PlayerPrefs.SetInt("AlreadyFixedWires", 0);
    }
    private void FixedUpdate()
    {
        scoreTXT.text = score.ToString();
        soreGameOver.text = score.ToString();
        bestScore.text = PlayerPrefs.GetInt("score", 0).ToString();

        if (PlayerPrefs.GetInt("score", 0) < score)
        {
            PlayerPrefs.SetInt("score", score);
        }

        if (score >= 4 && PlayerPrefs.GetInt("Stage", 0) == 0)
        {
            if (GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>() != null)
            {
                if (!alreadyPlayed)
                {
                    powerDown.Play();
                    alreadyPlayed = true;
                }

                GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>().SetTrigger("TurnOff");

                timer = timer + Time.deltaTime;

                FindObjectOfType<AudioManager>().StopAll();

                if (timer > 2f)
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("Stage1.5");
                    PlayerPrefs.SetInt("Stage", 1);
                }
            }
        }

        if (score>= 6 && PlayerPrefs.GetInt("Stage", 0) == 1)
        {
            if (GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>() != null)
            {
                if (!alreadyPlayed)
                {
                    powerDown.Play();
                    alreadyPlayed = true;
                }
                GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>().SetTrigger("TurnOff");

                timer = timer + Time.deltaTime;

                    FindObjectOfType<AudioManager>().StopAll();

                if (timer > 2f)
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("Stage2");
                    PlayerPrefs.SetInt("Stage", 2);
                }
            }
        }

        if (score >= 8 && PlayerPrefs.GetInt("Stage", 0) == 2)
        {
            if (GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>() != null)
            {
                if (!alreadyPlayed)
                {
                    powerDown.Play();
                    alreadyPlayed = true;
                }
                GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>().SetTrigger("TurnOff");

                timer = timer + Time.deltaTime;

                FindObjectOfType<AudioManager>().StopAll();

                if (timer > 2f)
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("Stage3");
                    PlayerPrefs.SetInt("Stage", 3);
                }
            }
        }

        if (score >= 10 && PlayerPrefs.GetInt("Stage", 0) == 3)
        {
            if (GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>() != null)
            {
                if (!alreadyPlayed)
                {
                    powerDown.Play();
                    alreadyPlayed = true;
                }
                GameObject.FindGameObjectWithTag("TV").GetComponent<Animator>().SetTrigger("TurnOff");

                timer = timer + Time.deltaTime;

                FindObjectOfType<AudioManager>().StopAll();

                if (timer > 2f)
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("Stage4");
                    PlayerPrefs.SetInt("Stage", 4);
                }
            }
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    { 
        gameOverScreen.SetActive(true);
        scoreTXT.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        score++;
    }
} 