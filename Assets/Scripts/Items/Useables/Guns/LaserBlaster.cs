using System;
using UnityEngine;

public class LaserBlaster : UseableItemGun
{
    public LaserBlaster()
    {
        fireDelay = 0.1f;
        autoAttack = true;

        OnFired += LaserBlaster_OnFired;
    }

    public SpriteRenderer iconRenderer;

    const float defFireDelay = 0.1f;

    private float heat = 0f;
    private float lastCool = 0f;
    private float lastShot = 0f;
    private float lastOverheatDisplay = 0f;

    private void LaserBlaster_OnFired(object sender, System.EventArgs e)
    {
        heat += 0.05f;

        lastShot = Time.time;
    }

    protected override void Start()
    {
        byte[] data = controller.currentItemData.customData;

        if (data != null && data.Length > 0)
        {
            heat = BitConverter.ToSingle(data, 0);
            lastShot = Time.time;
            lastCool = Time.time;
        }
    }
    public override string StatusText
    {
        get
        {
            if (heat >= 1f)
            {
                if (Time.time - lastOverheatDisplay >= 1f)
                {
                    if (Time.time - lastOverheatDisplay >= 2f)
                    {
                        lastOverheatDisplay = Time.time;
                    }

                    return "<color=red>!! OVERHEAT !!</color>";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                if (heat > 0)
                {
                    if (Time.time - lastShot >= 1f)
                    {
                        return "<color=cyan>Cooling Down</color>";
                    }
                }

                if (heat <= 0.25f)
                {
                    return "Heat: <color=green>OK</color>";
                }
                else if (heat <= 0.5f)
                {
                    return "Heat: <color=#BC4B00>Warm</color>";
                }
                else if (heat <= 0.75f)
                {
                    return "Heat: <color=#BF0000>Hot</color>";
                }
                else
                {
                    return $"Heat: <color=#FF0000>Flaming Hot</color>";
                }
            }
        }
    }
    protected override void FixedUpdate()
    {
        if (heat > 0)
        {
            fireDelay = defFireDelay * (1f + heat);

            if (Time.time - lastCool >= 0.1f && Time.time - lastShot >= 1f)
            {
                heat -= 0.025f;
            }
        }

        float val = Mathf.Clamp(heat, 0f, 1f);
        float rVal = 1f - val;

        iconRenderer.color = new Color(1f, rVal, rVal);

        byte[] heatBytes = BitConverter.GetBytes(heat);

        controller.currentItemData.customData = heatBytes;
    }
}
