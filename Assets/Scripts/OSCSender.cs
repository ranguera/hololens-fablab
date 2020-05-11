using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCSender : MonoBehaviour
{
    public OSC osc;

    [HideInInspector]
    public float r, g, b;

    private float led_on;

    // Start is called before the first frame update
    void Start()
    {
        led_on = 0;
    }

    public void SendLED()
    {
        OscMessage message = new OscMessage();
        message.address = "/toboard_toggle";
        led_on = (led_on == 0f) ? 1f : 0f;
        message.values.Add(led_on);
        osc.Send(message);
    }

    public void SendR(float f)
    {
        OscMessage message = new OscMessage();
        message.address = "/toboard_r";
        message.values.Add(f);
        osc.Send(message);
    }

    public void SendG(float f)
    {
        OscMessage message = new OscMessage();
        message.address = "/toboard_g";
        message.values.Add(f);
        osc.Send(message);
    }

    public void SendB(float f)
    {
        OscMessage message = new OscMessage();
        message.address = "/toboard_b";
        message.values.Add(f);
        osc.Send(message);
    }
}
