using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer bgSpriteRenderer;
    private TextMeshPro textMeshPro;
    public ChatBubble playerChatBubble;
    public ChatBubble enemyChatBubble;
    public ChatBubble allyChatBubble;
    public ChatManager chatManager;
    private int playerChatIndex = 0;
    private int enemyChatIndex = 0;
    private int allyChatIndex = 0;

    private void Awake()
    {
        bgSpriteRenderer = transform.Find("ChatBackground").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("ChatText").GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        ProcessChat();
    }

    private void ProcessChat()
    {
        if (playerChatBubble != null && playerChatBubble.gameObject.activeSelf == true)
        {
            chatManager.StartPlayerChat(playerChatIndex);
            playerChatIndex++;       
        }
        else if (enemyChatBubble != null && enemyChatBubble.gameObject.activeSelf == true)
        {
            chatManager.StartEnemyChat(enemyChatIndex);
            enemyChatIndex++;
        }
        else if (allyChatBubble != null && allyChatBubble.gameObject.activeSelf == true)
        {
            chatManager.StartAllyChat(allyChatIndex);
            allyChatIndex++;
        }
    }

    public void Setup(string text)
    {
        textMeshPro.text = text;
        textMeshPro.ForceMeshUpdate();
        
        float textWidth = textMeshPro.GetPreferredValues(text).x;
        
        float newWidth = textWidth * 100 + 7;
        
        Vector2 currentSize = bgSpriteRenderer.size;
        
        bgSpriteRenderer.size = new Vector2(newWidth, currentSize.y);
    }
}