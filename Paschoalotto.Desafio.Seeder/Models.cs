namespace Paschoalotto.Desafio.Seeder;

public class CoordinatesModel
{
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
}

public class DobModel
{
    public DateTime Date { get; set; }
    public int Age { get; set; }
}

public class IdModel
{
    public string? Name { get; set; }
    public string? Value { get; set; }
}

public class InfoModel
{
    public string? Seed { get; set; }
    public int Results { get; set; }
    public int Page { get; set; }
    public string? Version { get; set; }
}

public class LocationModel
{
    public StreetModel? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Postcode { get; set; }
    public CoordinatesModel? Coordinates { get; set; }
    public TimezoneModel? Timezone { get; set; }
}

public class LoginModel
{
    public string? Uuid { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Salt { get; set; }
    public string? Md5 { get; set; }
    public string? Sha1 { get; set; }
    public string? Sha256 { get; set; }
}

public class NameModel
{
    public string? Title { get; set; }
    public string? First { get; set; }
    public string? Last { get; set; }
}

public class PictureModel
{
    public string? Large { get; set; }
    public string? Medium { get; set; }
    public string? Thumbnail { get; set; }
}

public class RegisteredModel
{
    public DateTime Date { get; set; }
    public int Age { get; set; }
}

public class ResultModel
{
    public string? Gender { get; set; }
    public NameModel? Name { get; set; }
    public LocationModel? Location { get; set; }
    public string? Email { get; set; }
    public LoginModel? Login { get; set; }
    public DobModel? Dob { get; set; }
    public RegisteredModel? Registered { get; set; }
    public string? Phone { get; set; }
    public string? Cell { get; set; }
    public IdModel? Id { get; set; }
    public PictureModel? Picture { get; set; }
    public string? Nat { get; set; }
}

public class UsersModel
{
    public List<ResultModel>? Results { get; set; }
    public InfoModel? Info { get; set; }
}

public class StreetModel
{
    public int Number { get; set; }
    public string? Name { get; set; }
}

public class TimezoneModel
{
    public string? Offset { get; set; }
    public string? Description { get; set; }
}

