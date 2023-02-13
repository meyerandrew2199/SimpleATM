
using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    public string getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getbalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setfirstName(string newfirstName)
    {
        firstName = newfirstName;
    }

    public void setlastName(string newlastName)
    {
        lastName = newlastName;
    }

    public void setbalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Enter deposite amount");
            try
            {
                    double deposit = double.Parse(Console.ReadLine());
                currentUser.setbalance(currentUser.getbalance() + deposit);
                Console.WriteLine("Thank you for your deposit. Your new balance is $" + currentUser.getbalance());
                    
            }
            catch
            {
                { Console.WriteLine(" Invalid amount. Please try again."); }
            }
                
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw:");

            try
            {
                double withdraw = double.Parse(Console.ReadLine());
                //check if user has enough money
                if (currentUser.getbalance() < withdraw)
                {
                    Console.WriteLine("Insufficent balance");
                }
                else
                {
                    currentUser.setbalance(currentUser.getbalance() - withdraw);
                    Console.WriteLine("You're all set! Have a great day.");
                }
            }
            catch
            {
                Console.WriteLine(" Invalid amount. Please try again.");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: $" + currentUser.getbalance());
        }
        //test fake users
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1253564234567755222", 3433, "John", "Smith", 10.01));
        cardHolders.Add(new cardHolder("7574638477583678742", 5453, "Tim", "Jobs", 516.77));
        cardHolders.Add(new cardHolder("9457738975789739023", 1112, "Kayla", "Griffen", 229.44));
        cardHolders.Add(new cardHolder("7684737328546788753", 8547, "Steve", "Swanson", 364.85));
        cardHolders.Add(new cardHolder("5353425443646323455", 9587, "Allen", "Poe", 1.03));

        //prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardnum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardnum = Console.ReadLine();
                //check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardnum);
                if (currentUser != null) { break; }
                else { Console.WriteLine(" Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine(" Card not recognized. Please try again."); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse (Console.ReadLine());
                //check against db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine(" Inncorrect pin. Please try again."); }
            }
            catch { Console.WriteLine(" Inncorrect pin. Please try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ", to SimpleATM");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse (Console.ReadLine());
            }
            catch
            {
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
        }
        while (option !=4);
        Console.WriteLine("Thank you for using SimpleAtm. Have a great day.");


    }
}

