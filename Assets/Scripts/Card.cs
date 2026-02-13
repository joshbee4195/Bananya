
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public int ID;
    public int Type;

    public GameControl Control;

    public Button button;

   // public GameControl gControl;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        Control = FindObjectOfType<GameControl>();
        //button.onClick(this);

        //  button.onClick += myMethod;


        //regular card
        if (ID == 0)
        {
            button.onClick.AddListener(CardClicked);

            button.onClick.AddListener(Control.PlayCard);
        }


        //in pirate display

        if (ID == 1)
        {
            button.onClick.AddListener(PirateCardClicked);

            button.onClick.AddListener(Control.PirateCard);
        }


        //in calico display
        if (ID == 2)
        {
            button.onClick.AddListener(PirateCardClicked);

          //  button.onClick.AddListener(Control.ChosenCardFromLitter(Type));

            button.onClick.AddListener(() => Control.ChosenCardFromLitter(Type));
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardClicked()
    {
        Control.playedCard = this;

        if (Control.Discard)
        {
            //discard this card
        }
    }

    public void PirateCardClicked()
    {
        Control.playedCard = this;

        if (Control.Discard)
        {
            //discard this card
        }
    }
}
