using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettingsScript : MonoBehaviour
{
    public TMP_Dropdown qualitySettingDropdown;

    private void Start()
    {
        qualitySettingDropdown.value = PlayerPrefs.GetInt("QualityLevel", 2);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }
}
