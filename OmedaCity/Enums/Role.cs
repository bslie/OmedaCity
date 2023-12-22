namespace OmedaCity.Enums;

public enum Role
{
    Offlane,
    Jungle,
    Midlane,
    Carry,
    Support
}

public static class RoleExtensions
{
    public static string ToStringValue(this Role role)
    {
        return role switch
        {
            Role.Offlane => "offlane",
            Role.Jungle => "jungle",
            Role.Midlane => "midlane",
            Role.Carry => "carry",
            Role.Support => "support",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}