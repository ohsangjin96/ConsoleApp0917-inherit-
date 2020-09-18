using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0917
{
    class Person
    {
        private string fName;
        private string lName;
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
       
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
        // public Person(){ }//생성자를 추가하고 싶으면 빈 생성자를 만들어 놓는 습관을 가져야한다.

        public Person(string _FName, string _LName) 
        {
            fName= _FName;
            lName= _LName  ;
        }
        public Person() : this("김", "아무개") { } //자기 자신 클래스에 파리미터 두개짜리한테 들어가라 ↑↑↑

       
        public virtual void PrintInfoVirtual()//virtual는 OverRide를 가능하게 해주는것(허락해주는것)
        {
           
            Console.WriteLine("=============Person==============");
            Console.WriteLine("First Name: {0}", fName);
            Console.WriteLine("Last Name: {0}", lName);
            Console.WriteLine("==============================");
        }
        public void PrintInfo()
        {
            Console.WriteLine("=============Person==============");
            Console.WriteLine("First Name: {0}", fName);
            Console.WriteLine("Last Name: {0}", lName);
            Console.WriteLine("==============================");
        }
       


    }
    class Employee : Person // private은 상속이여도 못받는다.
    {
        public int employeeID=0;//생성자

        public Employee(int employeeID,string _fname, string _lname) : base(_fname, _lname) //부모 클래스에서 파라미터 두개짜리 생성자를 가져와라
        {
            this.employeeID = employeeID;//내부의 클래스에서만 this 사용
        }
        public Employee(int employeeID) : base("", "") //부모 클래스에서 파라미터 두개짜리 생성자를 가져와라(base는 부모를 뜻함)
        {

            this.employeeID = employeeID;//내부의 클래스에서만 this 사용
            
        }
        
        public override void PrintInfoVirtual()
        {
            base.PrintInfoVirtual();
            Console.WriteLine("employeeID: {0}",employeeID);
        }


        public new void PrintInfo()//new를 쓰면 물려준 클래스것을 무시하고 이것만 출력한다.(OverLoad 다형성, OverRide는 재정의)
                                   //new를 쓰는 이유는 virtual를 못붙여줄때 즉, 오버라이딩이 안될때 사용한다.
        {
            Console.WriteLine("=============Employee==============");
            Console.WriteLine("employeeID:{0}", employeeID);
            Console.WriteLine("First Name: {0}", this.FirstName);
            Console.WriteLine("Last Name: {0}", this.LastName);
            Console.WriteLine("==============================");
        }
    }
    class SalesMan:Employee
    {
        int bouns;

        public SalesMan():base(1)//파라미터가 하나인 부모생성자한테 가라
        {
            bouns = 100;
        }
       
    }








    class InheritTest
    {
        static void Main()
        {
            Person per=new Person();
           

            SalesMan sales = new SalesMan();
            sales.PrintInfo();
            sales.PrintInfoVirtual();



            #region
            Person per = new Person("아", "이유");
            Person per2 = new Person("김", "연아");

            Employee emp1 = new Employee(2020155);
            emp1.FirstName = "류";
            emp1.LastName = "현진";
            emp1.PrintInfo();

            Employee emp2 = new Employee(2020200, "손", "흥민");
            emp2.PrintInfo();

            //생성자를 추가할때 1.부모 클래서에서 기본 생성자를 부른다.
            //                  2.자식 클래스의 생성자 옆에: base를 쓰고 옆에 파라미터 갯수와 타입을 맞춘다 ex) :base("", "")
            //                  ->옆에 아무것도 없으면 부모의 기본 생성자만 가져온다.


            per = emp1; //자식->부모 :자동(암시적) 형변환
            // virtual-override 했을때
            per.PrintInfoVirtual();//override된 메서드인 경우, 태생의 메서드가 실행
            //new 했을때
            per.PrintInfo();//new 된 메서드인 경우, 무조건 변수타입의 메서드가 실행

            emp1 = (Employee)per;  //부모->자식 :명시적형변환(실행됨)
            emp1.PrintInfoVirtual();

            //부모->자식 : 명시적형변환: 명시적형변환은 태생에 따라서 결정된다. 태생이 자식이였으면 가능
            emp1 = (Employee)per2; //부모->자식 : 명시적형변환(InvalidCastExceptrion 발생)
            emp1.PrintInfoVirtual();

            //emp as cat ->per2을 Employee으로 형변환 해서 emp1에 대입, 형변환을 못한다면 null이 대입됨 
            emp1 = per2 as Employee;
            if (emp1 != null) // as 짝궁
            {
                emp1.PrintInfoVirtual();
            }

            //emp is cat -> emp을 cat으로 형변환이 가능하니? 라고 물어본는 것 true,false로 나옴(is는 bool 타입)
            if (per2 is Employee)
            {
                emp1 = (Employee)per2;
            }
            #endregion 
        }
    }
}
//값->값: i=(int) d 
//값->참조(문자),참조(문자)->값: int.Parse(), Convert.ToInt32(), ToString
//참조->참조 :  ex)Person per(부모) , Employee emp(자식) 일때 자식(per+employeeID)이 부모보다 크기때문에
//              emp=(Employee)per 이렇게 해야지 형변환이 가능하다.