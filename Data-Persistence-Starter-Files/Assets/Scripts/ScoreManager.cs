using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System.IO;

public class ScoreManager : MonoBehaviour
{
		public static ScoreManager Instance;

public string PlayerName;

public int KeptScore;
public string KeptName;
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
		
		LoadName();
    }

[System.Serializable]
class SaveData
{
    public string KeptName;
	public int KeptScore;
}

public void SaveName()
{
	SaveData data = new SaveData();
	data.KeptName = KeptName;
	data.KeptScore = KeptScore;
	
	string json = JsonUtility.ToJson(data);
	
	File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadName()
{
	string path = Application.persistentDataPath + "/savefile.json";
	if (File.Exists(path))
	{
		string json = File.ReadAllText(path);
		SaveData data = JsonUtility.FromJson<SaveData>(json);
		
		KeptName = data.KeptName;
		KeptScore = data.KeptScore;
	}
}
}
