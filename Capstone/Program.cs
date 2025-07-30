using Capstone.Objects;

char[] splitChars = ['[', ']', ':', '%'];//characters used to split apart lines in files loaded in
string path = $@"{Environment.CurrentDirectory}\Resources";//string to go to the location where the files are stored on the current device
string[] resourcesFiles = Directory.GetFiles(path, "*.txt");//putting all text based files in the path gotten in the previous line into an array 
string cinemaName = "";//making a string to store the cinema name
List<Concession> concessions = new List<Concession>();//creating a list for the different concessions before the files are loaded in
List<Screen> screens = new List<Screen>();//creating a list for the different screens before the files are loaded in
List<Staff> staff = new List<Staff>();//creating a list for the different staff before the files are loaded in
List<Ticket> tickets = new List<Ticket>();//creating a list for the different tickets before the files are loaded in
List<Films> films = new List<Films>();//creating a list for the different films before the files are loaded in
for (int j = 0, jmax = resourcesFiles.Length; j < jmax; j++)//for loop to go through all the text files found and loaded in
{
    string[] filelines = File.ReadAllLines(resourcesFiles[j]);//creates an array of every line in the current file
    foreach (string line in filelines)//a loop that will go through all the lines in the current file
    {
        string[] words = line.Split(splitChars);//splits the current line into different words using the previously listed characters and puts the words into an array
        if (words[1] == "Name")
        {
            cinemaName = words[2];//if the first word is "Name" it will save the world after it in the previous variable for the cinema name
        }
        if (words[1] == "Concession")
        {
            concessions.Add(new Concession(words[2], int.Parse(words[4])));//if the first word is "Concession" then it will create a new instance of a concession in the concessions list
        }
        if (words[1] == "Screen")
        {
            screens.Add(new Screen(words[2], int.Parse(words[6]), int.Parse(words[4])));//if first word is "Screen" it will create a new instance of a screen in the screens list
        }
        if (words[1] == "Ticket")
        {
            tickets.Add(new Ticket(words[2], int.Parse(words[3])));//if first word si "Ticket" it creates a new instance of a Ticket in the tickets list
        }
        if (words[1] == "Movie")
        {
            films.Add(new Films(words[2], words[8].ToString(), int.Parse(words[4])));//if the first word is "Movie" it creates a new instance of Films in the films list
        }
        //if (words[1] == "Screening")
        //{
        //    Boolean screenAndSeatPossible = false;//if the first word is "Screening", first a boolean for if the screening is possible is made
        //    foreach (Screen screen in screens)//a loop to go through the different instances in screens
        //    {
        //        if (words[8] == screen.getName())//checks the 8th word(which should be the Screen name) is the same as a name for an instance of a screen
        //        {
        //            if (int.Parse(words[10]) <= screen.getSSeat() && int.Parse(words[12]) <= screen.getPSeat())//if it is then it will check that the amount of seats the screening says it has left is less than the standard and premium seats respectively
        //            {
        //                screenAndSeatPossible = true;//if correct it will change the boolean to true
        //            }
        //        }
        //    }
        //if (screenAndSeatPossible == true)//checks if the boolean is true
        //{
        //    screening.Add(new Screening(words[2], int.Parse(words[4]), int.Parse(words[6]), words[8], int.Parse(words[10]), int.Parse(words[12])));//if true it creates a new instance of a Screening in the screenings list
        // }
    //}
        if (words[1] == "Staff")
        {
            Boolean noChange = false;//if the first word is staff a boolean is created representing if a change has happened
            while (noChange == false)//creates a loop that will only end once no change has taken place meaning the staff ID is unique
            {
                noChange = true;//sets the boolean to true
                foreach (Staff employee in staff)//creates a loop that goes through each staff member
                {
                    if (int.Parse(words[2]) == employee.getid())//checks if the id is the same as the current employees id
                    {
                        int temp = int.Parse(words[2]) + 1;//if it is it increases the possible new employee id by 1 by converting the string to an interger and stores it in a temp value
                        words[2] = temp.ToString();//the temp then gets changed back into a string
                        noChange = false;//the boolean then gets change to false causing the loop again until the id is unique
                    }
                }
            }
            staff.Add(new Staff(int.Parse(words[2]), words[6], words[8], words[4]));//if the boolean stays true for a loop it will create a new insatnce of Staff in the staff list
        }
    }
}
void addTicket(Sale sales, Screening screening)
{
    Console.WriteLine("Select a ticket type below");
    int count = 0;
    //screening.sSeats = screening.sSeats - 2;
    //Console.WriteLine(screening.ToString());
    foreach (Ticket tick in tickets)
    {
        count++;
        Console.WriteLine(count + " " + tick.ToString());
    }
    int Tchoice = int.Parse(Console.ReadLine()) - 1;

    int aOfChoice = 0;
    while (aOfChoice <= 0)
    {
        Console.WriteLine(screening.ToString);
        Console.WriteLine("How many would the customer like, enter a number above 0");
        aOfChoice = int.Parse(Console.ReadLine());
    }
    if (Tchoice == 0)
    {
        if (aOfChoice > screening.sSeats)
        {
            return;
        }
        screening.sSeats = screening.sSeats-aOfChoice;
    }
    if (Tchoice == 1)
    {
        if (aOfChoice > screening.pSeats)
        {
            return;
        }
        screening.pSeats = screening.pSeats - aOfChoice;
    }
    for (int i = 0; i < aOfChoice; i++)
        {
            sales.AddSaleItem(tickets[Tchoice]);
        }
        Console.WriteLine(sales.ToString());
}
void addConcession(Sale sales)
{
    Console.WriteLine("Select a concession below");
    int count = 0;
    foreach (Concession concession in concessions)
    {
        count++;
        Console.WriteLine(count + " " + concession.ToString());
    }
    int conchoice = int.Parse(Console.ReadLine()) - 1;
    Console.WriteLine("How many would you like");
    int aOfChoice = int.Parse(Console.ReadLine());
    for (int i = 0; i < aOfChoice; i++)
    {
        sales.AddSaleItem(concessions[conchoice]);
        Console.WriteLine(sales.ToString());
    }
}

Console.WriteLine("Which staff member is using the program");
foreach (Staff employee in staff)
{
    Console.WriteLine(employee.ToString());
}
int sIDChoice = 0;
Boolean ValidID=false;
int staffPick = 0;
while (ValidID == false)
{
    Console.WriteLine("Enter a Valid ID number");
    sIDChoice = int.Parse(Console.ReadLine());
    int count = 0;
    foreach (Staff employee in staff)
    {
        if (sIDChoice == employee.getid())
        {
            ValidID = true;
            Console.WriteLine("Correct");
            staffPick=count;
        }
        count++;
    }
}
if (staff[staffPick].getlevel() == "Manager")
{
    //Menu including option to change screening details
}
else
{
    //menu for general
    string screeningPath = $@"{Environment.CurrentDirectory}\Schedules";//string to go to the location where the screening files are stored on the current device
    string[] screeningFiles = Directory.GetFiles(screeningPath, "*.txt");//putting all text based files in the path gotten in the previous line into an array 
    Console.WriteLine("Choose the day of screening with the corresponding number");
    List<Screening> screening = new List<Screening>();//creating a list for the different screenings before the files are loaded in
    int count = 0;
    for (int j = 0, jmax = screeningFiles.Length; j < jmax; j++)//for loop to go through all the text files found and loaded in
    {
        count++;
        Console.WriteLine(count + ". " + screeningFiles[j]);
    }
    int scheduleChoice = int.Parse(Console.ReadLine()) - 1;
    string[] filelines = File.ReadAllLines(screeningFiles[scheduleChoice]);//creates an array of every line in the choosen screening day
    foreach (string line in filelines)//a loop that will go through all the lines in the current file
    {
        string[] words = line.Split(splitChars);//splits the lines of the schedule using the split characters list
        Boolean screenAndSeatPossible = false;//first a boolean for if the screening is possible is made
        foreach (Screen screen in screens)//a loop to go through the different instances in screens
        {
            if (words[8] == screen.getName())//checks the 8th word(which should be the Screen name) is the same as a name for an instance of a screen
            {
                if (int.Parse(words[10]) <= screen.getSSeat() && int.Parse(words[12]) <= screen.getPSeat())//if it is then it will check that the amount of seats the screening says it has left is less than the standard and premium seats respectively
                {
                    screenAndSeatPossible = true;//if correct it will change the boolean to true
                }
            }
        }
        if (screenAndSeatPossible == true)//checks if the boolean is true
        {
            screening.Add(new Screening(words[2], int.Parse(words[4]), int.Parse(words[6]), words[8], int.Parse(words[10]), int.Parse(words[12])));//if true it creates a new instance of a Screening in the screenings list
        }
    }
    Console.WriteLine("Would the customer like tickets to a screening, enter 'Yes' or 'No'");
    string answer = Console.ReadLine();
    if (answer == "Yes")
    {
        count = 0;
        foreach (Screening screenings in screening)
        {
            count++;
            Console.WriteLine(count + ". " + screenings.ToString());
        }
        Console.WriteLine("Select a screening by inputting a number corresponding");
        int scrChoice = int.Parse(Console.ReadLine());
        string filmName = screening[scrChoice - 1].film;
        count = 0;
        foreach (Films movies in films)
        {
            if (movies.getName() == filmName)
            {
                break;
            }
            count++;
        }
        Console.WriteLine("Are all customers above the age rating of " + films[count].getRating() + ". If so input Yes");
        string AgeVerify = Console.ReadLine();
        Sale sales = new Sale();
        if (AgeVerify == "Yes")
        {

            addTicket(sales, screening[count]);
            Console.WriteLine(screening[count].ToString());
        }
        Console.WriteLine("Do the customers want any concessions? Enter 'Yes' if so");
        string WantConcessions = Console.ReadLine();
        while (WantConcessions == "Yes")
        {
            addConcession(sales);
            Console.WriteLine("Does the customer want more concessions, if so enter 'Yes' else enter anything else");
            WantConcessions = Console.ReadLine();
        }
        Console.WriteLine(screening.Count);
        string[] updatedSchedule = new string[screening.Count];
        count = 0;
        foreach (Screening screening1 in screening)
        {
            updatedSchedule[count] = $"[Screening:{screening1.film}%TimeH:{screening1.timeH}%TimeM:{screening1.timeM}%Screen:{screening1.Screen}%sSeat:{screening1.sSeats}%pSeats:{screening1.pSeats}]";
            count++;
        }
        System.IO.File.WriteAllLines(screeningFiles[scheduleChoice], updatedSchedule);
    }
}