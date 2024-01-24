using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story_Scene : MonoBehaviour
{
	private void OnEnable()
	{
		SceneManager.LoadScene("Nivel 1 Story");
	}
}
