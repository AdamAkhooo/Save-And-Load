using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistenDataPath + "/player.file";
        FileStream stream = new FileStream(path, FileMode.Create);


        PlayerData data = new PlayerData(player);


        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistenDataPath + "/player.file";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
        }else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}
