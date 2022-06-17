using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddNewScene : MonoBehaviour
{
	public string LevelName;
	// Use this for initialization
	void Start()
	{
		if (LevelName.Length > 0)
		{
			Application.LoadLevelAdditive(LevelName);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}