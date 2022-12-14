using System.Collections.Specialized;
using System.Text;
using System.Text.Json;
using System.Web;
using WFB.Services;

NameValueCollection GetQueryString()
{
    return HttpUtility.ParseQueryString(Environment.GetEnvironmentVariable("QUERY_STRING") ?? "");
}

string GetQueryStringParam(string name)
{
    return GetQueryString()[name] ?? "";
}

void WriteResponse(object data)
{
    var sb = new StringBuilder();
    sb.AppendLine("Content-type: application/json");
    sb.AppendLine("Access-Control-Allow-Origin: *");
    sb.AppendLine();
    sb.AppendLine(JsonSerializer.Serialize(data));

    Console.WriteLine(sb.ToString());
}

var secret = "superSecret";
var hash = AwesomeService.HashWithSecret(GetQueryStringParam("number"), secret);

WriteResponse(new { hash });