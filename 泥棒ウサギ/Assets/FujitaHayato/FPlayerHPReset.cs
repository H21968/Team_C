using UnityEngine;

public class FPlayerHPReset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStatus.player_hp = 3;
        GameStatus.speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameStatus.player_hp = 3;
        }
        
    }
}
