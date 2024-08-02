using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score_p1;
    public int score_p2;
    public bool paused = true;
    public float remainingTime = 180f;
    public string name_p1;
    public string name_p2;
    public GameObject tip;
    public TMP_Text textoScore_p1;
    public TMP_Text textoScore_p2;
    public TMP_Text textoTime_p1;
    public TMP_Text textoTime_p2;
    public TMP_Text textoTimer;
    [SerializeField] private AudioClip startSFX;
    [SerializeField] private AudioClip finishSFX;


    void Start()
    {
        EventSystem.current.onGoalPlayer1 += OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 += OnGoalPlayer2;
        EventSystem.current.onBallPlay += OnBallPlay;
        Info_Player.scorep1 = 0;
        Info_Player.scorep2 = 0;
        score_p1 = 0;
        score_p2 = 0;
        name_p1 = Info_Player.namep1;
        name_p2 = Info_Player.namep2;
        textoTime_p1.SetText(name_p1);
        textoTime_p2.SetText(name_p2);
        textoScore_p1.SetText(score_p1.ToString());
        textoScore_p2.SetText(score_p1.ToString());
        SoundFXManager.instance.PlaySoundFXClip(startSFX, transform, 1f);
        StartCoroutine(GiveTip());
    }

    private void Update()
    {
        if(remainingTime > 0)
        {
            if(!paused)
            {
                remainingTime -= Time.deltaTime;
                textoTimer.color = Color.white;
                if(remainingTime <= 10f)
                {
                    textoTimer.color = Color.red;
                }
            }
            else
            {
                textoTimer.color = Color.blue;
            }
        }
        else
        {
            remainingTime = 0;
            FinaldeJogo();
            textoTimer.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        textoTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void FinaldeJogo()
    {
        EventSystem.current.EndGame();
        SoundFXManager.instance.PlaySoundFXClip(finishSFX, transform, 1f);
        StartCoroutine(EndGame());
    }

    IEnumerator GiveTip()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(7f);
        tip.SetActive(false);
    }
    void OnGoalPlayer1()
    {
        score_p1++;
        Info_Player.scorep1++;
        textoScore_p1.SetText(score_p1.ToString());
        paused = true;
    }
    void OnGoalPlayer2()
    {
        score_p2++;
        Info_Player.scorep2++;
        textoScore_p2.SetText(score_p2.ToString());
        paused = true;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TelaResultado");
    }
    void OnBallPlay()
    {
        paused = false;
    }
}
