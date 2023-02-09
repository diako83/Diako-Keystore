using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diako_keystore.Model
{
  public class Product
  {
    public string Name { get; set; } = "";
    public long EAN { get; set; }
    public double Price { get; set; }
  }
}