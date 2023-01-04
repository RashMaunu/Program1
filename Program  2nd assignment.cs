using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace project
{
    class CustInfo
    { public int custId;
      public string CustName;
      public string CustNum;
      }
      class cus{
        public static void Main(string[] args){
            Console.WriteLine("enter number of persons:");
            //string a;
            int b;
            b=Convert.ToInt32(Console.ReadLine());
            //b=Int32.Parse(a);
            List <CustInfo> clist = new List<CustInfo>();
            int vcusId;
            string VcusName;
            string VcusNum;
            for(int i=1;i<=b;i++){
                Console.WriteLine($"enter Id of {i} person");
                vcusId=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"enter Name of {i} person");
                VcusName = Console.ReadLine();
                Console.WriteLine($"enter contact number of {i} person");
                VcusNum= Console.ReadLine();
                clist.Add(new CustInfo {custId=vcusId , CustName= VcusName , CustNum = VcusNum} );
            }
            filewrite(clist);
            fileread(clist);
        }
        static void filewrite(List <CustInfo> clist){
             string str;
              StreamWriter f = File.CreateText(@"C:\project1\firstProject\demo.dat");
                foreach(CustInfo cust in clist){
                    str = cust.custId.ToString()+","+cust.CustName+","+cust.CustNum;
                    Console.WriteLine(str);
                    f.WriteLine(str);
                }
                f.Close();
                }
                //read from file
                static void fileread(List <CustInfo> clist){
                StreamReader fil = new StreamReader(@"C:\project1\firstProject\demo.dat");
                string s=fil.ReadLine();
                string[] arr=s.Split(',');
                int n =Convert.ToInt32(arr[0]);
                clist.Add(new CustInfo{custId=n , CustName= arr[1] , CustNum = arr[2]});
                Console.WriteLine("the datails are");
                foreach(CustInfo cus in clist){
                    Console.WriteLine(" {0}",cus.custId);
                    Console.Write(" {0}",cus.CustName);
                    Console.Write(" {0}",cus.CustNum);
                }
                }
    }
    }