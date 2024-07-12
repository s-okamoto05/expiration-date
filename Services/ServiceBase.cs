using WebApplication.Models;

namespace WebApplication.Services;

public abstract class ServiceBase
{
    public ValueDto ValueDto { get; } = new();
}
