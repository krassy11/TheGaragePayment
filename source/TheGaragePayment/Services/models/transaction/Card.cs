using Newtonsoft.Json;

public class Card
{
    private string type;

    private string name;

    private string number;

    [JsonProperty(PropertyName = "expiryDt")]
    private string expiryDt;

    private string cvv;

    public string getType()
    {
        return type;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getNumber()
    {
        return number;
    }

    public void setNumber(string nmber)
    {
        this.number = nmber;
    }

    public string getExpiryDt()
    {
        return expiryDt;
    }

    public void setExpiryDt(string expiryDt)
    {
        this.expiryDt = expiryDt;
    }

    public string getCvv()
    {
        return cvv;
    }

    public void setCvv(string cvv)
    {
        this.cvv = cvv;
    }
}
