namespace DelegatesSample.Models
{
    public class Erro
    {
        public Erro(string msgErro)
        {
            MensagemErro = msgErro;
        }

        public string MensagemErro { get; private set; }
    }
}