namespace MiniEfApi.Dtos
{
    public class CustomerReponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<AddressReponseDto> Adresses { get; set; }
    }
     public class AddressReponseDto
    {
        public int Id { get; set; }
        public string Road { get; set; }
    }
}
