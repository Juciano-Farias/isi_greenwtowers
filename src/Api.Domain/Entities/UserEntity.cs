namespace Api.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTimeOffset Birth { get; set; }
    public string Floor { get; set; }
}
