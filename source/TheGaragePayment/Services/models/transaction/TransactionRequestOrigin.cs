//package com.firstdata.payeezy.models.transaction;

//import com.fasterxml.jackson.annotation.JsonAutoDetect;
//import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
//import com.fasterxml.jackson.annotation.JsonInclude;
//import com.fasterxml.jackson.annotation.JsonProperty;

///**
// * Created by FA7G14Q on 6/30/2015.
// */
//@JsonAutoDetect(getterVisibility= JsonAutoDetect.Visibility.DEFAULT,setterVisibility= JsonAutoDetect.Visibility.DEFAULT,fieldVisibility= JsonAutoDetect.Visibility.ANY)
//@JsonIgnoreProperties(ignoreUnknown = true)
//@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class TransactionRequestOrigin
{
    private string ipAddress;

    private string host;

    private string deviceId;

    public string getIpAddress()
    {
        return ipAddress;
    }

    public void setIpAddress(string ipAddress)
    {
        this.ipAddress = ipAddress;
    }

    public string getHost()
    {
        return host;
    }

    public void setHost(string host)
    {
        this.host = host;
    }

    public string getDeviceId()
    {
        return deviceId;
    }

    public void setDeviceId(string deviceId)
    {
        this.deviceId = deviceId;
    }
}
