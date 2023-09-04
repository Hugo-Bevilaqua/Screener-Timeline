using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPlacer : MonoBehaviour
{
    public List<GameObject> cards;
    public GameObject cardStartArea;
    public GameObject nextCardStartArea;
    private int i = 0;
    private List<int> seed = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
    private List<int> checklist = new List<int> {};
    private GameObject lastCardTouched;
    public GameObject GameOverPopUp;
    private int MistakeCount;
    public GameObject StopWatch;
    
    public static bool IsSorted(List<int> Test){
        for (int x = 1; x < Test.Count; x++){
            if (Test[x - 1] > Test[x]){
                return false;
            }
        }
        return true;
    }

    void Start()
    {
        for (int x = 0; x < seed.Count; x++) {
            int temp = seed[x];
            int randomIndex = Random.Range(x, seed.Count);
            seed[x] = seed[randomIndex];
            seed[randomIndex] = temp;
        }

        MistakeCount=0;

        if(i==0){
            
            GameObject card = Instantiate(cards[seed[i]], new Vector2(0,0), Quaternion.identity);
            card.transform.GetChild(0).GetComponent<Image>().color = new Color32(0,255,0,255);
            card.transform.SetParent(cardStartArea.transform,false);
            card.transform.GetChild(4).gameObject.SetActive(false);

            i+=1;

            card = Instantiate(cards[seed[i]], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(nextCardStartArea.transform,false);            
            lastCardTouched=card;

            
            
        }
        StopWatch.GetComponent<Timer>().startbutton();
    }

    void Update()
    {


        if(cardStartArea.transform.childCount==(i+1) ){

            for(int x = 0; x<cardStartArea.transform.childCount; x++){
                checklist.Add(int.Parse(cardStartArea.transform.GetChild(x).GetChild(3).GetComponent<TMP_Text>().text));
            }
            if(IsSorted(checklist)){
                lastCardTouched.transform.GetChild(0).GetComponent<Image>().color = new Color32(0,255,0,255);
            }
            else{
                lastCardTouched.transform.GetChild(0).GetComponent<Image>().color = new Color32(255,0,0,255);
                checklist.Sort();
                lastCardTouched.transform.SetSiblingIndex(checklist.FindIndex(a => a == int.Parse(lastCardTouched.transform.GetChild(3).GetComponent<TMP_Text>().text)));
                MistakeCount+=1;
                //Debug.Log(MistakeCount);
            }





            i+=1;
            if(i<29 && MistakeCount<3){
                GameObject card = Instantiate(cards[seed[i]], new Vector2(0,0), Quaternion.identity);
                card.transform.SetParent(nextCardStartArea.transform,false);
                lastCardTouched=card;
            }
            
        }
        
        checklist.Clear();

        if(i==29 || MistakeCount>=3){
            StopWatch.GetComponent<Timer>().stopbutton();

            GameOverPopUp.SetActive(true);
            //Debug.Log("Ending mistakes:");
            //Debug.Log(MistakeCount);
            if(MistakeCount>=3){
                GameOverPopUp.transform.GetChild(0).GetComponent<TMP_Text>().text="Derrota";
            }
            else{
                GameOverPopUp.transform.GetChild(0).GetComponent<TMP_Text>().text="Sucesso";
            }
            GameOverPopUp.transform.GetChild(1).GetComponent<TMP_Text>().text = ( "Acertos: " + (i-MistakeCount).ToString() + "/29" );
            GameOverPopUp.transform.GetChild(2).GetComponent<TMP_Text>().text = ( "Tempo: " + StopWatch.GetComponent<Timer>().retTime() + "s" );

            //StopWatch.GetComponent<Timer>().resetbutton();
            //i+=1;
            //MistakeCount=-1;
        }
    }
}
