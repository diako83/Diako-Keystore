using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diako_keystore.Model;

namespace Diako_keystore
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine(CalculateDiscount(shoppingCart, campaignEANs, 30));

      Console.ReadLine();


    }

    static List<long> campaignEANs = new List<long>()
            {
            5000112637922,
            5000112637939,
            7310865004703,
            7340005404261,
            7310532109090,
            7611612222105
            };



    static List<Product> shoppingCart = new List<Product>()
            {
           new Product()
           {
               Name="Coca-cola",
               EAN=5000112637922,
               Price = 20
           },
             new Product()
           {
               Name="Fanta",
               EAN=5000112637939,
               Price = 20
           },
               new Product()
           {
               Name="Sprite",
               EAN=7310865004703,
               Price = 20
           },
               new Product()
           {
               Name="Pepsi",
               EAN=7340005404261,
               Price = 20
           },
               new Product()
           {
               Name="seven-upp",
               EAN=7310532109090,
               Price = 20
           },
                 new Product()
           {
               Name="Champo",
               EAN=5000112555922,
               Price = 18
           },
                   new Product()
           {
               Name="Glass",
               EAN=5000112666622,
               Price = 25
           },
            new Product()
           {
               Name="Mjöl",
               EAN=5000112337922,
               Price = 10
           },

     };



    static double CalculateDiscount(List<Product> shoppingCart, List<long> campaignEANs, int campaingPrice)
    {

      //Filterea och skapa en lista av alla producter som har EAN som är med i kampanj
      List<Product> itemLists = (from product in shoppingCart
                                 join ean in campaignEANs on product.EAN equals ean
                                 select product)
                                     .ToList();

      //Se ifall antalet producter som är giltiga för kampanj är ett jämt eller ojämt tal
      if (itemLists.Count % 2 == 0)
      {
        // om de är ett jämt tal. dividerar med 2 -> returnera reultatat gånger kampanjpriset
        //plus resterande varor som ej med i Kampanjen


        int nrOfDicountProducts = (itemLists.Count / 2);
        return (nrOfDicountProducts * campaingPrice) + calculatSumOfNonCampaignPrice(shoppingCart, campaignEANs);

      }
      else
      {


        int nrOfDicountProducts = (itemLists.Count / 2);
        double discountPrice = nrOfDicountProducts * campaingPrice;

        //plocka ut sista producten som gav en udda siffra och ej har kampanjpris
        //i och med List börjar från index 0 måste itemLists.Count minskas med 1
        Product nonDicountProduct = itemLists[itemLists.Count - 1];

        // sammansätt rabbaterade priset pluss priset fron producten som blev udda ut
        // och var ej giltig för kampanjpris plus resterande varor som ej med i Kampanjen


        return (discountPrice + nonDicountProduct.Price) + calculatSumOfNonCampaignPrice(shoppingCart, campaignEANs);

      }

    }


    static double calculatSumOfNonCampaignPrice(List<Product> shoppingCart, List<long> campaignEANs)
    {
      // filterar bort alla producter som har EAN tillhörande kampanjpris
      List<Product> itemList = (from product in shoppingCart
                                where !campaignEANs.Contains(product.EAN)
                                select product)
                                    .ToList();

      // Ett alternativt vis att filterar bort producter som ej tillhör kampanj
      //List<Product> itemLists = shoppingCart
      //    .Where(p => !campaignEANs.Any(x => x == p.EAN))
      //    .ToList();


      // returnera summan av alla varor som inte är med i kampanj
      return itemList.Sum(prod => prod.Price);

    }

  }
}