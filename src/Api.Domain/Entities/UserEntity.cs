namespace Api.Domain.Entities;

public class UserEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTimeOffset Birth { get; set; }
    public required string Floor { get; set; }
    public required string Password { get; set; }
}
