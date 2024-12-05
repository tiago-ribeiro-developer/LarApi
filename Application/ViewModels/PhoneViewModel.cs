namespace Application.ViewModels;

public class PhoneViewModel
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string Numero { get; set; }
    public int PersonId { get; set; }

    public class RegisterPhoneViewModel
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public int PersonId { get; set; }
    }
    
    public class UpdatePhoneViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }

    }
}