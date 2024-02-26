/*
 * -----------------------------------------------------------------------
#
Altering the program from the previous module by adding the ability to store, modify and open the clients’ information.
When a file is opened all previous information should be added to the program and you should be able to save the information.

-------------------------------------------------------------
Your program must have the following:

All the previous modules' information.
Add the ability to store, modify and open a file.
You must provide the entire project file and you must save to an input file. REQUIRED.
You must provide the following:
Your code
Screenshot of your fully functioning program with inputs/outputs

## ---------------------------

// src
https://www.geeksforgeeks.org/how-to-read-and-write-a-text-file-in-c-sharp/
https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file1
https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
*/

using System;
using System.IO;

//moved to one unit to make simpler
public class Customers { 

    private string fname;
    private string lname;
    private long NUMPhone;
    private int totalInvoice;
    
    public override string ToString() 
    {
        return String.Format("Name: {0} {1}\nPhone Number: {2}\ntotalInvoice: {3}", fname, lname, NUMPhone, totalInvoice);
    }
    
    Customers(string first, string last, long phone, int bill) 
    {
        fname = first;
        lname = last;
        NUMPhone = phone;
        totalInvoice = bill;
    }




    public static void Main() 
    { 
   
        Customers[] customers = new Customers[3];
        string[] products = new string[] 
        { "Product 1",  "Product 2", "Product 3","Product 4","Product 5" };

        int[] prices = new int[] { 10, 5, 20, 17,  30 };
        string fname, lname, input;
        long NUMPhone;
        int count = 0, total = 0;
        Console.Write("Load Previous file (Y/N)");
        string ch = Console.ReadLine();

        try
        {
        if ((ch == "Y") || (ch == "y")) 
        {
            ch = "Y";

            using(StreamReader reader = new StreamReader("document.txt")) 
            {
                for (int i = 0; i < 3; i++) 
                {
                    fname = reader.ReadLine();
                    lname = reader.ReadLine();
                    NUMPhone = long.Parse(reader.ReadLine());
                    total = int.Parse(reader.ReadLine());
                    customers[i] = new Customers(fname, lname, NUMPhone, total);
                }

            }

        }

              
        while ((count < 3) && (ch != "Y")) 
        {
            Console.WriteLine("Sold {0}", (count + 1));
            Console.WriteLine("Select product\n");

            //Reads first name        
            Console.Write("Customer First Name: ");
            fname = Console.ReadLine();


            Console.Write("Last Name: ");
            lname=Console.ReadLine();  

                Console.Write("Customer Phone Number: ");
                NUMPhone = long.Parse(Console.ReadLine());
                total = 0;
                int option;
                int i = 0;


                foreach(string product in products) 
                {
                    Console.WriteLine("{0} {1}", (i + 1), product);
                    i++;

                }
                Console.WriteLine("0 Exit");
                
                

                while (true) 
                {
                    Console.Write("Your Option : ");
                    input = Console.ReadLine();
                    
                    

                    option = Convert.ToInt32(input);
                    
                    
                    while (option < 0 || option > 5) 
                    {
                        Console.WriteLine("Please enter valid option.");
                        Console.Write("Your option: ");
                        input = Console.ReadLine();
                                          
                        option = Convert.ToInt32(input);

                    }
                    
                    if (option == 0) 
                    {
                        break;
                    }
                    total = total + prices[option - 1];
                               
                }
                    
                customers[count] = new Customers(fname, lname, NUMPhone, total);
                count++;

            }
        catch (Exception) 
            {
                Console.WriteLine("Invalid");
            }

        }
    /*
      //src https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
    */
        using(StreamWriter writer = new StreamWriter("customers.txt")) 
        {
            for (int i = 0; i < 3; i++) {
                writer.WriteLine(customers[i].fname);
                writer.WriteLine(customers[i].lname);
                writer.WriteLine(customers[i].NUMPhone);
                writer.WriteLine(customers[i].totalInvoice);

            }

        }
        
        


        int j = 0;
        foreach(Customers customer in customers) 
        {
            Console.WriteLine("{0} Invoice", (j + 1));
            Console.WriteLine(customer);
            j++;

        }

    }

}