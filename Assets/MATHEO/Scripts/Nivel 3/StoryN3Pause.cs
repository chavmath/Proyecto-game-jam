using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryN3Pause : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu, text1, text2, text3, text4, text5, text6;
	[SerializeField] AudioSource audioSource; // Asegúrate de asignar esto en el editor

	private void Start()
	{
		// Asegúrate de tener asignado el AudioSource en el editor
		if (audioSource == null)
		{
			Debug.LogError("AudioSource no está asignado. Asígnalo en el editor.");
		}
	}

	public void Pause()
	{
		pauseMenu.SetActive(true);
		text1.SetActive(false);
		text2.SetActive(false);
		text3.SetActive(false);
		text4.SetActive(false);
		text5.SetActive(false);
		text6.SetActive(false);
		Time.timeScale = 0;

		if (audioSource != null && audioSource.isPlaying)
		{
			audioSource.Pause();
		}
	}

	public void Skip()
	{
		SceneManager.LoadScene("Nivel 3");
		Time.timeScale = 1;

		if (audioSource != null && audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;

		if (audioSource != null && audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public void Continue()
	{
		pauseMenu.SetActive(false);
		text1.SetActive(true);
		text2.SetActive(true);
		text3.SetActive(true);
		text4.SetActive(true);
		text5.SetActive(true);
		text6.SetActive(true);
		Time.timeScale = 1;

		if (audioSource != null && !audioSource.isPlaying)
		{
			audioSource.Play();
		}
	}
}
