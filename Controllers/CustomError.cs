using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API.Controllers
{
	public class CustomError : ObjectResult
	{
		public CustomError(object value) : base(value)
		{
		}
		
		public ActionResult CustomOk(object value)
		{
			var result = new CustomError(value);
			result.StatusCode = 200;
			return result;
		}

		public ActionResult CustomeCreated(object value)
		{
			var result = new CustomError(value);
			result.StatusCode = 201;
			return result;
		}

		public ActionResult CustomNotFound(string message)
		{
			var result = new CustomError(message);
			result.StatusCode = 404;
			return result;
		}

		public ActionResult CustomBadRequest(string message)
		{
			var result = new CustomError(message);
			result.StatusCode = 400;
			return result;
		}


	}
}
