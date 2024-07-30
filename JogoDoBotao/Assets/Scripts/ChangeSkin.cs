using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSkinP1(int val)
    {
        Info_Player.teamp1 = val;
    }

    public void ChangeNameP1(string val)
    {
        Info_Player.namep1 = val;
    }

    public void ChangeSkinP2(int val)
    {
        Info_Player.teamp2 = val;
    }

    public void ChangeNameP2(string val)
    {
        Info_Player.namep2 = val;
    }
}
