using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
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
    string[] Rfilelines = File.ReadAllLines(resourcesFiles[j]);//creates an array of every line in the current file
    foreach (string line in Rfilelines)//a loop that will go through all the lines in the current file
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
Console.WriteLine("Which staff member is using the program");
foreach (Staff employee in staff)//loops through for amount of staff in staff list
{
    Console.WriteLine(employee.ToString());//outputs all information for each staff member
}
int sIDChoice = 0;//initalises choice for the ID number
Boolean ValidID=false;//initalises boolean for ID being a correct ID
int staffPick = 0;//initalises interger for the selection of staff after ID is inputed
while (ValidID == false)//while the ID isnt valid a loop will happen
{
    Console.WriteLine("Enter a Valid ID number");
    sIDChoice = int.Parse(Console.ReadLine());//converts user input to interger and puts it in sIDChoice variable
    int count1 = 0;//makes a count interger variable
    foreach (Staff employee in staff)//loops through for the amount of staff in staff list
    {
        if (sIDChoice == employee.getid())//verifies if the inputted ID is a real ID and correspondes to a staff member
        {
            ValidID = true;//if Id matches makes validID true
            Console.WriteLine("Correct");//outputs 'Correct' to show the user has inputed a correct ID
            staffPick=count1;//makes staffPick the current count so it knows which staff member the ID belongs to
        }
        count1++;//increases count per loop
    }
}

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

///
///A method to add tickets to the customers order requiring both the current sale lsit and current screening list
///
void addTicket(Sale sales, Screening screening)
{
    Console.WriteLine("Select a ticket type below");
    int count = 0;
    foreach (Ticket tick in tickets)//loop going through each ticket type
    {
        count++;
        Console.WriteLine(count + " " + tick.ToString());//outputs each ticket type with a number before hand to show which option it is
    }
    int Tchoice = int.Parse(Console.ReadLine()) - 1;//reads user input and takes 1 away to get the selection of ticket type

    int aOfChoice = 0;//initilisases interger for how many tickets user wants
    while (aOfChoice <= 0)//loops whilst wanted ticket amount is below or equal to 0
    {
        Console.WriteLine("How many would the customer like, enter a number above 0");
        aOfChoice = int.Parse(Console.ReadLine());//amount of choice reads user input and converts to an interger using int.Parse
    }
    if (Tchoice == 0)
    {
        if (aOfChoice > screening.sSeats)//if the amount of seats wanted is more than the amount of standard seats left the method will end without buying tickets
        {
            return;
        }
        screening.sSeats = screening.sSeats-aOfChoice;//if amount of seats is less than left over the amount of wanted seats is taken away from remaining seats
    }
    if (Tchoice == 1)
    {
        if (aOfChoice > screening.pSeats)//if the amount of seats wanted is more than the amount of premium seats left the method will end without buying tickets
        {
            return;
        }
        screening.pSeats = screening.pSeats - aOfChoice; //if amount of seats is less than left over the amount of wanted seats is taken away from remaining seats
    }
    for (int i = 0; i < aOfChoice; i++)//loops the amount of times as tickets wanted
        {
            sales.AddSaleItem(tickets[Tchoice]);//each iteration adds a ticket to the sales list
        }
        Console.WriteLine(sales.ToString());//outputs the sales list
}
///
///method to add a concession to the sales list, needs the sales list to function
///
void addConcession(Sale sales)
{
    Console.WriteLine("Select a concession below");
    int count = 0;
    foreach (Concession concession in concessions)//loops through the amount of times as the amount of concessions
    {
        count++;
        Console.WriteLine(count + " " + concession.ToString());// outputs each concession and price with a number behind showing which option the selection is
    }
    int conchoice = int.Parse(Console.ReadLine()) - 1;//converts user input to interger and removes 1 from the selection to get the correct identifier
    Console.WriteLine("How many would you like");
    int aOfChoice = int.Parse(Console.ReadLine());//converts user input to interger for the amount of said concession wanted
    for (int i = 0; i < aOfChoice; i++)//loops the amount of times for the amount of concessions wanted
    {
        sales.AddSaleItem(concessions[conchoice]);//each iteration adds a concession to the sales list
    }
    Console.WriteLine(sales.ToString());//outputs the sales list to the user
}
///
///A method to launch a loop once an employee uses the program
///
void menu(List<Screening> screening)
{
    Sale sales = new Sale();//initiates a new instance of the sale object
    Boolean done = false;//makes a false boolean
    while (done == false)//loops whilst the previous boolean is false
    {
        Console.WriteLine("Does the customer want to (1)purchase tickets or (2)purchase concessions");
        int choice = int.Parse(Console.ReadLine());//converts user input to interger corresponding to wanting ticket or concessions
        if (choice == 1)//if input is 1 launches ticket option
        {
            choosingTicket(sales, screening);//calls ticket choosing method and passes through the sale instance and screening instance
        }
        if (choice == 2)//if input is 2 launchs concession option
        {
            addConcession(sales);//method to add a concession to the sale which is passed through to the method
        }
        Console.WriteLine("Is customer Finished with their order, if so enter 'Yes'");
        string Fin = Console.ReadLine();//reads user input and stores in a varibale
        if (Fin == "Yes")//compares user input to word needed to end the loop
        {
            done = true;//if user input and word are the same the boolean changes to true and ends the loop
        }
    }
}
///
///Method to choose which screening of which film tickets are to be bought for
///
void choosingTicket(Sale sales, List<Screening> screening)
    {
        int count = 0;
        foreach (Screening screenings in screening)//makes a loop through each line in the screening list
        {
            count++;
            Console.WriteLine(count + ". " + screenings.ToString());//outputs it with a count crresponding to a screening
        }
        Console.WriteLine("Select a screening by inputting a number corresponding");
        int scrChoice = int.Parse(Console.ReadLine());//takes user input converts to interger and stores it
        string filmName = screening[scrChoice - 1].film;//gets the film which the user picked and puts the name in a variable
        count = 0;
        foreach (Films movies in films)//loops for each film in the film list
        {
            if (movies.getName() == filmName)//compares if the name of choosen film is the current film in the current loop
            {
                break;//once it is the same film the loop breaks
            }
            count++;//count increases each iteration
        }
        Console.WriteLine("Are all customers above the age rating of " + films[count].getRating() + ". If so input Yes");
        string AgeVerify = Console.ReadLine();//gets user input and stores
        if (AgeVerify == "Yes")//compares if user input is 'Yes' if not nothing happens
    { 
            addTicket(sales, screening[count]);//calls the method to add tickets to the sale and passes the sales list and screening wanted
            Console.WriteLine(screening[count].ToString());//displays the updated information of the choosen screening
        }
    }

if (staff[staffPick].getlevel() == "Manager")//verifies if staff level is a manager or not
{
    menu(screening);//calls menu for adding tickets and concessions to customer order
    //If so leads into a menu that should be able to change screening details
}
else
{
    menu(screening);//calls menu for adding tickets and concessions to customer order
}
string[] updatedSchedule = new string[screening.Count];//creates a new empty array of strings the length of the current open screening schedule
count = 0;//reassigns the count variable to 0
foreach (Screening screening1 in screening)//loops for each time there is a screening in screening
{
    updatedSchedule[count] = $"[Screening:{screening1.film}%TimeH:{screening1.timeH}%TimeM:{screening1.timeM}%Screen:{screening1.Screen}%sSeat:{screening1.sSeats}%pSeats:{screening1.pSeats}]";
    //the above line inputs every screening into the newly made array of strings in the format the file is
    count++;//iterates every loop to make sure the array is filled
}
System.IO.File.WriteAllLines(screeningFiles[scheduleChoice], updatedSchedule);//overwrites the screening file with the new schedule after tickets have been sold
    