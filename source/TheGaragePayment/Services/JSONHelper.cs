//This data can be converted to json format using jQuery.parseJSON.

// var obj = JSON.parse(data);
//then we can access data like

// obj[0].id
//thanks to all.


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TheGarage.Services.Payment
//{
//    /**
//     * Helps in converting an object to JSON and vice versacs
//     */
//    public class JSONHelper
//    {

//        public string getJSONObject(Object data) 
//        {
//            ObjectMapper objectMapper = new ObjectMapper();
//        objectMapper.setSerializationInclusion(JsonInclude.Include.NON_NULL);
//        ByteArrayOutputStream byteStream = new ByteArrayOutputStream();
//        OutputStream stream = new BufferedOutputStream(byteStream);
//        JsonGenerator jsonGenerator =
//            objectMapper.getFactory().createGenerator(stream,
//                                                              JsonEncoding.UTF8);
//        // mapper.getSerializationConfig();
//        objectMapper.writeValue(jsonGenerator, data);
//        // mapper.writeValue(stream, payload);
//        stream.flush();
//        return new String(byteStream.toByteArray());
//    }

//    public <Type> Type fromJson(String jsonInput, Class<Type> classType)
//    {
//        Type obj = null;
//        try
//        {
//            ObjectMapper mapper = new ObjectMapper();
//            obj = mapper.readValue(jsonInput, classType);
//        }
//        catch (JsonParseException parseException)
//        {
//            parseException.printStackTrace();
//        }
//        catch (Exception e)
//        {
//            e.printStackTrace();
//        }
//        return obj;
//    }
//}
