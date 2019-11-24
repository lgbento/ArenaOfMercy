using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
	{
		EditorSceneManager.LoadScene("Nivel1");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
