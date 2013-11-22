Using Quickteller Payment SDK for Windows Phone 8
================================================================

Quickteller Payment SDK for Windows Phone 8 let you easily add payment capability into your Windows Phone 8 application. To get the SDK, visit the NuGet package URL: http://www.nuget.org/packages/Quickteller.Sdk.Wp8/. The steps below describe how you can go about integrating the SDK into your application.

Registering you application on the Developer Console
----------------------------------------------------

To begin integration with the Quickteller for Windows Phone 8 SDK, you have to register your application on the Developer Console. To do this, follow the steps below:

1.	Go to http://developer.interswitchng.com and sign up by clicking on the Get Started button. Fill the form presented to you and click on sign up. You will get an email to the address you supplied during registration asking you to confirm your registration. Follow the link to confirm your registration and you will be logged in.

2.	Welcome to Interswitch Developer Network. Click on “Create Your First App” to create credentials for your first Interswitch App. Creating the App will provide you the basic requirement to use Interswitch SDKs. You need to supply the following information:

	App Name (required): A desired name for your app, e.g. BlueCups App
	
	Company Name (required): The name of the company that owns the application. E.g Blue Cups Ltd
	
	Company Logo - Your App logo (optional): (Note that there is a limit to the size you can upload and it is expected to be 200 x 200 pixels)
	
	Merchant ID (optional): If you are a WebPAY merchant already, enter your Merchant ID here, otherwise ignore this field.
	
	Description (required): A short message introducing your App to its users. Basically, tell us what it does, the owner etc.	
	
3.	Click on Submit button. Once you have done this, you will see a page displaying your credentials.

4.	Click on 'Manage' button at the top right conner. On this page under 'Details' section you will see your client id and your secret key. This will be needed in the SDK. On the 'Services' section turn on the 'QuickTeller Wallet Services' and 'QuickTeller Service' for your application. Note: without turning on this two services your application will throw access denied error.  

5	Now that all is set, just go ahead and build your application.

Downloading and Installing the SDK
----------------------------------

Visit our Nuget package page at http://www.nuget.org/packages/Quickteller.Sdk.Wp8. Then follow either of the two instructions bellow:

1. Inside Visual Studio, select your project in the Solution Explorer, then go to VIEW menu --> Other Windows --> Package Manager Console. On the console type: 
Install-Package Quickteller.Sdk.Wp8
…and press Enter.

2. Go to your Solution Explorer, right-click on “References” then select “Manage NuGet Packages…” On the pop-up click “Online” at the left-hand-side, then on the search menu, type “Quickteller” and select “Quickteller Payment SDK for Windows Phone 8” then click “Install”.
 

Using the SDK in your project
-----------------------------

1. Add the using statement for the SDK in your code:
	
		using Quickteller.Sdk.Wp8;

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

4. Call the method DoPayment() method on the QuicktellerPayment object. Check the sample below:

			var amount = 10000; //payment amount in kobo e.g. 10000=N100.00
			var quicktellerPayment = new QuicktellerPayment(this, "10402", amount,  "0000000001", CLIENT_ID, CLIENT_SECRET);
			quicktellerPayment.OnPaymentCompleted += (code, message) => {}
			quicktellerPayment.OnPaymentException += (exception) => {}
			await quicktellerPayment.DoPaymentAsync();
			
5. That is all, go ahead and implement your application as you please. Enjoy!
