// See https://aka.ms/new-console-template for more information

// using System;
// namespace StaticVarApplication
// {
//     class StaticVar
//     {
//         public static int num;
//         public void count()
//         {
//             num++;
//         }
//         public static int getNum()
//         {
//             return num;
//         }
//     }
//     class StaticTester
//     {
//         static void Main(string[] args)
//         {
//             StaticVar s = new StaticVar();
//             s.count();
//             s.count();
//             s.count();
//             Console.WriteLine("Variable num: {0}", StaticVar.getNum());
//         }

//     }

// }


Console.WriteLine("Hello, World!");

var num1 = 111;
var num2 = 22;

Console.WriteLine("请输入你的年龄:");
string ageStr = Console.ReadLine();
int age = 0;
//try
//{
//    age = int.Parse(ageStr);
//    Console.WriteLine("age:" + age);
//}
//catch (FormatException e)
//{
//    Console.WriteLine("请输入一个正确的年龄（必须为数字）");
//}

while (true)
{
    try
    {
        age = int.Parse(ageStr);
        Console.WriteLine("age:" + age);
        break;
    }
    catch (FormatException e)
    {
        Console.WriteLine("请输入一个正确的年龄（必须为数字）");
        ageStr = Console.ReadLine();
    }
}


var str1 = "Hello";
var str2 = @"World 
adsfkj 
sdfkj";

Console.WriteLine(str1 + " " + str2 + num1 + num2 + "\n");
Console.ReadKey(); // 等待用户按键

Console.WriteLine(addString("str1", "str2") + "\n");

int[] list1 = [1, 2, 3];
Console.WriteLine("list1:" + list1[1]);

List<string> names = new List<string>();
names.Add("name1");
names.Add("name2");
names.Add("name3");
Console.WriteLine(names[1]);

Dictionary<string, string> dict = new Dictionary<string, string>();
dict.Add("key1", "value1");
dict["key2"] = "value2121";
Console.WriteLine(dict["key2"]);

string addString(string str1, string str2)
{
    return str1 + " " + str2;
}

int addInt(int num1, int num2)
{
    return num1 + num2;
}


if (num1 == 111)
{
    Console.WriteLine("num1 is 111");
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("line:" + i);
}

Console.ReadKey();

HeroModel hero1 = new HeroModel("hero1", 1001, 1010, 101, 110, 101, 11, 10);
HeroModel hero2 = new HeroModel("hero2", 100, 100, 10, 10, 10, 1, 0);
hero1.showInfo();
hero2.showInfo();

hero1.attack(hero2);
hero1.defend(hero2);

hero1.showInfo();
hero2.showInfo();

Console.ReadKey();




// 多线程应用
// using System;
// using System.Threading;

// namespace MultithreadingApplication
// {
//     class ThreadCreationProgram
//     {
//         public static void CallToChildThread()
//         {
//             Console.WriteLine("Child thread starts");
//         }

//         static void Main(string[] args)
//         {
//             ThreadStart childref = new ThreadStart(CallToChildThread);
//             Console.WriteLine("In Main: Creating the Child thread");
//             Thread childThread = new Thread(childref);
//             childThread.Start();
//             Console.ReadKey();
//         }
//     }
// }


class HeroModel
{
    // 属性默认时private

    public string name;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int spd;
    public int level;
    public int exp;
    public int maxHp;
    public int maxMp;
    public int maxExp;
    public int maxLevel;
    public int maxAtk;
    public int maxDef;
    public int maxSpd;

    public HeroModel(string name, int hp, int mp, int atk, int def, int spd, int level, int exp)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.spd = spd;
        this.level = level;
        this.exp = exp;
        this.maxHp = 100;
        this.maxMp = 100;
        this.maxExp = 100;
        this.maxLevel = 100;
        this.maxAtk = 100;
        this.maxDef = 100;
        this.maxSpd = 100;
    }

    public void levelUp()
    {
        if (this.exp >= this.maxExp)
        {
            this.level++;
            this.exp = 0;
            this.maxExp = this.maxExp * 2;
            this.maxHp = this.maxHp + 10;
            this.maxMp = this.maxMp + 10;
            this.maxAtk = this.maxAtk + 10;
            this.maxDef = this.maxDef + 10;
            this.maxSpd = this.maxSpd + 10;
        }
    }

    public void attack(HeroModel hero)
    {
        Console.WriteLine(this.name + "攻击了" + hero.name);
        hero.hp = hero.hp - this.atk;
    }

    public void defend(HeroModel hero)
    {
        Console.WriteLine(this.name + "抵挡了" + hero.name + "的攻击");
        this.hp = this.hp - hero.atk;
    }

    public void showInfo()
    {
        Console.WriteLine("当前英雄:" + this.name);
        Console.WriteLine("hp:" + this.hp);
        Console.WriteLine("mp:" + this.mp);
        Console.WriteLine("atk:" + this.atk);
        Console.WriteLine("def:" + this.def);
        Console.WriteLine("spd:" + this.spd);
        Console.WriteLine("level:" + this.level);
        Console.WriteLine("exp:" + this.exp);
        Console.WriteLine("maxHp:" + this.maxHp);
        Console.WriteLine("maxMp:" + this.maxMp);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

    }
}







string path = @"\\Mac\Home\Desktop\Windows项目\WpfApp2"



