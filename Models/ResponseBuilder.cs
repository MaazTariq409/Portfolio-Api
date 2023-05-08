namespace Portfolio_API.Models
{
	public class ResponseBuilder
	{
		public static ResponseObject GenerateResponse(string code, List<string> messages, object data = null)
		{
			ResponseObject responseObject = new ResponseObject();



			responseObject.Data = data;
			responseObject.Result.Code = code;
			responseObject.Result.Messages = messages;



			return responseObject;
		}

		public static ResponseObject GenerateResponse(string code, string message)
		{
			ResponseObject responseObject = new ResponseObject();



			responseObject.Result.Code = code;
			responseObject.Result.Messages = new List<string>();
			responseObject.Result.Messages.Add(message);



			return responseObject;
		}
	}
}
