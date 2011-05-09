# Facebook.Extensions.Tasks

## Overview
This library takes the asynchorous programming with [Facebook C# SDK](http://facebooksdk.codeplex.com) 
to the next level by adding extension methods to FacebookClient and FacebookOAuthClient which returns
Task&lt;object&gt;

## Requirements
* [Microsoft Visual Studio Async CTP (SP1 Refresh)](http://msdn.microsoft.com/en-us/vstudio/async.aspx)
* .NET 4.0 or Silverlight 4 or Windows Phone 7 (.NET 3.5 is not supported)

## Getting Started
Reference Facebook.Extensions.Tasks.dll which adds extension methods to FacebookClient and FacebookOAuthClient.
To prevent conflicts from existing async methods, these extension methods start with HttpMethod type and
ends with **TaskAsync( ... )**. Even though the dll name is "Facebook.Extensions.Tasks.dll" these extension
methods are under the "Facebook" namespace.

Extension methods available for FacebookClient:

	GetTaskAsync( ... )
	PostTaskAsync( ... )
	DeleteTaskAsync( ... )

Extension methods available for FacebookOAuthClient:

	GetApplicationAccessTokenTaskAsync( ... )
	ExchangeCodeForAccessTokenTaskAsync( ... )

## Samples
Full samples can be found under the "samples" folder in the source code.

### Using with Task Parallel Library (TPL)

	private static void ExecuteAsyncMethod()
	{
		var fb = new FacebookClient();
		var task = fb.GetTaskAsync("/4");

		task.ContinueWith(
			t =>
			{
				if (t.Exception == null)
				{
					dynamic result = t.Result;
					Console.WriteLine("Name: {0}", result.name);
				}
				else
				{
					Console.WriteLine("error occurred");
				}
			});
	}


Note: If you are running the above code under .NET 4.0, you don't need to reference the Async libraries
as Task Parallel Library (TPL) comes bundled with .NET 4.0. For Silverlight and Windows Phone 7 Async libraries
(AsyncCtpLibrary\_Silverlight.dll or AsyncCtpLibrary\_Phone.dll) must be referenced as TPL is not present.

### Using with async and await

	private async static void ExecuteAsyncMethod()
	{
		var fb = new FacebookClient();

		try
		{
			dynamic result = await fb.GetTaskAsync("/4");

			Console.WriteLine("Name: {0}", result.name);
		}
		catch (FacebookApiException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

Note: Reference the appropriate Async libraries (AsyncCtpLibrary.dll or AsyncCtpLibrary\_Silverlight.dll or 
AsyncCtpLibrary\_Phone.dll). You need to reference AsyncCtpLibrary.dll for .NET 4.0 also in this case unlike
the example with TPL.

## License
Facebook.Extensions.Tasks is intended to be used in both open-source and commercial environments. It is licensed
under Microsoft Public License (Ms-PL).