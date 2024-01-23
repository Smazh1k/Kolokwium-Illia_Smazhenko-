namespace Illia_Smazhenko
{
    public class Program
    {
        static void Main(string[] args)
        {

            Objects<int> intObjects = new Objects<int>();

            // Dodawanie elementów do listy i obsługa zdarzenia
            intObjects.ItemAdded += IntStorage_ItemAdded;
            intObjects.Add(1);
            intObjects.Add(3);
            intObjects.Add(6);
            intObjects.Add(20);
            intObjects.Add(612);
            Objects<string> strObjects = new Objects<string>();
            strObjects.ItemAdded += StrStorage_ItemAdded;
            strObjects.Add("Jacek");
            strObjects.Add("Marek");
            strObjects.Add("Adam");
            strObjects.Add("Misha");
            Console.WriteLine("Items in the list:");
            foreach (var item in intObjects.Items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sorted items in the list (descending):");
            foreach (var item in intObjects.GetSortedItems())
            {
                Console.WriteLine(item);

            }

            Console.WriteLine("Filtered items in the list (greater than 4):");
            var filteredItems = intObjects.GetFilteredItems(x => x > 4);
            foreach (var item in filteredItems)
            {
                Console.WriteLine(item);
            }


            intObjects.Delete(3);

            Console.WriteLine("Updated items in the list:");
            foreach (var item in intObjects.Items)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("Items in the list:");
            foreach (var item in strObjects.Items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sorted items in the list (descending):");
            foreach (var item in strObjects.GetSortedItems())
            {
                Console.WriteLine(item);

            }
            strObjects.Delete("Jacek");

            Console.WriteLine("Updated items in the list:");
            foreach (var item in intObjects.Items)
            {
                Console.WriteLine(item);
            }
            List<Pair<int, string>> pairs = new List<Pair<int, string>>
        {
            new Pair<int, string>(5, "five"),
            new Pair<int, string>(3, "three"),
            new Pair<int, string>(5, "ten")
        };

            Console.WriteLine("Pairs before sorting:");
            PrintPairs(pairs);

            Pair<int, string>.SortPairs(pairs);

            Console.WriteLine("\nPairs after sorting:");
            PrintPairs(pairs);
        }

        static void PrintPairs(List<Pair<int, string>> pairs)
        {
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.First}, {pair.Second}");
            }
        }

        private static void IntStorage_ItemAdded(object sender, ItemAddedEventArgs<int> e)
        {
            Console.WriteLine($"Item added: {e.AddedItem}");
        }
        private static void StrStorage_ItemAdded(object sender, ItemAddedEventArgs<string> e)
        {
            Console.WriteLine($"Item added: {e.AddedItem}");
        }
    }
}
