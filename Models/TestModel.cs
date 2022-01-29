namespace Nuremberg.Models;
public class TestModel
{
    public Guid Id { get; set; } = Guid.Empty;
    public string TestModelName { get; set; } = null!;
    public string TestModelOtherProp { get; set; } = null!;
}