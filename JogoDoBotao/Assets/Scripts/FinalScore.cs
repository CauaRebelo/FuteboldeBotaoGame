using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TMP_Text textoScore_p1;
    public TMP_Text textoScore_p2;
    [SerializeField] private AudioClip startSFX;

    void Start()
    {
        textoScore_p1.SetText(Info_Player.scorep1.ToString());
        textoScore_p2.SetText(Info_Player.scorep2.ToString());
        SoundFXManager.instance.PlaySoundFXClip(startSFX, transform, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
