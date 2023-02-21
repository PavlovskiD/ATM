using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    string getNum()
    {
        return cardNum;
    }
    int getPin()
    {
        return pin;

    }
    string getFirstName()
    {
        return firstName;
    }

    string getLastName()
    {
        return lastName;
    }

    double getBalance()
    {
        return balance;
    }

    public void setCardNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;

    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;

    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


     public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose one....");
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Show Balance");
                Console.WriteLine("4.Exit");
            }
            void Deposit(cardHolder currentuser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = double.Parse(Console.ReadLine());
                currentuser.setBalance(currentuser.getBalance()+deposit);
                Console.WriteLine("Thank you for your deposit.This is your new balance: " + currentuser.getBalance());
            }
            void Withdraw(cardHolder currentuser)
            {
                Console.WriteLine("How much money would you like to wwithdraw: ");
                double withdraw = double.Parse(Console.ReadLine());
                if (currentuser.getBalance() < withdraw)
                {
                    Console.WriteLine("Sorry, Insufficient funds");
                }
                else
                {
                    currentuser.setBalance(currentuser.getBalance() - withdraw);
                    Console.WriteLine("Thank you for withdrawing");
                }
            }
            void Balance(cardHolder currentuser)
            {
                Console.WriteLine("Current Balance: " + currentuser.getBalance());

            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("123456789", 1234, "Dejan", "Pavlovski", 420.69));
            cardHolders.Add(new cardHolder("987654321", 4321, "Ole", "Gligorov", 690.42));

            Console.WriteLine("Welcome To This ATM");
            Console.WriteLine("Insert Card Number: ");
            string debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null) { break; }
                    else { Console.WriteLine("card not found.pleas try again!"); }

                }
                catch { Console.WriteLine("card not found.pleas try again!"); }
            }
            Console.WriteLine("Please enter PIN: ");
            int userPin = 0;
            
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect PIN.Pleas try again!"); }

                }
                catch { Console.WriteLine("Incorrect PIN.pleas try again!"); }
            }
            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { Deposit(currentUser); }
                else if (option == 2) { Withdraw(currentUser); }
                else if (option == 3) { Balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you.Come again :)");
        }
}

