Adding payment to your application using Quickteller Windows Phone 8 SDK
================================================================

Quickteller Windows Phone 8 SDK let you easily add payment capability into your Windows Phone 8 application. To get the SDK, visit the NuGet package URL: http://www.nuget.org/packages/Quickteller.Sdk.Wp8/. The steps below describe how you can go about integrating the SDK into your application.

Registering you application on the Developer Console
----------------------------------------------------

To begin integration with the Quickteller for Windows Phone 8 SDK, you have to register your application on the Developer Console. To do this, follow the steps below:

1. Go to the Developer Console on http://developer.interswitch.com Sign-up if you haven’t. If you have, log-in to gain access to your console.
2. Click on the API Console tab on top of the page, and then click on the API Access link on the left hand side of the page.
3. There would be two tabs on the main pane: “Sandbox” and “Production”. The “Sandbox” tab is used for creating keys for test applications, while the “Production” tab is for creating keys for production applications. You can’t move “Sandbox” keys to “Production”, after testing them; you’ll have to recreate them.
4. To create a new key, click on the “Create new key” button on either “Staging” or “Production” tab, and fill out the required information.
5. Now you have your keys, you can continue with the steps below.

Downloading and Installing the SDK
----------------------------------

To use the SDK, follow either of the two steps below:

1. Visit http://www.nuget.org/packages/Quickteller.Sdk.Wp8/, to get the instructions on how to install the SDK. Then on your Visual Studio, Go to VIEW menu --> Other Windows --> Package Manager Console. On the console type: 
Install-Package Quickteller.Sdk.Wp8
…and press Enter.
2. Go to your Solution Explorer, right-click on “References” then select “Manage NuGet Packages…” On the pop-up click “Online” at the left-hand-side, then on the search menu, type “Quickteller” and select “Quickteller Payment SDK for Windows Phone 8” and click “Install”.
 

Using the SDK in your project
-----------------------------

1. Add the using statement for the SDK in your code:
	
		using Quickteller.Payment.Sdk;

2. Initialize the QuicktellerPayment class as given: 

		var quicktellerPayment = new QuicktellerPayment(PhoneApplicationPage parent, string paymentCode, long amount, string customerId, string clientId, string clientSecret[, bool isTestPayment = true]);

	The meanings of the parameters are:

	+ PhoneApplicationPage parent – This refers to the page hosting the SDK, the page where you want the SDK pop-up screen to show-up over.
	+ string paymentCode – This refers to the payment code for the item which you want to pay for. To get a payment code, go to your Developer Console and register a new item. You’ll automatically get a payment code for the item.
	+ long amount – This refers to the amount of money you need the user of your application to pay.
	+ string customerId – This refers to the id of the customer who I trying to perform the payment on your application. It is usually issued by you and it can be anything.
	+ string clientId – This refers to the client ID you got from Developer Console for the particular application that you are developing.
	+ string clientSecret – This refers to the secret key you got from Developer Console for the particular application that you are developing.
	+ bool isTestPayment – This is an optional parameter that is set when switching from test implementation to production environment. It is true by default which means that you are running in the test implementation. NOTE: it’s very important to set the value to false in a live distribution.

3. Add handlers to the following events: OnPaymentCompleted and OnPaymentException, on the QuicktellerPayment object. Sample code is given thus:

		quicktellerPayment.OnPaymentCompleted += (string code, string message) => {}
		quicktellerPayment.OnPaymentException += (Exception exception) => {}

4. Call the method DoPaymentAsync()on the QuicktellerPayment object. As a long-running process, the method returns System.Threading.Tasks.Task. So it’s meant to be called with the C# 5.0 await keyword so that the compiler can optimize for concurrency. The best way to implement it is to embed it into a method defined as async and then call it with the await keyword, as shown below:

		private async void PerformPaymentOperation(long amount)
		{
			var quicktellerPayment = new QuicktellerPayment(this, "10402", amount,  "0000000001", CLIENT_ID, CLIENT_SECRET);
			quicktellerPayment.OnPaymentCompleted += (code, message) => {}
			quicktellerPayment.OnPaymentException += (exception) => {}
			await quicktellerPayment.DoPaymentAsync();
		}

	Then call this method whenever you want to invoke the payment SDK. Both the SDK and .NET would handle the rest.

5. Go ahead and implement your application as you please.
