using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBarScript : MonoBehaviour
{
    public Image dashBarImage;

    public void UpdateDashBar(float currentDash, float maxDash)
    {
        dashBarImage.fillAmount = currentDash / maxDash;
    }
}
