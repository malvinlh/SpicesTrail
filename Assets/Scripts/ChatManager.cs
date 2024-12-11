using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public ChatBubble playerChatBubble;
    public ChatBubble enemyChatBubble;
    public ChatBubble allyChatBubble;
    public string[] playerTexts;
    public string[] enemyTexts;
    public string[] allyTexts;

    public void StartPlayerChat(int playerTextIndex)
    {
  
        playerChatBubble.Setup(playerTexts[playerTextIndex]);
    }

    public void StartEnemyChat(int enemyTextIndex)
    {
        enemyChatBubble.Setup(enemyTexts[enemyTextIndex]);
    }

    public void StartAllyChat(int allyTextIndex)
    {
        allyChatBubble.Setup(allyTexts[allyTextIndex]);
    }
}