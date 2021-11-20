using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
	public Text NameText;
	
	public Text ScoreText;
	
	public string playerName;
    
	public GameObject scoreManager;
	
	public void Start()
	{
		if (ScoreManager.Instance.PlayerName != null)
		{ScoreText.text = "High Score: " + ScoreManager.Instance.KeptName + " : " + ScoreManager.Instance.KeptScore; }	
	}
	
	public void StartNew()
	{
		playerName = NameText.text.ToString();
		ScoreManager.Instance.PlayerName = playerName;
		SceneManager.LoadScene(1);
		
		
	}
	
	public void Exit()
	{
		
		#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
		#else
		Application.Quit();
		#endif
		;
	}
}
