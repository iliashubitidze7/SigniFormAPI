
using Reader.Utility;
using System.Text;


namespace SigniFormAPI.DataAccess.Repository
{
    public class SignifyApiHelper
    {
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

        public HttpRequestMessage GetRequestMessage(string url, string jsonData, string? token)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            if (token != null)
            {
                request.Headers.Add("Authorization", "Bearer " + $"{token}");
            }
            request.Headers.Add("X-language", "en");
            request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            return request;

        }

        public object CreateRecipient(string name, string email)
        {
            return new
            {
                name,
                email,
                role = "SIGNER",
                recipientContactType = "EMAIL",
                fields = new[]
                        {
                    CreateField(1, "RECIPIENT_NAME", 1, 215, 98, 150, 18, true, 8),
                    CreateField(1, "RECIPIENT_EMAIL", 1, 215, 130, 150, 18, true, 8),
                    CreateField(1, "TEXTAREA", 1, 215, 164, 150, 18, true, 8),
                    CreateField(1, "SIGNATURE", 1, 442, 292, 150, 60, true ,8)
                }
            };
        }

        public Field CreateField(int fileNumber, string type, int page, int left, int top, int width, int height, bool required, int fontSize)
        {
            return new Field
            {
                fileNumber = fileNumber,
                type = type,
                page = page,
                left = left,
                top = top,
                width = width,
                height = height,
                required = required,
                placeholder = (string)null,
                fontSize = fontSize
            };
        }
    }
}
