﻿/*
 * Filename: ATM
 * Author: @gravitypixelinfinitex
 * Description: Main Version 1
*/





using System;
public class cardHolder 
{ 
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardId, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum() 
    { 
    return cardNum;
    }

    public int getPin() 
    {
    return pin;
    }

    public String getFirstName() 
    {
    return firstName;
    }
    public String getLastName() 
    {
    return lastName;
    }

    public double getBalance() 
    {
    return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin) 
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName) 
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    { 
        lastName = newLastName;
    }

    public void setBalance(Double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args) 
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
            Console.WriteLine("How much ££ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your ££. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        { 
            Console.WriteLine("How much ££ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // check if the user has enough money
            if (currentUser.getBalance() < withdrawal) 
            {
               Console.WriteLine("Insufficient balance: (");
            }
            else 
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're goog to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        { 
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4532761841325002", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("5128381368581872", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("6011188364697109", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("3490693153147110", 4826, "Dawn", "Smith", 54.27));

        // Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card number: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; } 
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin number: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our database
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}
