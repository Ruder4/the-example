using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

    public void SetMusicVolume(float volume)
	{
		audioMixer.SetFloat("MusicVolume", volume);
	}

	public void SetSFXVolume(float volume)
	{
		audioMixer.SetFloat("SFXVolume", volume);
	}

	public void SetFullscreen(bool fullscreen)
	{
		Screen.fullScreen = fullscreen;
	}
}
