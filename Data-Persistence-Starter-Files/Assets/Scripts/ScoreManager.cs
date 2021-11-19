using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System.IO;

public class ScoreManager : MonoBehaviour
{
		public static ScoreManager Instance;

public string PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	 private void Awake()
    {
        if (Instance != null){
			Destroy(gameObject);
		return;}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		
		LoadColor();
    }

[System.Serializable]
class SaveData
{
    public string PlayerName;
}

public void SaveName()
{
	SaveData data = new SaveData();
	data.PlayerName = PlayerName;
	
	string json = JsonUtility.ToJson(data);
	
	File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadColor()
{
	string path = Application.persistentDataPath + "/savefile.json";
	if (File.Exists(path))
	{
		string json = File.ReadAllText(path);
		SaveData data = JsonUtility.FromJson<SaveData>(json);
		
		PlayerName = data.PlayerName;
	}
}
}
