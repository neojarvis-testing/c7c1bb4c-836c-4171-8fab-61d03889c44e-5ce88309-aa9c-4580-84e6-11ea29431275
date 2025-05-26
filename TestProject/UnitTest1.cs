using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

public class Tests
{
     private HttpClient _httpClient;
    private HttpClient _httpClient1;
    private HttpClient _httpClient2;
    private HttpClient _httpClient3;
    private HttpClient _httpClient4;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _httpClient1 = new HttpClient();
        _httpClient2 = new HttpClient();
        _httpClient3 = new HttpClient();        
        _httpClient4 = new HttpClient();

        _httpClient.BaseAddress = new Uri("http://localhost:8080");
        _httpClient1.BaseAddress = new Uri("http://localhost:8079");
        _httpClient2.BaseAddress = new Uri("http://localhost:8078");
        _httpClient3.BaseAddress = new Uri("http://localhost:8077");
        _httpClient4.BaseAddress = new Uri("http://localhost:8076");
    }


  [Test, Order(1)]
  public async Task Backend_Test_Post_Method_Register_Customer_Returns_HttpStatusCode_OK()
        {
            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            string responseString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    
  [Test, Order(2)]
  public async Task Backend_Test_Post_Method_Login_Customer_Returns_HttpStatusCode_OK()
        {

            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            // Print registration response
            string registerResponseBody = await response.Content.ReadAsStringAsync();

            // Login with the registered user
            string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
            HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

            // Print login response
            string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        }

      [Test, Order(3)]
        public async Task Backend_Test_Post_Method_Register_Manager_Returns_HttpStatusCode_OK()
        {
            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            // //Console.WriteLine(response.StatusCode);
            string responseString = await response.Content.ReadAsStringAsync();

            // //Console.WriteLine(responseString);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    
        [Test, Order(4)]
        public async Task Backend_Test_Post_Method_Login_Manager_Returns_HttpStatusCode_OK()
        {

            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            // Print registration response
            string registerResponseBody = await response.Content.ReadAsStringAsync();

            // Login with the registered user
            string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
            HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

            // Print login response
            string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        }

      [Test, Order(5)]
     public async Task Backend_Test_Post_Method_Register_Teller_Returns_HttpStatusCode_OK()
        {
            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            string responseString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    
     [Test, Order(6)]
      public async Task Backend_Test_Post_Method_Login_Teller_Returns_HttpStatusCode_OK()
        {

            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            // Print registration response
            string registerResponseBody = await response.Content.ReadAsStringAsync();

            // Login with the registered user
            string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
            HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

            // Print login response
            string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        }

     [Test, Order(7)]
      public async Task Backend_Test_Post_Method_Register_Returns_HttpStatusCode_BadRequest_For_Invalid_User_Role()
     {
            string uniqueId = Guid.NewGuid().ToString();

            // Generate a unique userName based on a timestamp
            string uniqueUsername = $"abcd_{uniqueId}";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"InvalidRole\"}}";
            HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            string responseString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    
    [Test, Order(8)]
    public async Task Backend_Test_Post_Account_By_Customer_Returns_HttpStatusCode_201()
{
    string uniqueId = Guid.NewGuid().ToString();

    // Generate a unique userName based on a timestamp
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

    // Print registration response
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    //Console.WriteLine("Registration Response: " + registerResponseBody);
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    // if registerResponseMap.userId == null or data is like UserId, then it should be registerResponseMap.UserId? it can differently be written as registerResponseMap["UserId"]
    int userId = registerResponseMap["UserId"];
    //Console.WriteLine("User ID: " + userId);
    //Console.WriteLine("User ID: " + response);
    // Login with the registered user
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

    // Print login response
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();

    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();

    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);

    string token = responseMap.token;

    Assert.IsNotNull(token);


    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));

    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
}

[Test, Order(9)]
    public async Task Backend_Test_Post_Account_By_Teller_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();

    // Generate a unique userName based on a timestamp
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

    // Print registration response
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    //Console.WriteLine("Registration Response: " + registerResponseBody);
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    // if registerResponseMap.userId == null or data is like UserId, then it should be registerResponseMap.UserId? it can differently be written as registerResponseMap["UserId"]
    int userId = registerResponseMap["UserId"];
    // Login with the registered user
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

    // Print login response
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();

    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();

    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);

    string token = responseMap.token;

    Assert.IsNotNull(token);


    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));

    Assert.AreEqual(HttpStatusCode.Forbidden, Response.StatusCode);
}
// test to check the enpoint that get account by user id
[Test, Order(10)]
public async Task Backend_Test_Get_Account_By_User_Id_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();

    // Generate a unique userName based on a timestamp
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));  
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync($"/api/account/user/{userId}");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that manager can get all accounts
[Test, Order(11)]
public async Task Backend_Test_Get_All_Accounts_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/account");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that customer cant get all accounts
[Test, Order(12)]
public async Task Backend_Test_Get_All_Accounts_By_Customer_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/account");
    Assert.AreEqual(HttpStatusCode.Forbidden, accountResponse.StatusCode);
}

// test to check the enpoint that manager can get all transactions
[Test, Order(13)]
public async Task Backend_Test_Get_All_Transactions_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/transaction");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

[Test, Order(14)]
public async Task Backend_Test_Get_All_Transactions_By_Teller_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/transaction");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that customer can get only his transactions
[Test, Order(15)]
public async Task Backend_Test_Get_All_Transactions_By_Customer_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/transaction");
    Assert.AreEqual(HttpStatusCode.Forbidden, accountResponse.StatusCode);
}

// test to check the enpoint that customer can get only his transactions
[Test, Order(16)]
public async Task Backend_Test_Get_Transactions_By_User_Id_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync($"/api/transaction/user/{userId}");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that customer can post transactions
[Test, Order(17)]
public async Task Backend_Test_Post_Transactions_By_Customer_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account 
    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    HttpResponseMessage accountResponse = await _httpClient.GetAsync($"/api/account/user/{userId}");
    string accountResponseBody = await accountResponse.Content.ReadAsStringAsync();
    dynamic accountResponseMap = JsonConvert.DeserializeObject(accountResponseBody);
    int accountId = accountResponseMap[0]["AccountId"];

    // Approve the account by manager to make transactions
    string uniqueId1 = Guid.NewGuid().ToString();
    string uniqueUsername1 = $"abcd_{uniqueId1}";
    string uniqueEmail1 =  $"abcd{uniqueId}@gmail.com";
    string requestBody1 = $"{{\"Username\": \"{uniqueUsername1}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail1}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response1 = await _httpClient.PostAsync("/api/register", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
    string registerResponseBody1 = await response1.Content.ReadAsStringAsync();
    dynamic registerResponseMap1 = JsonConvert.DeserializeObject(registerResponseBody1);
    // int userId1 = registerResponseMap1["UserId"];
    string loginRequestBody1 = $"{{\"Email\" : \"{uniqueEmail1}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse1 = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody1, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse1.StatusCode);
    string responseBody1 = await loginResponse1.Content.ReadAsStringAsync();
    dynamic responseMap1 = JsonConvert.DeserializeObject(responseBody1);
    string token1 = responseMap1.token;
    Assert.IsNotNull(token1);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token1);
    string approvalStatus = "Active";
    HttpResponseMessage approvalResponse = await _httpClient1.PatchAsync(
        $"/api/ms/account/{accountId}", 
        new StringContent($"\"{approvalStatus}\"", Encoding.UTF8, "application/json")
    );
    Assert.AreEqual(HttpStatusCode.NoContent, approvalResponse.StatusCode);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


    // //Console.WriteLine("Account ID: 123 " + accountId);
    string Json1 = $"{{\"AccountId\":{accountId},\"Amount\":1000,\"TransactionType\":\"Deposit\"}}";
    HttpResponseMessage Response1 = await _httpClient.PostAsync("/api/transaction",
    new StringContent(Json1, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response1.StatusCode);
}

[Test, Order(18)]
public async Task Backend_Test_Get_All_Notifications_Without_Token_Returns_HttpStatusCode_Unauthorized()
{
    // Make the GET request to retrieve all notifications without a token
    HttpResponseMessage notificationResponse = await _httpClient.GetAsync("/api/notification");

    //Console.WriteLine("Notification Response: " + notificationResponse);

    Assert.AreEqual(HttpStatusCode.Unauthorized, notificationResponse.StatusCode);
}

// without token get all accounts unauthorized
[Test, Order(19)]
public async Task Backend_Test_Get_All_Accounts_Without_Token_Returns_HttpStatusCode_Unauthorized()
{
    // Make the GET request to retrieve all accounts without a token
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/account");

    //Console.WriteLine("Account Response: " + accountResponse);

    Assert.AreEqual(HttpStatusCode.Unauthorized, accountResponse.StatusCode);
}

// without token get all transactions unauthorized
[Test, Order(20)]
public async Task Backend_Test_Get_All_Transactions_Without_Token_Returns_HttpStatusCode_Unauthorized()
{
    // Make the GET request to retrieve all transactions without a token
    HttpResponseMessage transactionResponse = await _httpClient.GetAsync("/api/transaction");

    //Console.WriteLine("Transaction Response: " + transactionResponse);

    Assert.AreEqual(HttpStatusCode.Unauthorized, transactionResponse.StatusCode);
}

// test to check the enpoint that manager can get all FDs
[Test, Order(21)]
public async Task Backend_Test_Get_All_FixedDeposits_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync("/api/fixeddeposit");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that post FDs by customer
[Test, Order(22)]
public async Task Backend_Test_Post_FixedDeposits_By_Customer_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =  $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    HttpResponseMessage accountResponse1 = await _httpClient.GetAsync($"/api/account/user/{userId}");
    string accountResponseBody1 = await accountResponse1.Content.ReadAsStringAsync();
    dynamic accountResponseMap1 = JsonConvert.DeserializeObject(accountResponseBody1);
    int accountId1 = accountResponseMap1[0]["AccountId"];

    // Approve the account by manager to make transactions
    string uniqueId1 = Guid.NewGuid().ToString();
    string uniqueUsername1 = $"abcd_{uniqueId1}";
    string uniqueEmail1 =  $"abcd{uniqueId}@gmail.com";
    string requestBody1 = $"{{\"Username\": \"{uniqueUsername1}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail1}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response1 = await _httpClient.PostAsync("/api/register", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
    string registerResponseBody1 = await response1.Content.ReadAsStringAsync();
    dynamic registerResponseMap1 = JsonConvert.DeserializeObject(registerResponseBody1);
    // int userId1 = registerResponseMap1["UserId"];
    string loginRequestBody1 = $"{{\"Email\" : \"{uniqueEmail1}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse1 = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody1, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse1.StatusCode);
    string responseBody1 = await loginResponse1.Content.ReadAsStringAsync();
    dynamic responseMap1 = JsonConvert.DeserializeObject(responseBody1);
    string token1 = responseMap1.token;
    Assert.IsNotNull(token1);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token1);
    string approvalStatus = "Active";
    HttpResponseMessage approvalResponse = await _httpClient1.PatchAsync(
        $"/api/ms/account/{accountId1}", 
        new StringContent($"\"{approvalStatus}\"", Encoding.UTF8, "application/json")
    );
    Assert.AreEqual(HttpStatusCode.NoContent, approvalResponse.StatusCode);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

    string Json2 = $"{{\"UserId\":{userId},\"AccountId\":{accountId1},\"PrincipalAmount\":1000,\"InterestRate\":10,\"TenureMonths\":12,\"MaturityAmount\":1100}}";
    HttpResponseMessage Response2 = await _httpClient.PostAsync("/api/fixeddeposit",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response2.StatusCode);
}

// test to check the enpoint that post FDs by teller forbidden
[Test, Order(23)]
public async Task Backend_Test_Post_FixedDeposits_By_Teller_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =  $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    // string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    // HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    // new StringContent(Json, Encoding.UTF8, "application/json"));
    // Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    // HttpResponseMessage accountResponse1 = await _httpClient.GetAsync($"/api/account/user/{userId}");
    // string accountResponseBody1 = await accountResponse1.Content.ReadAsStringAsync();
    // dynamic accountResponseMap1 = JsonConvert.DeserializeObject(accountResponseBody1);
    // int accountId1 = accountResponseMap1[0]["AccountId"];
    string Json2 = $"{{\"UserId\":{userId},\"AccountId\":1,\"PrincipalAmount\":1000,\"InterestRate\":10,\"TenureMonths\":12,\"MaturityAmount\":1100}}";
    HttpResponseMessage Response2 = await _httpClient.PostAsync("/api/fixeddeposit",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Forbidden, Response2.StatusCode);
}

// test to check the enpoint that post FDs by manager forbidden
[Test, Order(24)]
public async Task Backend_Test_Post_FixedDeposits_By_Manager_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =   $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    // string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    // HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    // new StringContent(Json, Encoding.UTF8, "application/json"));
    // Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    // HttpResponseMessage accountResponse1 = await _httpClient.GetAsync($"/api/account/user/{userId}");
    // string accountResponseBody1 = await accountResponse1.Content.ReadAsStringAsync();
    // dynamic accountResponseMap1 = JsonConvert.DeserializeObject(accountResponseBody1);
    // int accountId1 = accountResponseMap1[0]["AccountId"];
    string Json2 = $"{{\"UserId\":{userId},\"AccountId\":1,\"PrincipalAmount\":1000,\"InterestRate\":10,\"TenureMonths\":12,\"MaturityAmount\":1100}}";
    HttpResponseMessage Response2 = await _httpClient.PostAsync("/api/fixeddeposit",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Forbidden, Response2.StatusCode);
}

// test to check the enpoint that get FDs by user id
[Test, Order(25)]
public async Task Backend_Test_Get_FixedDeposits_By_User_Id_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =   $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync($"/api/fixeddeposit/user/{userId}");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that get RDs by user id
[Test, Order(26)]
public async Task Backend_Test_Get_RecurringDeposits_By_User_Id_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =    $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient.GetAsync($"/api/recurringdeposit/user/{userId}");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the enpoint that post RDs by customer
[Test, Order(27)]
public async Task Backend_Test_Post_RecurringDeposits_By_Customer_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =    $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    HttpResponseMessage Response = await _httpClient.PostAsync("/api/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    HttpResponseMessage accountResponse1 = await _httpClient.GetAsync($"/api/account/user/{userId}");
    string accountResponseBody1 = await accountResponse1.Content.ReadAsStringAsync();
    dynamic accountResponseMap1 = JsonConvert.DeserializeObject(accountResponseBody1);
    int accountId1 = accountResponseMap1[0]["AccountId"];

    // Approve the account by manager to make transactions
    string uniqueId1 = Guid.NewGuid().ToString();
    string uniqueUsername1 = $"abcd_{uniqueId1}";
    string uniqueEmail1 =  $"abcd{uniqueId}@gmail.com";
    string requestBody1 = $"{{\"Username\": \"{uniqueUsername1}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail1}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response1 = await _httpClient.PostAsync("/api/register", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
    string registerResponseBody1 = await response1.Content.ReadAsStringAsync();
    dynamic registerResponseMap1 = JsonConvert.DeserializeObject(registerResponseBody1);
    // int userId1 = registerResponseMap1["UserId"];
    string loginRequestBody1 = $"{{\"Email\" : \"{uniqueEmail1}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse1 = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody1, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse1.StatusCode);
    string responseBody1 = await loginResponse1.Content.ReadAsStringAsync();
    dynamic responseMap1 = JsonConvert.DeserializeObject(responseBody1);
    string token1 = responseMap1.token;
    Assert.IsNotNull(token1);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token1);
    string approvalStatus = "Active";
    HttpResponseMessage approvalResponse = await _httpClient1.PatchAsync(
        $"/api/ms/account/{accountId1}", 
        new StringContent($"\"{approvalStatus}\"", Encoding.UTF8, "application/json")
    );
    Assert.AreEqual(HttpStatusCode.NoContent, approvalResponse.StatusCode);
    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

    string Json2 = $"{{\"UserId\":{userId},\"AccountId\":{accountId1},\"MonthlyDeposit\":1000,\"InterestRate\":10,\"TenureMonths\":12,\"MaturityAmount\":1100}}";
    HttpResponseMessage Response2 = await _httpClient.PostAsync("/api/recurringdeposit",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response2.StatusCode);
}

// test to check the enpoint that post RDs by teller forbidden
[Test, Order(28)]
public async Task Backend_Test_Post_RecurringDeposits_By_Teller_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =     $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    // dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    // int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    string Json2 = $"{{\"UserId\":1,\"AccountId\":1,\"MonthlyDeposit\":1000,\"InterestRate\":10,\"TenureMonths\":12,\"MaturityAmount\":1100}}";
    HttpResponseMessage Response2 = await _httpClient.PostAsync("/api/recurringdeposit",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Forbidden, Response2.StatusCode);
}

// test to check the _httpClient1 that the get all accounts by manager returns ok
[Test, Order(29)]
public async Task Backend_Test_Microservices_Port_8079_Get_All_Accounts_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =  $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient1.GetAsync("/api/ms/account");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the _httpClient1 that the post accounts by customer returns created
[Test, Order(30)]
public async Task Backend_Test_Microservices_Port_8079_Post_Accounts_By_Customer_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =   $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    HttpResponseMessage Response = await _httpClient1.PostAsync("/api/ms/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
}

// test to check the _httpClient2 port 8078 that the get all transactions by manager returns ok
[Test, Order(31)]
public async Task Backend_Test_Microservices_Port_8078_Get_All_Transactions_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =    $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient2.GetAsync("/api/ms/transaction");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the _httpClient2 port 8078 that the post transactions by customer returns created
[Test, Order(32)]
public async Task Backend_Test_Microservices_Port_8078_Post_Transactions_By_Customer_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =   $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    int userId = registerResponseMap["UserId"];
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    _httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    // create one account
    string Json = $"{{\"UserId\":{userId},\"AccountHolderName\":\"Demo\",\"AccountType\":\"Savings\",\"Balance\":1000,\"ProofOfIdentity\":\"demostringUrl\"}}";
    HttpResponseMessage Response = await _httpClient1.PostAsync("/api/ms/account",
    new StringContent(Json, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    // get the account id
    HttpResponseMessage accountResponse1 = await _httpClient1.GetAsync($"/api/ms/account/user/{userId}");
    string accountResponseBody1 = await accountResponse1.Content.ReadAsStringAsync();
    dynamic accountResponseMap1 = JsonConvert.DeserializeObject(accountResponseBody1);
    //Console.WriteLine("Account ID: 123 " + accountResponseMap1);
    int accountId1 = accountResponseMap1[0]["AccountId"];

    // approve the account by login as manager
    string uniqueId1 = Guid.NewGuid().ToString();
    string uniqueUsername1 = $"abcd_{uniqueId1}";
    string uniqueEmail1 =   $"abcd{uniqueId1}@gmail.com";
    string requestBody1 = $"{{\"Username\": \"{uniqueUsername1}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail1}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response1 = await _httpClient.PostAsync("/api/register", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
    
    string loginRequestBody1 = $"{{\"Email\" : \"{uniqueEmail1}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse1 = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody1, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse1.StatusCode);
    string responseBody1 = await loginResponse1.Content.ReadAsStringAsync();
    dynamic responseMap1 = JsonConvert.DeserializeObject(responseBody1);
    string token1 = responseMap1.token;
    Assert.IsNotNull(token1);
    // clear the headers in the _httpClient1
    _httpClient1.DefaultRequestHeaders.Clear();
    _httpClient1.DefaultRequestHeaders.Add("Authorization", "Bearer " + token1);
        string approvalStatus = "Active";
    HttpResponseMessage approvalResponse = await _httpClient1.PatchAsync(
        $"/api/ms/account/{accountId1}", 
        new StringContent($"\"{approvalStatus}\"", Encoding.UTF8, "application/json")
    );
    Assert.AreEqual(HttpStatusCode.NoContent, approvalResponse.StatusCode);
    
    // HttpResponseMessage accountResponse2 = await _httpClient1.GetAsync($"/api/ms/account/user/{userId}");
    // string accountResponseBody2 = await accountResponse2.Content.ReadAsStringAsync();
    
    // dynamic accountResponseMap2 = JsonConvert.DeserializeObject(accountResponseBody2);
    // Assert.AreEqual(approvalStatus, accountResponseMap2[0]["Status"]);
    string Json2 = $"{{\"AccountId\":{accountId1},\"Amount\":1000,\"TransactionType\":\"Deposit\"}}";
    HttpResponseMessage Response2 = await _httpClient2.PostAsync("/api/ms/transaction",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Created, Response2.StatusCode);
}

// test to check the _httpClient2 port 8078 that the post transactions by teller returns forbidden
[Test, Order(33)]
public async Task Backend_Test_Microservices_Port_8078_Post_Transactions_By_Teller_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =    $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Teller\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    string Json2 = $"{{\"AccountId\":1,\"Amount\":1000,\"TransactionType\":\"Deposit\"}}";
    HttpResponseMessage Response2 = await _httpClient2.PostAsync("/api/ms/transaction",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Forbidden, Response2.StatusCode);
}

// test to check the _httpClient2 port 8078 that the post transactions by manager returns forbidden
[Test, Order(34)]
public async Task Backend_Test_Microservices_Port_8078_Post_Transactions_By_Manager_Returns_HttpStatusCode_Forbidden()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail =  $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap = JsonConvert.DeserializeObject(registerResponseBody);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    string Json2 = $"{{\"AccountId\":1,\"Amount\":1000,\"TransactionType\":\"Deposit\"}}";
    HttpResponseMessage Response2 = await _httpClient2.PostAsync("/api/ms/transaction",
    new StringContent(Json2, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.Forbidden, Response2.StatusCode);
}

// test to check the _httpClient1 port 8079 that register user returns created
[Test, Order(35)]
public async Task Backend_Test_Microservices_Port_8079_Register_User_Returns_HttpStatusCode_Created()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient1.PostAsync("/api/ms/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
}

// test to check the _httpClient2 port 8079 that login user returns ok with the token
[Test, Order(36)]
public async Task Backend_Test_Microservices_Port_8079_Login_User_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient1.PostAsync("/api/ms/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient1.PostAsync("/api/ms/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
}

// test to check the _httpClient4 port 8076 that get all FDs by manager returns ok
[Test, Order(37)]
public async Task Backend_Test_Microservices_Port_8076_Get_All_FixedDeposits_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient1.PostAsync("/api/ms/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient1.PostAsync("/api/ms/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient4.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient4.GetAsync("/api/ms/fixeddeposit");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the _httpClient4 port 8076 that get all RDs by manager returns ok
[Test, Order(38)]
public async Task Backend_Test_Microservices_Port_8076_Get_All_RecurringDeposits_By_Manager_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Manager\"}}";
    HttpResponseMessage response = await _httpClient1.PostAsync("/api/ms/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient1.PostAsync("/api/ms/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient4.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient4.GetAsync("/api/ms/recurringdeposit");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}

// test to check the _httpClient3 port 8077 that get all notifications by manager returns Unauthorized without token
[Test, Order(39)]
public async Task Backend_Test_Microservices_Port_8077_Get_All_Notifications_By_Manager_Returns_HttpStatusCode_Unauthorized()
{
    HttpResponseMessage accountResponse = await _httpClient3.GetAsync("/api/ms/notifications");
    Assert.AreEqual(HttpStatusCode.Unauthorized, accountResponse.StatusCode);
}

// test to check the _httpClient3 port 8077 that get notifications by user id for customer returns ok
[Test, Order(40)]
public async Task Backend_Test_Microservices_Port_8077_Get_Notifications_By_User_Id_For_Customer_Returns_HttpStatusCode_OK()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";
    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
    HttpResponseMessage response = await _httpClient1.PostAsync("/api/ms/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    string registerResponseBody1 = await response.Content.ReadAsStringAsync();
    dynamic registerResponseMap1 = JsonConvert.DeserializeObject(registerResponseBody1);
    int userId = registerResponseMap1["UserId"];
    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}";
    HttpResponseMessage loginResponse = await _httpClient1.PostAsync("/api/ms/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);
    string token = responseMap.token;
    Assert.IsNotNull(token);
    _httpClient3.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage accountResponse = await _httpClient3.GetAsync($"/api/ms/notifications/user/{userId}");
    Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);
}




}