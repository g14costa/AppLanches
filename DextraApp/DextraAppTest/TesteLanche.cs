using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DextraApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace DextraAppTest
{
    [TestClass]
    public class TesteLanche
    {
        private readonly Ingrediente Alface;
        private readonly Ingrediente Bacon;
        private readonly Ingrediente Hamburguer;
        private readonly Ingrediente Ovo;
        private readonly Ingrediente Queijo;
        private readonly Lanche XBacon;
        private readonly Lanche XEgg;
        private readonly Lanche XBurger;
        private readonly Lanche XEggBacon;

        public TesteLanche()
        {
            //Inicialização dos Ingredientes e Lanches

            Alface = new Ingrediente("Alface");
            Bacon = new Ingrediente("Bacon");
            Hamburguer = new Ingrediente("Hamburguer");
            Ovo = new Ingrediente("Ovo");
            Queijo = new Ingrediente("Queijo");
            XBacon = new Lanche("X-Bacon");
            XEgg = new Lanche("X-Egg");
            XBurger = new Lanche("X-Burger");
            XEggBacon = new Lanche("X-Egg Bacon");
        }

        private decimal CalcularValorLanche(List<Ingrediente> ingredientes)
        {
            //Calcula o valor dos lanches que se encaixam ou não nas promoções
            decimal valorTotalLanche = ingredientes.Sum(ing => ing.Valor);

            //Verifica se o lanche se encaixa na promoção de Muita Carne e calcula seu valor
            if (ingredientes.FindAll(ing => ing.Nome == "Hamburguer").Count >= 3)
            {
                //Calcula a quantidade de desconto que o lanche possui, dividindo a quantidade de hamburguer por 3 e arredondando seu resultado
                //O resultado será a quantidade de vezes que será retirado o valor de um hamburguer do valor total do lanche
                decimal quantidadeDesconto = Math.Truncate((decimal)ingredientes.FindAll(ing => ing.Nome == "Hamburguer").Count / 3);
                valorTotalLanche -= quantidadeDesconto * Hamburguer.Valor;
            }

            //Verifica se o lanche se encaixa na promoção de Muito Queijo e calcula seu valor
            if (ingredientes.FindAll(ing => ing.Nome == "Queijo").Count >= 3)
            {
                //Calcula a quantidade de desconto que o lanche possui, dividindo a quantidade de Queijo por 3 e arredondando seu resultado
                //O resultado será a quantidade de vezes que será retirado o valor de um queijo do valor total do lanche
                decimal quantidadeDesconto = Math.Truncate((decimal)ingredientes.FindAll(ing => ing.Nome == "Queijo").Count / 3);
                valorTotalLanche -= quantidadeDesconto * Queijo.Valor;
            }

            //Verifica se o lanche se encaixa na promoção de Lanche Light e calcula seu valor
            if (ingredientes.Any(ing => ing.Nome == "Alface") && !ingredientes.Any(ing => ing.Nome == "Bacon"))
            {
                //Calcula a porcentagem de desconto no valor total do lanche
                decimal desconto = (valorTotalLanche / 100) * 10;

                valorTotalLanche -= desconto;
            }

            return valorTotalLanche;
        }

        /// <summary>
        /// Verifica o valor do lanche X-Bacon
        /// </summary>
        [TestMethod]
        public void VerificarValorXBacon()
        {
            XBacon.Valor = CalcularValorLanche(XBacon.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(XBacon.Ingredientes), XBacon.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche X-Burguer
        /// </summary>
        [TestMethod]
        public void VerificarValorXBurguer()
        {
            XBurger.Valor = CalcularValorLanche(XBurger.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(XBurger.Ingredientes), XBurger.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche X-Egg
        /// </summary>
        [TestMethod]
        public void VerificarValorXEgg()
        {
            XEgg.Valor = CalcularValorLanche(XEgg.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(XEgg.Ingredientes), XEgg.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche X-Egg Bacon
        /// </summary>
        [TestMethod]
        public void VerificarValorXEggBacon()
        {
            XEggBacon.Valor = CalcularValorLanche(XEggBacon.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(XEggBacon.Ingredientes), XEggBacon.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche que se encaixa na promoção de Lanche Light
        /// </summary>
        [TestMethod]
        public void VerificarValorLancheComDescontoLight()
        {
            Lanche lancheLight = new Lanche("");
            lancheLight.Ingredientes.Add(Alface);
            lancheLight.Ingredientes.Add(Alface);
            lancheLight.Ingredientes.Add(Hamburguer);
            lancheLight.Ingredientes.Add(Queijo);
            lancheLight.Valor = CalcularValorLanche(lancheLight.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(lancheLight.Ingredientes), lancheLight.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche que se encaixa na promoção de Muita Carne
        /// </summary>
        [TestMethod]
        public void VerificarValorLancheMuitaCarne()
        {
            Lanche lancheMuitaCarne = new Lanche("");
            lancheMuitaCarne.Ingredientes.Add(Hamburguer);
            lancheMuitaCarne.Ingredientes.Add(Hamburguer);
            lancheMuitaCarne.Ingredientes.Add(Hamburguer);
            lancheMuitaCarne.Ingredientes.Add(Alface);
            lancheMuitaCarne.Ingredientes.Add(Queijo);
            lancheMuitaCarne.Ingredientes.Add(Bacon);
            lancheMuitaCarne.Valor = CalcularValorLanche(lancheMuitaCarne.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(lancheMuitaCarne.Ingredientes), lancheMuitaCarne.Valor);
        }

        /// <summary>
        /// Verifica o valor do lanche que se encaixa na promoção de Muito Queijo
        /// </summary>
        [TestMethod]
        public void VerificarValorLancheMuitoQueijo()
        {
            Lanche lancheMuitoQueijo = new Lanche("");
            lancheMuitoQueijo.Ingredientes.Add(Hamburguer);
            lancheMuitoQueijo.Ingredientes.Add(Queijo);
            lancheMuitoQueijo.Ingredientes.Add(Queijo);
            lancheMuitoQueijo.Ingredientes.Add(Alface);
            lancheMuitoQueijo.Ingredientes.Add(Queijo);
            lancheMuitoQueijo.Ingredientes.Add(Queijo);
            lancheMuitoQueijo.Valor = CalcularValorLanche(lancheMuitoQueijo.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(lancheMuitoQueijo.Ingredientes), lancheMuitoQueijo.Valor);
        }

        /// <summary>
        /// Verifica o valor de um lanche personalizado 
        /// </summary>
        [TestMethod]
        public void VerificarValorLanchePersonalizado()
        {
            Lanche lanchePersonalizado = new Lanche("");
            lanchePersonalizado.Ingredientes.Add(Hamburguer);
            lanchePersonalizado.Ingredientes.Add(Queijo);
            lanchePersonalizado.Ingredientes.Add(Alface);
            lanchePersonalizado.Ingredientes.Add(Bacon);
            lanchePersonalizado.Ingredientes.Add(Ovo);
            lanchePersonalizado.Ingredientes.Add(Queijo);
            lanchePersonalizado.Valor = CalcularValorLanche(lanchePersonalizado.Ingredientes);

            Assert.AreEqual(CalcularValorLanche(lanchePersonalizado.Ingredientes), lanchePersonalizado.Valor);
        }
    }
}
