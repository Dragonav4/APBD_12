namespace APBD_s31722_12.Models.DTO;

public class TripResponseDto
{
    public string pageNumber { get; set; }
    public int pageSize { get; set; }
    public int allPages { get; set; }
    public List<TripDto> trips {get;set;}
}
public class TripDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateFrom { get; set; }
    public string DateTo { get; set; }
    public int MaxPeople { get; set; }
    public List<CountryDto> Countries { get; set; }
    public List<ClientDto> Clients { get; set; }
}

public class CountryDto
{
    public string Name { get; set; }
}

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}