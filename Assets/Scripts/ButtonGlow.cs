using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonGlow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI glowText;

    float glowPower = 0f;

    bool isGlowing;

    void Update()
    {

        if(glowPower <= 0)
        {
            isGlowing = true;
        }

        if(glowPower < 0.120 && isGlowing)
        {
            glowPower += .001f;
            glowText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);
        }else 
        {
            isGlowing = false;
            glowPower -= 0.001f;
            glowText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);
        }
        
    }
}
