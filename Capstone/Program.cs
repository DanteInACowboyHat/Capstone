using Capstone.Objects;

char[] splitChars = ['[', ']', ':', '%'];
string path = $@"{Environment.CurrentDirectory}\Resources";
string[] resourcesFiles = Directory.GetFiles(path, "*.txt");
string[] filelines = File.ReadAllLines(resourcesFiles[0]);
string cinemaName = "";
List<Concession> concessions = new List<Concession>();
List<Screen> screens = new List<Screen>();
List<Staff> staff = new List<Staff>();
List<Ticket> tickets = new List<Ticket>();
List<Films> films = new List<Films>();
foreach (string file in filelines)
{
    foreach (string line in filelines)
    {
        string[] words = line.Split(splitChars);
        if (words[1] == "Name")
        {
            cinemaName = words[2];
        }
        if (words[1] == "Concession")
        {
            concessions.Add(new Concession(words[2], int.Parse(words[4])));
        }
        if (words[1] == "Screen")
        {
            screens.Add(new Screen(words[2], int.Parse(words[6]), int.Parse(words[4])));
        }
        if (words[1] == "Ticket")
        {
            tickets.Add(new Ticket(words[2], int.Parse(words[3])));
        }
        if (words[1] == "Movie")
        {
            films.Add(new Films(words[2], words[8], int.Parse(words[4])));
        }
        if (words[1] == "Staff")
        {
            Boolean noChange = false;
            while (noChange == false)
            {
                noChange = true;
                foreach (Staff employee in staff)
                {
                    if (int.Parse(words[2]) == employee.getid())
                    {
                        int temp = int.Parse(words[2]) + 1;
                        words[2] = temp.ToString();
                        Console.WriteLine(words[2]);
                        noChange = false;
                    }
                }
            }
            staff.Add(new Staff(int.Parse(words[2]), words[6], words[8], words[4]));
        }
    }
}
foreach (Concession concession in concessions)
{
    Console.WriteLine(concession.ToString());
}
foreach (Screen screen in screens)
{
    Console.WriteLine(screen.ToString());
}
foreach (Staff employee in staff)
{
    Console.WriteLine(employee.ToString());
}
foreach (Films movies in films)
{
    Console.WriteLine(movies.ToString());
}
//Sale sales = new Sale();
//addConcession();

//void addConcession() {
//    Console.WriteLine("Select a concession below");
//int count = 0;
//foreach (Concession concession in concessions)
//{
//        count++;
//        Console.WriteLine(count + " " + concession.ToString());
//    }
//int conchoice = int.Parse(Console.ReadLine())-1;
//    Console.WriteLine("How many would you like");
//int aOfChoice = int.Parse(Console.ReadLine());
//for (int i = 0; i < aOfChoice; i++) {
//        sales.AddSaleItem(concessions[conchoice]);
//        Console.WriteLine(sales.ToString());
//    } }