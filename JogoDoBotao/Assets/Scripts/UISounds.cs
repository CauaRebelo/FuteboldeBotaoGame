using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick;
    public void soundClick()
    {
        SoundFXManager.instance.PlaySoundFXClip(buttonClick, transform, 1f);
    }

}
