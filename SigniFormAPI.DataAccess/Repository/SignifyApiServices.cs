using SigniFormAPI.DataAccess.Repository;
using SigniFormAPI.DataAccess.Repository.IRepository;
using SigniFormAPI.Utility;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Reader.DataAccess.Repository
{
    public class SignifyApiServices : SignifyApiHelper
    {
        public SD SD = new SD();

        private readonly IUnitOfWork _unitOfWork;

        public SignifyApiServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Authentication()
        {
            string Token = null;
            var dataKey = new
            {
                clientId = SD.clientId,
                clientSecret = SD.clientSecret
            };
            var jsonData = JsonSerializer.Serialize(dataKey);

            string data = GetRequestData(GetRequestMessage(SD.AuthenticateURL, jsonData, Token));

            using (JsonDocument doc = JsonDocument.Parse(data))
            {
                Token = doc.RootElement.GetProperty("accessToken").GetString();
                return Token;
            }

        }

        public int CreateDocument(string token, string filePath)
        {
            int documentId;

            byte[] fileBytes = File.ReadAllBytes(filePath);
            string fileBase64 = Convert.ToBase64String(fileBytes);

            var Values = new
            {
                documentName = "Reconciliation Act template",
                extension = "docx",
                fileBase64 = $"{fileBase64}"
            };


            var jsonData = JsonSerializer.Serialize(Values);
            string data = GetRequestData(GetRequestMessage(SD.CreateDocumentURL, jsonData, token));

            var parseData = JsonSerializer.Deserialize<JsonElement>(data);
            return documentId = parseData.GetProperty("documentId").GetInt32();

        }

        public void SetDocumentDetails(string token, int id, string email, string name)
        {
            var values = new
            {
                documentId = id,
                workflowType = "SERIAL",
                recipients = new[]
                    {
                        CreateRecipient(name, email)
                    }
            };

            var jsonData = JsonSerializer.Serialize(values);
            string data = GetRequestData(GetRequestMessage(SD.SetDocumentURL, jsonData, token));
        }

        public void SendDocument(string token, int id)
        {
            var Values = new
            {
                documentId = id
            };
            var jsonData = JsonSerializer.Serialize(Values);
            string data = GetRequestData(GetRequestMessage(SD.SendDocumentURL, jsonData, token));
        }

        public string GetDocumentDetails(string token, int id)
        {
            var jsonData = JsonSerializer.Serialize(id);
            string data = GetRequestData(GetRequestMessage(SD.GetDocumentURL, jsonData, token));

            return data;

        }

        public void UpdateDocumentDetails()
        {



        }

        public string GetRequestData(HttpRequestMessage httpRequestMessage)
        {
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;

            return data;
        }

    }
}
