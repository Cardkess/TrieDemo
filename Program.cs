namespace TrieDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            
            List<string> result = trie.SearchPrefix("app");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

    }
}
