using System.Reflection;
using System.Security.Cryptography;

namespace PersonsFactory
{
    class Program
    {
        private static readonly string? PersonKey = "Person";
        private static readonly int[] Ages = [32, 45, 52, 28, 41, 30];
        private static readonly string[] Cities = ["Jaipur", "Gurgaon", "New Delhi", "Noida", "Udaipur", "Mumbai", "Pune", "Navi Mumbai", "Bengaluru", "Mysore", "Cochin", "Nagpur", "Thiruvananthpuram", "Chennai", "Hyderabad", "Ranchi", "Patna"];
        private static readonly Dictionary<string, List<string>> Qualities = new() 
        {
            { "Behavior", new List<string> () { "Wise", "MoneyMinded", "Cunning", "Shrewd", "Social", "Zealous", "Humerous", "Verbose" } },
            { "Built", new List<string>() { "Athletic", "Sporty", "Lean", "Bulky", "Healthy", "Average", "Skinny", "Muscular" } },
            { "WorkProfile",new List<string>() { "Productive", "Stubborn", "ResultOriented", "Resilient", "Competitive", "Resilient" } }
        };
        static void Main(string[] args)
        {
            var lines = new List<string>();
            for (int i = 9; i <= 15423; i++)
            {
                lines.Add(
                    $"{PersonKey}{i}," +
                    $"Age{Ages.GetRandomElements(1)}," +
                    $"{Cities.GetRandomElements(1)}," +
                    $"{"Behavior"}~{Qualities["Behavior"].GetRandomElements(1)}|" + 
                    $"{"Built"}~{Qualities["Built"].GetRandomElements(1)}|" +
                    $"{"WorkProfile"}~{Qualities["WorkProfile"].GetRandomElements(1)}");
            }
            var persons_file_path = Path.Combine(Directory.GetParent(Path.Combine(Environment.CurrentDirectory)).Parent.Parent.Parent.FullName, "MyLocalServiceCore", "Persons.csv");
            var sw = new StreamWriter(persons_file_path,true);
            sw.WriteLine("");
            lines.ForEach(sw.WriteLine);
            sw.Close();
        }
    }
}



