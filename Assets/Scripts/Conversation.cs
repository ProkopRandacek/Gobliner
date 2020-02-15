using UnityEngine;
using System.Collections.Generic;

public class Conversation
{
    public string[] Texts;
    public int pos = -1;

    public Conversation(string[] texts)
    {
        Texts = texts;
    }

    public string Next()
    {
        pos++;
        if (pos > Texts.Length - 1)
            return null;
        return Texts[pos];
    }
}
