public class Token
{
    private string tokenType;
    
    private Transarmor tokenData;

    public string getTokenType()
    {
        return tokenType;
    }

    public void setTokenType(string tokenType)
    {
        this.tokenType = tokenType;
    }

    public Transarmor getTokenData()
    {
        return tokenData;
    }

    public void setTokenData(Transarmor tokenData)
    {
        this.tokenData = tokenData;
    }
}
