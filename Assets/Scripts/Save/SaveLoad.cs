//C:\Users\Vektorrus\AppData\LocalLow\DefaultCompany\Choco Slicer
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveLoad
{
    private static string _path = Application.persistentDataPath;

    private static BinaryFormatter _formatter = new BinaryFormatter();


    public static void SaveGame(SaveGame saveGame)
    {
        FileStream fs = new FileStream(_path + "/ChocoSlicer.dat", FileMode.Create);

        SaveGameData data = new SaveGameData(saveGame);

        _formatter.Serialize(fs, data);

        fs.Close();
    }


    public static SaveGameData LoadGame(string path = "/ChocoSlicer.dat")
    {
        if (File.Exists(_path + path))
        {
            FileStream fs = new FileStream(_path + path, FileMode.Open);

            SaveGameData data = _formatter.Deserialize(fs) as SaveGameData;

            fs.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
