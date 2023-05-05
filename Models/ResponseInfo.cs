namespace Portfolio_API.Models
{
	public class ResponseInfo
	{
			public ResponseInfo()
			{
				Messages = new List<string>();
				Code = ResultCode.Failure.ToString();
			}

			public string Code { get; set; }

			public List<string> Messages { get; set; }
		
	}
}
