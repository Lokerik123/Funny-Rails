using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormScript : MonoBehaviour
{
    private float timeSinceLastClick;
    private int PhraseInt;
    [SerializeField] private Text PhraseText;
    private void Start()
    {
        PhraseInt = 0;
        timeSinceLastClick = 0f;
    }
    void Update()
    {
        timeSinceLastClick -= Time.deltaTime;
        if (timeSinceLastClick < 0f)
        {
            PhraseText.text = "";
        }
    }

    public void OnClickWiseTree()
    {
        if(GameScript.dialog == 1) { timeSinceLastClick = 10f; PhraseText.text = "I have seen you talking with that tree."; return; }
        if (timeSinceLastClick < 0f)
        {
            timeSinceLastClick = 10f;
            SayPhrase();
            PhraseInt++;
        }
    }
    private void SayPhrase()
    {
        GameScript.dialog = 2;
        if (PhraseInt == 0)
        {
            PhraseText.text = "Welcome to my world.";
        }
        if (PhraseInt == 1)
        {
            PhraseText.text = "I hope you like it.";
        }
        if (PhraseInt == 2)
        {
            PhraseText.text = "You can do anything you want here.";
        }
        if (PhraseInt == 3)
        {
            PhraseText.text = "But remember ONE thing.";
        }
        if (PhraseInt == 4)
        {
            PhraseText.text = "NEVER, NEVER TALK TO THAT TREE.";
        }
        if (PhraseInt == 5)
        {
            PhraseText.text = "And another thing.";
        }
        if (PhraseInt == 6)
        {
            PhraseText.text = "There is no train, we just don't have a sprite for it.";
        }
    }
}
