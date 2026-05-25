using System;
using UnityEngine;
public enum Polarity
{
    Blue, Red, Count
}
public class ObjectPolarity : MonoBehaviour
{
    private Action<Polarity> OnPolarityChange;
    Polarity polarity;
    public Polarity GetPolarity()
    {
        return polarity;
    }

    public void SetPolarity(Polarity polar)
    {
        polarity = polar;
        OnPolarityChange?.Invoke(polarity);
    }

    public void ChangePolarity()
    {
        polarity = polarity == Polarity.Blue ? Polarity.Red : Polarity.Blue;
        OnPolarityChange?.Invoke(polarity); 
    }
    public void AddPolarityListener(Action<Polarity> action)
    {
        OnPolarityChange -= action;
        OnPolarityChange += action;
    }
    public void RemovePolarityListener(Action<Polarity> action)
    {
        OnPolarityChange -= action;
    }
}

