using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diako_keystore.Model;

namespace Diako_keystore.Model
{
  public class Receipt
  {
    public DateTime date { get; set; } = new DateTime();
    public CampaignReceipt? CampaignReceipt { get; set; }
    public NormalPriceReceipt? NormalPriceReceipt { get; set; }
    public double TotalPrice { get; set; }
  }

  public class CampaignReceipt
  {

    public List<Product> shoppingCart { get; set; } = new List<Product>();
    public double Price { get; set; }
  }

  public class NormalPriceReceipt
  {
    public List<Product> shoppingCart { get; set; } = new List<Product>();
    public double Price { get; set; }
  }
}