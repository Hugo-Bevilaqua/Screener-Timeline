using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Untitled Card", menuName="Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public int step;
}
