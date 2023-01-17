using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingNumber : MonoBehaviour
{

    [SerializeField] private PlayfabManager _playfabManager;
    [SerializeField] private SetNumber _setNumber;

    private int _iteks1;
    private int _iteks2;
    private int _iteks3;

    private void Start()
    {
        SetText(budi: 0, ipin: 0, ibnu: 0);
    }

    public void SetText(int budi, int ipin, int ibnu)
    {
        _iteks1 = budi;
        _iteks2 = ipin;
        _iteks3 = ibnu;

        SyncToTeks();
    }

    public void AddTeks1()
    {
        FetchCurrentData();

        _iteks1++;

        SyncToTeks();
    }
    public void AddTeks2()
    {
        FetchCurrentData();

        _iteks2++;

        SyncToTeks();
    }
    public void AddTeks3()
    {
        FetchCurrentData();

        _iteks3++;

        SyncToTeks();
    }

    public void SubTeks1()
    {
        FetchCurrentData();

        _iteks1--;

        SyncToTeks();
    }
    public void SubTeks2()
    {
        FetchCurrentData();

        _iteks2--;

        SyncToTeks();
    }

    public void SubTeks3()
    {
        FetchCurrentData();

        _iteks3--;

        SyncToTeks();
    }

    private void FetchCurrentData()
    {
        _iteks1 = _setNumber.Iteks1;
        _iteks2 = _setNumber.Iteks2;
        _iteks3 = _setNumber.Iteks3;
    }

    public void SaveData()
    {
        _playfabManager.SaveDataTeman(budi: _iteks1, ipin: _iteks2, ibnu: _iteks3);
    }

    public void GetData()
    {
        _playfabManager.GetDataTeman();
    }

    private void SyncToTeks()
    {
        _setNumber.SyncToTeks(_iteks1, _iteks2, _iteks3);
    }
}
