using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13_AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass myc = new MyClass();
            //MyClass.Hello();
            //MyClass.MyName("Moz");
            //نمیشه از کلاس های ابجکت سازی کرد
            //یا حتی بدون ابجکت استفاده کرد
            //با کلیدواژه استاتیک اشتباه نشود
            //Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by
            //the derived class
            //An abstract class can have both abstract and regular methods
            //برای اینکه بدنه یک متد ابسترکت رو ایجاد کنیم از کلمه اورراید بهتره استفاده کنیم
            //An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies)
            //By default, members of an interface are abstract and public
            //Interfaces can contain properties and methods, but not fields


            Console.WriteLine("**************** Class User ***************");

            User use = new User();
            use.Hello();
            Console.WriteLine(use.Goodbay());
            use.MyName("Moz");

            Console.WriteLine("**************** Class Test from Class User ***************");

            Test testy = new Test();
            testy.Hello();
            testy.MyName("Moz");

            Console.WriteLine("**************** Class Test2 from Class MyClass ***************");

            Test2 testy2 = new Test2();
            testy2.Hello();
            testy2.MyName("Moz");

            Console.WriteLine("**************** Class Test3 from Class MyClass ***************");

            Test3 testy3 = new Test3();
            testy3.MyName("Moz");

            Console.WriteLine("**************** Class Sum ***************");

            NoHaritage Sum = new NoHaritage();
            Sum.Sum(10, 5);

            Console.ReadKey();
        }
    }

    public abstract class MyClass
    {
        public void Hello()
        {
            Console.WriteLine("Hello World!");
        }
        
        public virtual void MyName(string Name)
        {
            Console.WriteLine("m_d_rezaei "+Name);
        }
    }

    public class User : MyClass
    {
        //public override void MyName()
        //{
        //    //اینجا که ارور میده میگه این ورودیش متفاوته و اورلود شده پس یک متد دیگست برای چی از کلمه اورلود استفاده کردی اورلود اشتباهه
        //    base.MyName(Name);
        //    //اینجا هم نیم رو پیدا نمیکنه
        //    Console.WriteLine(10);
        //}

        //public override void MyName(int a)
        //{
        ////    base.MyName(Name);
        //    Console.WriteLine(a);
        //}

        public override void MyName(string Name)
        {
            //base.MyName(Name);
            //یک بار بدون کامنت اجرا کن یکبار با کتمنت شده اجرا کن
            //این یعنی کلاس بیس که ما ازش ارث بری کردیم بیاد و متد مای نیمش رو اجرا کنه و چون
            //ابسترکت هست اینجوری ننوشتیمش کلن اینجوریه
            //اون نیم داخلش هم همون نیم ورودی متدی هست که الان توشیم
            //دوتا کلاس داریم یکی بیس یکی درایود
            Console.WriteLine("f");
            //در متدی که اورراید میکنیم میتونیم کاملن چیزی که خودمون میخوایم رو بنویسیم
        }

        //اورراید مال وقتیه که متد ما ویرچوال داشته باشه
        //خب در اینتر فیس ما خودمان متد هارا مینویسیم در کلاسی که ازش ارث بری کردیم
        //ولی در ابسترکت ، متد ها عادی از قبل نوشته شده هستند
        //پس ویرچوال و اورراید میکنیم چون شاید کسی نخواست از متد های از قبل تعیین شده استفاده کنه
        //یا شاید خواست چیزی بهشون اضافه کنه

        public string Goodbay()
        {
            return "Goodbay world!";
        }

        public void Hello()
        {
            //اگر روی اسم هلو که زرد هست بریم میبینیم که نوشته عضو ارث بری شده رو هاید میکنه و زیر این هلو هم یک خط سبز هست
            //و میگه از کلیدواژه نیو استفاده کنیم اگر که از قصد میخواستیم هایدش کنیم
            //public new void Hello()

            base.Hello();
            Console.WriteLine("S Hello");
            //یعنی حتی اینجوری بدون استفاده از ویرچوال و اورراید هم میتونیم کارمون رو انجام بدیم

        }
    }
    
    public class Test : User
    {
        public override void MyName(string Name)
        {
            //این اورراید بالا خوب داره متدی رو اورراید میکنه که اون متد اورراید شده
            //پس امکان اوررایدش هست که قبلن یه بار اورراید شده
            //فقط امکان اورراید متد های ویرچوال موجود هست

            base.MyName(Name);
            //مطابق با درون متد ماینیم کلاس یوزر کار میکنه اگه توی اون متد چیزی کامنت بشه اینجا هم تاثیرش رو میزاره
            base.Hello();
            //خود یوزر هلو نداره ولی دسترسی داره
            //پس اولویت اول با خود کلاس بیس خودمونه و بعد بیس بیسمون
            Console.WriteLine(base.Goodbay());
            //همه این بیس ها از یوزر میان چون بیس این کلاس یوزر هستش
        }
    }

    public class Test2 : MyClass
    {
        public override void MyName(string Name)
        {
            base.MyName(Name);
            //اینا بیسشون دیگه یوزر نیست و مای کلاس هستش
        }

        //public override void MyName(string Name)
        //{
        //    //این مند قبلا اورراید شده 
        //    //امکان اورراید مجدد در این کلاس نیست
        //}
    }

    public class Test3 : MyClass
    {
        public override void MyName(string Name)
        {
            base.MyName(Name);
            //اینا بیسشون دیگه یوزر نیست و مای کلاس هستش
            Console.WriteLine("Extra");
        }
    }
    public sealed class NoHaritage
    {
        public void Sum(int a , int b)
        {
            Console.WriteLine(a+b);
        }
    }

    //public class Test4 : NoHaritage
    //{
              //Error
              //نمیشه از کلاسی که سییلد هست ارث بری کرد
    //}
}
