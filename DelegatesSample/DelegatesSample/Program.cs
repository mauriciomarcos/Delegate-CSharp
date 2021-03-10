using DelegatesSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesSample
{
    class Program
    {
        private delegate void OnSuccessDelegate<T>(IEnumerable<T> list) where T : class;
        private delegate void OnErrorDelegate(Erro erro);

        static void Main(string[] args)
        {
            OnSuccessDelegate<Artigo> onSucccessHandler = OnSuccess;
            OnSuccessDelegate<LinguagemProgramacao> onSuccessLHandler = OnSuccess;

            OnErrorDelegate onErrorHandler = OnError;

            Obter(onSucccessHandler, onErrorHandler);
            Obter(onSuccessLHandler, onErrorHandler);

            Console.ReadKey();
        }

        private static void Obter<T>(OnSuccessDelegate<T> onSuccess, OnErrorDelegate onError) where T : class
        {
            try
            {
                var artigos = new List<Artigo>();
                artigos.Add(new Artigo { Id = 1, Descricao = "Artigo 1" });
                artigos.Add(new Artigo { Id = 2, Descricao = "Artigo 2" });

                var linguagens = new List<LinguagemProgramacao>();
                linguagens.Add(new LinguagemProgramacao { Nome = ".NET C#" });
                linguagens.Add(new LinguagemProgramacao { Nome = "Python" });
                linguagens.Add(new LinguagemProgramacao { Nome = "JAVA" });

                //throw new Exception("Opsss....deu erro!!");
                
                if (typeof(T) == typeof(Artigo)) onSuccess((IEnumerable<T>)artigos);
                if (typeof(T) == typeof(LinguagemProgramacao)) onSuccess((IEnumerable<T>)linguagens);
            }
            catch (Exception ex)
            {
                onError(new Erro($"Ocorreu um erro: { ex.Message }"));
            }
        }

        private static void OnSuccess(IEnumerable<Artigo> artigos)
        {
            artigos.ToList().ForEach(x =>
            {
                Console.WriteLine($"Código do artigo: { x.Id } com a descrição { x.Descricao }");
            });
        }

        private static void OnSuccess(IEnumerable<LinguagemProgramacao> linguagens)
        {
            linguagens.ToList().ForEach(x =>
            {
                Console.WriteLine($"Nome da linguagem:  { x.Nome }");
            });
        }

        private static void OnError(Erro erro)
        {
            Console.WriteLine($"ERRO: { erro.MensagemErro }");
        }
    }
}