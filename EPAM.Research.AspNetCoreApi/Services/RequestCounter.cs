namespace EPAM.Research.AspNetCoreApi.Services;

public class RequestCounter
{
    public int PostRequests { get; set; }

    public List<string> Posts { get; set; } = new List<string>();
}
