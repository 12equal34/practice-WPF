using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace LearnWPFbook
{
	public class ProductsManagementViewModel : Notifier
	{

		#region Input and output properties
		private string searchInput;
		public string SearchInput
		{
			get => searchInput;
			set
			{
				searchInput = value;
				OnPropertyChanged();
				OnSearchInputChanged();
			}
		}

		private IEnumerable<Product> foundProducts;
		public IEnumerable<Product> FoundProducts
		{
			get => foundProducts;
			set
			{
				foundProducts = value;
				OnPropertyChanged();
			}
		}

		private Product selectedProduct;
		public Product SelectedProduct
		{
			get => selectedProduct;
			set
			{
				selectedProduct = value;
				OnPropertyChanged();
			}
		} 
		#endregion

		ProductsFactory factory = new ProductsFactory();
		
		public ProductsManagementViewModel()
		{
			FoundProducts = Enumerable.Empty<Product>();
		}

		private void OnSearchInputChanged()
		{
			SelectedProduct = null;
			FoundProducts = factory.FindProducts(SearchInput);
		}
	}
}
