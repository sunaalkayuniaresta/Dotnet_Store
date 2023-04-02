public class Program
{
	class Product
    {    
		public string Sku { get; set; }
        public string Name { get; set; }
		public int Stock { get; set; }
		public double Price {get; set;}
    }
	
	//primitive data type

    class Toko
	{
    private List<Product> listProduct = new List<Product>();    	
	private List<Product> listCart = new List<Product>();

		public void AddData()
		{
			Console.WriteLine("\nAdd Data Product");

			Console.Write("SKU: ");
			string sku = Console.ReadLine();
			Console.Write("Product Name: ");
			string name = Console.ReadLine();
			Console.Write("Stock: ");			
			int stock = Convert.ToInt32(Console.ReadLine());
			Console.Write("Price: ");			
			double price = Convert.ToDouble(Console.ReadLine());

			if (listProduct.Exists(product => product.Sku == sku))
			{
				Console.WriteLine("Sku already exists");
			}
			else
			{
				listProduct.Add(new Product { Sku = sku, Name = name, Stock = stock  , Price = price         } );
				Console.WriteLine("The products has been added successfully");
			}
		}
		
		public void AddToCart()
		{
			Console.WriteLine("\nAdding Products To Cart");

			Console.Write("SKU Product : ");
			string sku = Console.ReadLine();
			
			//singular sendiri
			//plural kelompok
			
			if (listProduct.Exists(product => product.Sku == sku))
			{
				Console.Write("How much wanna buy? ");
				int quantity = Convert.ToInt32(Console.ReadLine());
				int index = listProduct.FindIndex(produk => produk.Sku == sku);
				listCart.Add(new Product { 
					Name = listProduct[index].Name,
					Sku = listProduct[index].Sku,
					Stock = quantity,
					Price = listProduct[index].Price            
					});
				listProduct[index].Stock -= quantity;
				Console.WriteLine("The products has been added successfully");
			}
			else
			{
				Console.WriteLine("Sorry sku product not found :(");
			}

		}

        public void DeleteCart()
		{
			Console.WriteLine("Delete Product From Cart");
			Console.Write("Sku Product: ");

			string sku = Console.ReadLine();
			if (listProduct.Exists(product => product.Sku == sku))
			{
				int index = listProduct.FindIndex(produk => produk.Sku == sku);
				listCart.RemoveAt(index);
				Console.WriteLine("The products has been deleted successfully");
			}
			else
			{
				Console.WriteLine("Sorry sku product not found :(");
			}
		}
		
		public void Checkout()
		{
			double total = 0;
			Console.WriteLine("\nDaftar Checkout:");
			Console.WriteLine("Sku\tName\tStock\tPrice");

			foreach (var belanjaan in listCart)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}", belanjaan.Sku, belanjaan.Name, belanjaan.Stock, belanjaan.Price);
				total += belanjaan.Stock*belanjaan.Price;
			}
			
			Console.WriteLine("\nYou have to pay : {0}", total);
			Console.WriteLine("Make an Order?");
			Console.WriteLine("1. Yes");
			Console.WriteLine("2. Cancel");
			Console.WriteLine("Answer.....");
			int answer = Convert.ToInt32(Console.ReadLine());
			if (answer == 1)
			{
				listCart.Clear();
				Console.WriteLine("Payment Success");
			}
			else
			{
				Console.WriteLine("Payment Canceled");
			}
			
		}
		
		public void ShowAllProducts()
		{
			Console.WriteLine("SKU\tName\tStock\tPrice");
            //Console.WriteLine("\nSKU\tname\tstock\tprice");

			foreach (var produk in listProduct)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}",produk.Sku, produk.Name, produk.Stock, produk.Price);
                //Console.WriteLine(" | " + produk.Sku + " | " + produk.name + " | " + produk.stock + " | " + produk.price);
			}
			
			//Console.WriteLine("\nDaftar listCart:");

			//foreach (var produk in listCart)
			//{
				//Console.WriteLine("- " + produk.name + "- " + produk.Sku + "- " + produk.stock + "- " + produk.price);
			//}
		}
		
		public void ShowAllCart()
		{
			Console.WriteLine("\nDaftar listCart:");
			Console.WriteLine("Sku\tName\tStock\tPrice");

			foreach (var produk in listCart)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}", produk.Sku, produk.Name, produk.Stock, produk.Price);
			}
		}
		
		public void DeleteProduct()
		{
			Console.WriteLine("Hapus Data Produk");
			Console.Write("Sku Produk: ");

			string sku = Console.ReadLine();
			if (listProduct.Exists(product => product.Sku == sku))
			{
				int index = listProduct.FindIndex(produk => produk.Sku == sku);
            	listProduct.RemoveAt(index);
				Console.WriteLine("The product has been deleted successfully");
			}
			else
			{
				Console.WriteLine("Sorry sku product not found :(");
			}
            
		}

        public void EditProduct(){
            Console.WriteLine("Edit Data Produk");
            Console.Write("Sku Produk: ");
			
            string sku = Console.ReadLine();
			if (listProduct.Exists(product => product.Sku == sku))
			{
				int index = listProduct.FindIndex(produk => produk.Sku == sku);
				Console.Write("name Produk: ");
				string name = Console.ReadLine();
				Console.Write("stock: ");			
				int stock = Convert.ToInt32(Console.ReadLine());
				Console.Write("price: ");			
				double price = Convert.ToDouble(Console.ReadLine());
				listProduct[index].Name = name;
				listProduct[index].Stock = stock;
				listProduct[index].Price = price;
				Console.WriteLine("The product has been edited succesfully");
			}
			else
			{
				Console.WriteLine("Sorry sku product not found :(");
			}
            
        }
	}
	
	public static void Main()
	{
		Toko toko = new Toko();
		int menu = 0;

        while (menu != 9)
        {
            Console.WriteLine("Welcome to the Dotnet Store:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Show All Products");
            Console.WriteLine("4. Delete produk");
            Console.WriteLine("5. Add Product to Cart");
			Console.WriteLine("6. Delete Product From Cart");
			Console.WriteLine("7. Show Cart");
			Console.WriteLine("8. Checkout");
			Console.WriteLine("9. Exit");
            Console.Write("Pilih menu: ");
		menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    toko.AddData();
                    break;
                case 2:
					toko.ShowAllProducts();
					toko.EditProduct();
                    break;
                case 3:
					toko.ShowAllProducts();
                    break;
                case 4:
					toko.ShowAllProducts();
					toko.DeleteProduct();
                    break;
				case 5:
					toko.AddToCart();
                    break;
                case 6:
                    toko.DeleteCart();
                	break;
				case 7:
                    toko.ShowAllCart();
                	break;
				case 8:
                    toko.Checkout();
                	break;
				case 9:
                    Console.WriteLine("Thank you for using our program.");
                	break;
                default:
                    Console.WriteLine("Menu are not available.");
                    break;
            }
        }
	}
}