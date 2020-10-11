using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private InputField nameInput, commandInput, chanceInput;

    [SerializeField]
    private Text infoText;

    [SerializeField]
    private Clown clownPrefab;

    private Clown activeClown;


    [SerializeField]
    private string createCommand, killCommand;




    private void Awake()
    {
        nameInput.onEndEdit.AddListener(delegate { ChangeName(nameInput.text); });
        commandInput.onEndEdit.AddListener(delegate { ProcessCommand(commandInput.text); });
        chanceInput.onEndEdit.AddListener(delegate { ExplodeChance(chanceInput.text); });
    }


    private void ExplodeChance(string chanceAsString)
    {
       if(float.TryParse(chanceAsString, out float chance))
        {
            if(chance > Random.Range(0f, 100f))
            {
                if(activeClown != null)
                {
                    infoText.text = "The clown exploded";
                    activeClown.Explode();

                }
            }
            else if (activeClown != null)
            {
                infoText.text = "The clown got lucky. Try again";
            }

        }


    }




    public void ChangeName(string newName)
    {
        if (activeClown != null)
            activeClown.ChangeName(newName);
    }



    public void ProcessCommand(string command)
    {
        if (command == createCommand)
        { if (activeClown == null)
            {
                activeClown = Instantiate(clownPrefab);
                activeClown.transform.position = new Vector2(0.91f, -3.14f);
                infoText.text = "You have created a new clown! Be proud! Maybe you would like to kill him?";
            }
            else
            {
                infoText.text = "There already is a clown, why would you want 2 clowns???";
            }
        }
        else if( command == killCommand)
        {
            if(activeClown != null)
            {
                activeClown.Explode();
                infoText.text = activeClown.clownName + " has exploded. May he rest in clown heaven";
                activeClown = null;
            }



        }



    }







}
