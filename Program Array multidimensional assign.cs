using System; 

namespace firstProject
{  
    class Program
    {
        
    static string[,] EmpDetails = new string[5,3];
    static int [,] EmpSalary = new int[5,7];
    public static void Main(string[] args)
{
       input();
       output();
  }
  public static void input(){
      
    for(int i=0;i<1;i++){
      Console.WriteLine("enter emp code");
      EmpDetails[i,0]=Console.ReadLine();
      Console.WriteLine("enter empname");
      EmpDetails[i,1]=Console.ReadLine();
      Console.WriteLine("enter contact number");
      EmpDetails[i,2]=Console.ReadLine();

      EmpSalary[i,0]=Int32.Parse(EmpDetails[i,0]); //for emp code

      Console.WriteLine("Enter basics");
      EmpSalary[i,1]=Int32.Parse(Console.ReadLine());
      Console.WriteLine("enter da");
      EmpSalary[i,2]=Int32.Parse(Console.ReadLine());
        Console.WriteLine("enter hra");
          EmpSalary[i,3]=Int32.Parse(Console.ReadLine());
          Console.WriteLine("enter tds");
          EmpSalary[i,4]=Int32.Parse(Console.ReadLine());
           Console.WriteLine("gross salary is");

           EmpSalary[i,5]=getGrossSalary(EmpSalary[i,1],EmpSalary[i,2],EmpSalary[i,3]);
           int d=EmpSalary[i,5];
          Console.WriteLine(EmpSalary[i,5]);
          Console.WriteLine("NET SALARY IS");
          EmpSalary[i,6]=getNetSalary(EmpSalary[i,4], d);
          Console.WriteLine(EmpSalary[i,6]);
    } }
    public static void output(){
      Console.WriteLine("Employee Code :  " + EmpDetails[i,0]);
                Console.WriteLine("Employee Name :  " + EmpDetails[i, 1]);
                Console.WriteLine("Employee Contact :  " + EmpDetails[i, 2]);
                
                Console.WriteLine("Employee Basic Salary :  " + EmpSalary[i, 1]);
                Console.WriteLine("Employee DA :  " + EmpSalary[i, 2]);
                Console.WriteLine("Employee HRA :  " + EmpSalary[i, 3]);
                Console.WriteLine("Employee Gross Salary :  " + EmpSalary[i, 4]);
                Console.WriteLine("Employee TDS :  " + EmpSalary[i, 5]);
                Console.WriteLine("Employee Net Salary :  " + EmpSalary[i, 6]);

    }
    public static int getGrossSalary(int basics,int daa,int hraa){
      return (basics+daa+hraa);
    }
    public static int getNetSalary(int tds,int d){
      return ( tds-d);
    }
  }
   }
