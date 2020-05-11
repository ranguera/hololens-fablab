using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SMDManager : MonoBehaviour
{
    public OSCSender oscSender;

    [Space(20)]
    public TextMeshPro r;
    public TextMeshPro g;
    public TextMeshPro b;

    private string old_r, old_g, old_b;

    // Start is called before the first frame update
    void Start()
    {
        old_r = r.text;
        old_g = g.text;
        old_b = b.text;
        GameObject.Find("Diagnostics").SetActive(false);
        GameObject.Find("Diagnostic").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if( r.text != old_r )
        {
            oscSender.SendR((float)Convert.ToDouble(r.text));
            old_r = r.text;
        }

        if (g.text != old_g)
        {
            oscSender.SendG((float)Convert.ToDouble(g.text));
            old_g = g.text;
        }

        if (b.text != old_b)
        {
            oscSender.SendB((float)Convert.ToDouble(b.text));
            old_b = b.text;
        }
    }
}
