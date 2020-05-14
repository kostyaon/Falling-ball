using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/playerData.toxa";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void SavePlayerData(Player player)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(fs, data);
        fs.Close();

    } 

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            PlayerData data = null;
            Debug.LogError("There is no save file in" + path);
            return null;
        }
    }
}
