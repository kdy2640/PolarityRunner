using TMPro;
using UnityEngine;

public class PlayerPolarityVisualize : MonoBehaviour
{
    GameManager manager;
    TextMeshProUGUI text;
    public void Start()
    {
        manager = GameManager.GetInstance();
        text = GetComponent<TextMeshProUGUI>(); 
        manager.Player.AddPolarityListener(ChangePlayerPolarity);
        ChangePlayerPolarity(manager.Player.GetPolarity());
    }
    public void ChangePlayerPolarity(Polarity polar)
    {
        if(polar == Polarity.Blue)
        {
            text.color = Color.blue;
        }
        else if(polar == Polarity.Red)
        {
            text.color = Color.red;
        }
    }

}
