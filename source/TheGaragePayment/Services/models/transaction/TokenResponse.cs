public class TokenResponse : CommonResponse
{
    public TokenResponse()
        : base()
    {
        //super();
    }
    private string type;

    private string transactionId;

    private string transactionTag;

    private string avs;

    private Transarmor token;

    private Card card;

    public string getType()
    {
        return type;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    public Transarmor getToken()
    {
        return token;
    }

    public void setToken(Transarmor token)
    {
        this.token = token;
    }

    public Card getCard()
    {
        return card;
    }

    public void setCard(Card card)
    {
        this.card = card;
    }

    public string getAvs()
    {
        return avs;
    }

    public void setAvs(string avs)
    {
        this.avs = avs;
    }
}