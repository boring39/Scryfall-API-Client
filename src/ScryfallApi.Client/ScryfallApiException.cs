using System.Net;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client;

public class ScryfallApiException(string message) : Exception(message)
{
    public required HttpStatusCode ResponseStatusCode { get; set; }
    public required Uri RequestUri { get; set; }
    public required HttpMethod RequestMethod { get; set; }
    public required ErrorObject ScryfallError { get; set; }
}
