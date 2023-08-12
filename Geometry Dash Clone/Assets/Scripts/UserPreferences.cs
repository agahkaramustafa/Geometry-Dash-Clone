using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPreferences : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private const string VOLUME_KEY = "volume";

    private void Awake()
    {
        // Sets the volume slider to the value stored in PlayerPrefs.
        volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);
    }

    void Start()
    {
        // Adds a listener to the main slider and invokes a method when the value changes.
		volumeSlider.onValueChanged.AddListener (delegate {ValueChangeProcess ();});
    }

    public void ValueChangeProcess()
	{
        // Saves the value of the slider in
        // PlayerPrefs when the value changes.

		PlayerPrefs.SetFloat(VOLUME_KEY, volumeSlider.value);
        PlayerPrefs.Save();
        
	}
}
