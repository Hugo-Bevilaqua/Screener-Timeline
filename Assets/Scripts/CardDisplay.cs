using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    public TextMeshProUGUI cardStep;

    public void SetUnknown()
    {
        Debug.Log(cardName.text);
    }



    void Start()
    {
        cardName.text=card.cardName;
        cardDescription.text=card.description;
        cardStep.text=card.step.ToString();
    }
    

}
