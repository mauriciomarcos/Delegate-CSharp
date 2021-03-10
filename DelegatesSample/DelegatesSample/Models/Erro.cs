namespace DelegatesSample.Models
{
    public class Erro
    {
        public Erro(string msgErro)
        {
            StacktraceError = msgErro;
        }

        public string StacktraceError { get; private set; }
    }
}