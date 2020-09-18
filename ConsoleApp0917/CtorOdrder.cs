using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0917_1 //소멸자와 생산자 순서확인
{
    class Person
    {
        public Person()
        {
            Console.WriteLine("Person 생산자");//1
        }
        ~Person()
        {
            Console.WriteLine("Person 소멸자");//2
        }
    }
    class Employee : Person
    {
        public Employee()
        {
            Console.WriteLine("Employee 생산자");//3
        }
        ~Employee()
        {
            Console.WriteLine("Employee 소멸자");//4
        }
    }



    class CtorOdrder
    {
        static void Main() // 변수는 스택구조(LIFO)
        {

            Person per = new Person();
            Employee emp = new Employee();
            //1->1->3->4->2->2

        }
    }
}