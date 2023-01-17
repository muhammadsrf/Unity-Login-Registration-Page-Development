using UnityEngine;

public class NewAddingNumber : MonoBehaviour
{
    [SerializeField] private PlayfabManager _playfabManager;
    [SerializeField] private SetNumber _setNumber;

    private NumberData _numberData;

    private void Start()
    {
        SetText(budi: 0, ipin: 0, ibnu: 0);
    }

    public void SetText(int budi, int ipin, int ibnu)
    {
        _numberData = new NumberData(budi, ipin, ibnu);
        SyncToTeks();
    }

    public void AddTeks1()
    {
        FetchCurrentData();
        PerformOperation("iteks1", "add");
    }
    public void AddTeks2()
    {
        FetchCurrentData();
        PerformOperation("iteks2", "add");
    }
    public void AddTeks3()
    {
        FetchCurrentData();
        PerformOperation("iteks3", "add");
    }

    public void SubTeks1()
    {
        FetchCurrentData();
        PerformOperation("iteks1", "subtract");
    }
    public void SubTeks2()
    {
        FetchCurrentData();
        PerformOperation("iteks2", "subtract");
    }

    public void SubTeks3()
    {
        FetchCurrentData();
        PerformOperation("iteks3", "subtract");
    }

    private void FetchCurrentData()
    {
        _numberData = _setNumber.GetData();
    }

    public void SaveData()
    {
        _playfabManager.SaveDataTeman(_numberData.Budi, _numberData.Ipin, _numberData.Ibnu);
    }

    public void GetData()
    {
        _playfabManager.GetDataTeman();
    }

    private void SyncToTeks()
    {
        _setNumber.SyncToTeks(_numberData.Budi, _numberData.Ipin, _numberData.Ibnu);
    }

    private void PerformOperation(string variableName, string operation)
    {
        int value = 0;
        switch (variableName)
        {
            case "iteks1":
                value = _numberData.Budi;
                break;
            case "iteks2":
                value = _numberData.Ipin;
                break;
            case "iteks3":
                value = _numberData.Ibnu;
                break;
        }

        switch (operation)
        {
            case "add":
                value++;
                break;
            case "subtract":
                value--;
                break;
        }

        switch (variableName)
        {
            case "iteks1":
                _numberData.Budi = value;
                break;
            case "iteks2":
                _numberData.Ipin = value;
                break;
            case "iteks3":
                _numberData.Ibnu = value;
                break;
        }

        SyncToTeks();
    }
}

public class NumberData
{
    public int Budi { get; set; }
    public int Ipin { get; set; }
    public int Ibnu { get; set; }

    public NumberData(int budi, int ipin, int ibnu)
    {
        Budi = budi;
        Ipin = ipin;
        Ibnu = ibnu;
    }
}