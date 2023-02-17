using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persistence : MonoBehaviour
{
    public static int bestScore = 0;
    public static string BestScoreUserName;

    public TMP_InputField userNameInputField;
    public TextMeshProUGUI bestScoreText;
    public static string currentUserName;

    public static Persistence Instance;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public void StartNewScene()
    {

        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScoe;
        public string userName;
    }

    public static void SaveUserData()
    {
        SaveData data = new SaveData();
        data.bestScoe = bestScore;
        data.userName = BestScoreUserName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScoe;
            BestScoreUserName = data.userName;
        }
    }

    public void UpdateAndDisplayUserBestScore()
    {
        currentUserName = userNameInputField.text;

        LoadUserData();
        bestScoreText.text = "Best score by " + BestScoreUserName + " is " + bestScore;
    }


    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
