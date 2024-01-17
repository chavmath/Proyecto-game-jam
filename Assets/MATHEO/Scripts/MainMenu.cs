using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audiomixer;
	public void ExitButton()
	{
		Application.Quit();
		Debug.Log("Game closed");
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Nivel1");
	}
	public void SetVolume(float volume)
	{
		audiomixer.SetFloat("volume", volume);
	}
}