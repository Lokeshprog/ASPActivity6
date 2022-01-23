using AdvWorksBL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Adventure Works");
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                int result = blObj.ConnectToDB();
                if (result == 1)
                {
                    Console.WriteLine("Database Connection Established.");
                    Console.Write("Enter Department Name: ");
                    string deptName = Console.ReadLine();
                    Console.Write("Enter Department Group Name: ");
                    string deptGroupName = Console.ReadLine();
                    DeptDetailsDTO newDeptObj = new DeptDetailsDTO();
                    newDeptObj.DeptName = deptName;
                    newDeptObj.DeptGroupName = deptGroupName;
                    int returnValue = blObj.AddNewDeptEF(newDeptObj);
                    if (returnValue == 1)
                        Console.WriteLine("Department Added Sucessfully");
                    else if (returnValue == -1)
                        Console.WriteLine("Department Name Cannot be NULL");
                    else if (returnValue == -2)
                        Console.WriteLine("Department Group Name Cannot be NULL");
                    else
                        Console.WriteLine("ERROR 101: Something went worng.... We will fix it");
                }
                else
                    Console.WriteLine("Database Connection Failed.");
            }
            catch (Exception)
            {
                Console.WriteLine("Devlopers crashed, We will fix it...");
            }
        }
    }
}
