using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N3Scene : MonoBehaviour
{
	private void OnEnable()
	{
		SceneManager.LoadScene("Nivel 3");
	}
}
