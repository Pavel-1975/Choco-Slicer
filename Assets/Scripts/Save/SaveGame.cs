using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Player Player;


    public void OnSaveGame()
    {
        SaveLoad.SaveGame(GetComponent<SaveGame>());       
    }
}
