using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ByggString : MonoBehaviour
{
    private string username;
    public TMP_Text usernameText;

    private void Update()
    {
        usernameText.text = username;
    }
    public void BuildString(string letter)
    {
        username += letter;
    }

    public static void WriteToFile()
    {
        string path = Application.persistentDataPath + "/Leaderboard.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine();
        writer.Close();
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();

    }

    public static void ReadString()
    {
        string path = Application.persistentDataPath + "/Leaderboard.txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    
}
