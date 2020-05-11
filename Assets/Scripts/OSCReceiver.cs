using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OSCReceiver : MonoBehaviour
{
    public OSC osc;

    [Space(20)]
    public TextMeshPro tempText;
    public Renderer sphere;
    public Transform dial;

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/fromboard", OnReceiveTemp);
    }

    void OnReceiveTemp(OscMessage message)
    {
        float x = message.GetFloat(0);
        
        // prevent random readings
        if (x > 0f)
        {
            tempText.text = "Temperature: " + x.ToString("F1");

            Color c = Color.grey;
            c.r = map(x, 20f, 30f, 0f, 1f);
            c.b = 1f - c.r;
            sphere.material.color = c;

            dial.localPosition = Vector3.up * map(x, 20f, 30f, -1f, 1f);
        }
    }

    private float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
