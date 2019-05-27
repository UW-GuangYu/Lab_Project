using Microsoft.SharePoint.Client;
using System;
using System.Security;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext context = new ClientContext("https://fgfbrands1.sharepoint.com/sites/SAP/Project"))
            {

                try
                {
                    // Web web = context.Web;
                    context.Credentials = new SharePointOnlineCredentials(getUserName(), getPassword());
                    Console.WriteLine("credentials success");

                    List announcementsList = context.Web.Lists.GetByTitle("Report Testing");
                   // ListCollection collList = web.Lists;
                    CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
                    ListItemCollection items = announcementsList.GetItems(query);
                    Console.WriteLine("Success to Run");
                    
                    context.Load(items);
                    Console.WriteLine("load success");
           
                    context.ExecuteQuery();
                    Console.WriteLine("execute query success");


                    foreach (ListItem listItem in items)
                    {
                        Console.WriteLine("Hi, I am writing");
                        Console.WriteLine(listItem["Title"]);          //task name
                        Console.WriteLine(listItem["Report_x0020_Name"]);     //report Name
                        Console.WriteLine(listItem["Priority"]);
                        Console.WriteLine(listItem["Status"]);
                    }
                    Console.ReadKey();
                }

                catch (Exception)
                {
                    Console.WriteLine("Failed to catch");
                    Console.ReadKey();

                }
            }
        }

        static string getUserName()
        {
            return "gwu@fgfbrands.com";
        }

        static SecureString getPassword()
        {
            string password = "CYD666wdw@";
            SecureString encryptedPassword = new SecureString();
            foreach (var c in password.ToCharArray())
            {
                encryptedPassword.AppendChar(c);
            }
            return encryptedPassword;
        }
    }
}
