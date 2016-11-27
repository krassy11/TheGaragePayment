public class CommonResponse
{
    private string corrID;

    private string status;

    private string error;

    public string getCorrID()
    {
        return corrID;
    }

    public void setCorrID(string corrID)
    {
        this.corrID = corrID;
    }

    public string getStatus()
    {
        return status;
    }

    public void setStatus(string status)
    {
        this.status = status;
    }
}
