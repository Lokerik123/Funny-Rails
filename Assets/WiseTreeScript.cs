using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiseTreeScript : MonoBehaviour
{
    private float timeSinceLastClick;
    private int PhraseInt;
    [SerializeField] private Text PhraseText;
    private void Start()
    {
        PhraseInt= 0;
        timeSinceLastClick= 0f;
    }
    void Update()
    {
        timeSinceLastClick -=Time.deltaTime;
        if(timeSinceLastClick< 0f )
        {
            PhraseText.text = "";
        }
    }

    public void OnClickWiseTree()
    {
        if (GameScript.dialog == 2) { timeSinceLastClick = 10f; PhraseText.text = "My disappointment is immeasurable."; return; }
        if (timeSinceLastClick < 0f)
        {
            timeSinceLastClick = 10f;
            SayPhrase();
            PhraseInt++;
        }
    }
    private void SayPhrase()
    {
        GameScript.dialog = 1;
        if (PhraseInt == 0)
        {
            PhraseText.text = "I am not a regular tree. I am wise tree.";
        }
        if (PhraseInt == 1)
        {
            PhraseText.text = "I had a long life and I know many things.";
        }
        if (PhraseInt == 2)
        {
            PhraseText.text = "I will give you a good advice, my friend.";
        }
        if (PhraseInt == 3)
        {
            PhraseText.text = "Words are the best weapon.";
        }
        if (PhraseInt == 4)
        {
            PhraseText.text = "You can heal with kind words. And kill with the bad ones.";
        }
        if (PhraseInt == 5)
        {
            PhraseText.text = "But even WORDS can't stop a train...";
        }
        if (PhraseInt ==6)
        {
            PhraseText.text = "Don't say any word to that worm.";
        }
    }
}
