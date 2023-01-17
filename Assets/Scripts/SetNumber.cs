using System;
using UnityEngine;
using UnityEngine.UI;

public class SetNumber : MonoBehaviour
{
    [SerializeField] private Text _teks1;
    [SerializeField] private Text _teks2;
    [SerializeField] private Text _teks3;

    public int Iteks1;
    public int Iteks2;
    public int Iteks3;

    public void SyncToTeks(int iteks1, int iteks2, int iteks3)
    {
        Iteks1 = iteks1;
        Iteks2 = iteks2;
        Iteks3 = iteks3;

        _teks1.text = iteks1.ToString();
        _teks2.text = iteks2.ToString();
        _teks3.text = iteks3.ToString();
    }

    public void SyncToTeks(string iteks1, string iteks2, string iteks3)
    {
        Iteks1 = int.Parse(iteks1);
        Iteks2 = int.Parse(iteks2);
        Iteks3 = int.Parse(iteks3);

        _teks1.text = iteks1;
        _teks2.text = iteks2;
        _teks3.text = iteks3;
    }

    public NumberData GetData()
    {
        NumberData numberData = new NumberData(budi: Iteks1, ipin: Iteks2, ibnu: Iteks3);

        return numberData;
    }
}