using DelegatesSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesSample
{
    class Program
    {
        private delegate void OnSuccessDelegate(IEnumerable<Artigo> artigos);
        private delegate void OnErrorDelegate(Erro erro);

        static void Main(string[] args)
        {
            OnSuccessDelegate onSucccessHandler = OnSuccess;
            OnErrorDelegate onErrorHandler = OnError;

            ObterArtigos(onSucccessHandler, onErrorHandler);

            Console.ReadKey();
        }

        private static void ObterArtigos(OnSuccessDelegate onSuccess, OnErrorDelegate onError)
        {
            try
            {
                var artigos = new List<Artigo>();
                artigos.Add(new Artigo { Id = 1, Descricao = "Artigo 1" });
                artigos.Add(new Artigo { Id = 2, Descricao = "Artigo 2" });

                onSuccess(artigos);
            }
            catch (Exception ex)
            {
                onError(new Erro($"Ocorreu um erro: { ex.StackTrace }"));
            }
        }

        private static void OnSuccess(IEnumerable<Artigo> artigos)
        {
            artigos.ToList().ForEach(x =>
            {
                Console.WriteLine($"Código do artigo: { x.Id } com a descrição { x.Descricao }");
            });
        }

        private static void OnError(Erro erro)
        {
            Console.WriteLine($"ERRO: { erro.StacktraceError }");
        }
    }
}