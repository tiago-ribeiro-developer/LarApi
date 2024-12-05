namespace Application.ViewModels;

public class PersonViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public List<string> Telefones { get; set; }

    
    public class RegisterPersonViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
    
    public class UpdatePersonViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}