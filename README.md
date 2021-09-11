# AlertAPI
<p>This API is prepared in dot net Core 5.0 using visual studio 2019.</p>
<p>C# language is used for API development.</p>
<p>JWT authentication token system is used for user authentication.</p>
<p>We prepared one model class AlertData where email,currecny and alert price is posted by the user by post API /api/aleretdata/ with data in body.</p>
<p>One service backgroundprinter runs in the background whiche is inherited by IHostedService that runs in every 5 minutes.</p>
<p>It gets data by calling API for currency current price and then compare with alert price.<br /><br />If alert price is crossed then it send one Email to that user.</p>
<p>For sending Email I used EmailSender class which is inherited from dot net core inbuilt class IEmailSender .</p>
<p>SMTP parameters are set in appsetting.json file for sendinfg Email.</p>
<p><strong>Procedure to run the API</strong></p>
<p><strong>1.&nbsp;</strong>Run solution file CryptoCurrencyAlert.sln in visual studio.</p>
<p>2. Then create database by using update-database command in Package Manager console.</p>
<p>3. Run project in&nbsp; IIS express.</p>
<p>4.Then create username by using API post endpoint&nbsp; /api/authentication/register.</p>
<p>5. then login by same username and password using post endpoint /api/authentication/login.</p>
<p>6. Now post&nbsp; your alert price by using endpoints /api/alertdatas/ with alertdata data in body in json format.</p>
<p>7. Now background process will send Email if alert price is crossed.</p>
<hr />
3 schemas are made AlertDatas ,registerModel,UserModel <br>
<img src="screenshot/ss1.JPG" width=25% >

AlerData has 3 endpoints 
get-to get alert data
post- to set new alert
delete -to delete the set alert <br>

<img src="screenshot/ss2.JPG" width=25% >
Alertdatas/get <br>
<img src="screenshot/ss3.JPG" width=25% >
Alertdatas/delete <br>
<img src="screenshot/ss4.JPG" width=25% >
Authenticate for user authentication <br>

<img src="screenshot/ss5.JPG" width=25% >

<img src="screenshot/ss6.JPG" width=25% >
<img src="screenshot/ss7.JPG" width=25% >
 
 
 Anuj Gupta
 18BCE10044
