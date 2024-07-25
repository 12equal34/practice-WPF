using LearnWPFbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LearnWPFbook
{
	public class Product : Notifier
	{
		#region Title
		private string title = "";
		public string Title
		{
			get => title;
			set
			{
				title = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Reference
		private string reference = "";
		public string Reference
		{
			get => reference;
			set
			{
				reference = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Color
		private string color = "";
		public string Color
		{
			get => color;
			set
			{
				color = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Price
		private decimal price;
		public decimal Price
		{
			get => price;
			set
			{
				price = value;
				OnPropertyChanged();
			}
		} 
		#endregion
	}

	public class ProductsFactory
	{
		#region In-memory data
		static IList<Product> products;
		static ProductsFactory()
		{
			products = new List<Product>();
			for (int i = 0; i < 100; ++i) {
				products.Add(generateRandomProduct());
			}
		}
		static Random r = new Random(DateTime.Now.Millisecond);
		static Product generateRandomProduct()
		{
			var titles = new string[] { "Classic city bike", "Vintage city bike", "Basic mountain bike", "Easy mountain bike", "Devil mountain bike" };
			var colors = new string[] { "Red", "Blue", "Green", "Brown", "Gray", "Black" };
			return new Product()
			{
				Title = pickRandom(titles),
				Color = pickRandom(colors),
				Price = Math.Round(300M + (decimal)r.NextDouble() * 1700M, 2),
				Reference = "BK" + r.Next(100000).ToString("d8")
			};
		}
		static T pickRandom<T>(T[] array)
		{
			return array[r.Next(array.Length)];
		}
		#endregion

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
		}

		public IEnumerable<Product> FindProducts(string searchString)
		{
			return products.Where(p => p.Title.Contains(searchString));
		}
	}
}
