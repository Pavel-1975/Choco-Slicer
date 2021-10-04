//C:\Users\Vektorrus\AppData\LocalLow\DefaultCompany\Choco Slicer
[System.Serializable]
public class SaveGameData
{
    public int CurrentLevel;
    public int TotalScore;
    public int NewHighScore;


    public SaveGameData(SaveGame saveGame)
    {
        SaveDataPlayer(saveGame.Player);
    }

    private void SaveDataPlayer(Player player)
    {
        CurrentLevel = player.CurrentLevel;
        TotalScore = player.TotalScore;
        NewHighScore = player.NewHighScore;
    }
}
