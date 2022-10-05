namespace ShoppingList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, decimal> menuItems = new Dictionary<string, decimal>();
			menuItems.Add("apple", 0.99m);
			menuItems.Add("berries", 1.99m);
			menuItems.Add("pb cup", 0.50m);
			menuItems.Add("salmon", 7.99m);
			menuItems.Add("cheese", 11.99m);
			menuItems.Add("lentils", 2.49m);
			menuItems.Add("oreos", 3.19m);
			menuItems.Add("guava", 0.99m);
			List<string> cart = new List<string>();

			Console.WriteLine("Welcome To Randy's Market");
			bool areShopping = true;
			while (areShopping)
			{
				PrintMenu(menuItems);
				Console.WriteLine("what would you like to add to your cart?");
				string adding = Console.ReadLine();

				if (menuItems.ContainsKey(adding))
				{
					cart.Add(adding);
					Console.WriteLine($"Adding 1 {adding} to your cart for ${menuItems[adding]}");
					areShopping = AskToContinue();
				}
				else
				{
					areShopping = true;
					Console.WriteLine("\nwe dont have " + adding + " unfortunately!\n");
				}
			}
			
			Console.WriteLine("thanks for shopping, here is your receipt");
			Console.WriteLine("the total will be $"+GetSum(cart, menuItems));
		}
		public static decimal GetSum(List<string> cart, Dictionary<string, decimal> menuItems)
		{
			decimal total = 0;
			foreach (string item in cart)
			{
				if (menuItems.ContainsKey(item))
				{
					Console.WriteLine(item + "\t\t $" + menuItems[item]);
					decimal cost = menuItems[item];
					total += cost;
				}
			}
			return total;
		}
		public static void PrintMenu(Dictionary<string, decimal> menuItems)
		{
			Console.WriteLine("Item \t\t\t Price");
			Console.WriteLine("==============================");
			foreach (KeyValuePair<string, decimal> item in menuItems)
			{
				Console.WriteLine(item.Key + "\t\t\t $" + item.Value);
			}
		}
		public static bool AskToContinue()
		{
			Console.WriteLine("want to add anything else? (y/n)");
			string input = Console.ReadLine().ToLower();
			if (input == "y" || input == "yes")
			{
				return true;

			}
			else if (input == "n" || input == "no")
			{
				return false;
			}
			else
			{
				Console.WriteLine("try again (y/n)");
				return AskToContinue();
			}
		}
	}
}