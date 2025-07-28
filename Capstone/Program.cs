using Capstone;
using Capstone.Menu;
char[] splitChars = ['[', ']', ':', '%', ' '];
string path = $@"{Environment.CurrentDirectory}\Resources";
string[] resourcesFiles = Directory.GetFiles(path, "*.txt");
string[] filelines = File.ReadAllLines(resourcesFiles[0]);

foreach (string line in filelines)
{
    string[] words = line.Split(splitChars);
    if (words[1] == "Concession")
    { }
    }
CinemaMenu cinemaMenu = new CinemaMenu();