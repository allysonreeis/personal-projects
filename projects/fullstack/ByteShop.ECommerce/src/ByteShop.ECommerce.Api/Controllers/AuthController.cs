using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace ByteShop.ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Callback([FromQuery] string code)
    {
        var token = await ExchangeAuthorizationCodeForToken(code);

        return Ok(token);
    }

    private async Task<string> ExchangeAuthorizationCodeForToken(string code)
    {
        var tokenEndpoint = "http://localhost:8080/realms/ByteShop-Realm/protocol/openid-connect/token";
        var clientId = "confidential-ecommerce-client";
        var clientSecret = "IbJB1mocACc2MYgPcj4VNDMjbpFJ0SFe";
        var redirectUri = "";

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
        var parameters = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", redirectUri },
                { "client_id", clientId },
                { "client_secret", clientSecret }
            };

        request.Content = new FormUrlEncodedContent(parameters);

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var jsonToken = JsonSerializer.Deserialize<JsonElement>(content);

        return content;
    }
}
