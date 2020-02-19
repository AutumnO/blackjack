using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public CardStack dealer;
    public CardStack player;

    // int count = 0;
    // int[] cards = new int[] { 9, 12, 7 };

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 256, 28), "Hit Me!"))
        {
            player.Push(dealer.Pop());
            // player.Push(cards[count++]);
        }
    }
}
