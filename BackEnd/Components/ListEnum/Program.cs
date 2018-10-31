using System;

namespace AboutEnum
{
    /// <summary>
    /// 枚举相关
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 遍历枚举中所有的值
            foreach (var suit in Enum.GetValues(typeof(Suits)))
            {
                Console.WriteLine((int)suit + ":" + suit);
            }
            #endregion

            #region  GetHashCode 方法取值问题
            //如果你的Enum没有继承自sbyte的时候，或者继承自Int的时候是没有问题的（Enum默认继承自Int？），但是，当继承自其他类型的时候，就不一定了。。。
            //最后，以后还是强制转换吧

            Console.WriteLine(FileAttribute.ReadOnly.GetHashCode());

            var file = FileAttribute.ReadOnly | FileAttribute.Archived;
            Console.WriteLine(file);

            #endregion

            #region 类型转换
            //Enum-- > String

            //(1)利用Object.ToString()方法：
            Console.WriteLine(Suits.Clubs.ToString());

            //(2)利用Enum的静态方法GetName与GetNames：
            Console.WriteLine(Enum.GetName(typeof(Suits), 1));
            Console.WriteLine(Enum.GetName(typeof(Suits), Suits.Hearts));

            //public static string[] GetNames(Type enumType) 将返回枚举字符串数组
            var array = Enum.GetNames(typeof(Suits));
            Console.WriteLine(array.Length);

            //String-->Enum
            //(1)利用Enum的静态方法Parse：
            Console.WriteLine((Suits)Enum.Parse(typeof(Suits), "Hearts"));

            //Enum-->Int
            //(1)因为枚举的基类型是除 Char 外的整型，所以可以进行强制转换。
            Console.WriteLine((int)Suits.Clubs);

            //Int-->Enum
            //(1)可以强制转换将整型转换成枚举类型。
            var suit1 = (Suits)2;
            Console.WriteLine(suit1.ToString());

            ////(2)利用Enum的静态方法ToObject。
            var suit2 = (Suits)Enum.ToObject(typeof(Suits), 3);
            Console.WriteLine(suit2.ToString());
            #endregion

            //判断某个整型是否定义在枚举中的方法：Enum.IsDefined
            var isExist = Enum.IsDefined(typeof(Suits), 6);
            Console.WriteLine(isExist);

            Console.ReadKey();
        }
    }
    public enum Suits
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds,
        NumSuits
    }

    [Flags]
    public enum FileAttribute
    {
        ReadOnly = 0x01,
        Hide = 0x02,
        System = 0x04,
        Archived = 0x08
    }


    //    枚举 GetHashCode 方法问题

    //   Gender.Male.GetHashCode().ToString()返回的是1，是我要的结果，
    //Status.Normal.GetHashCode().ToString()返回的并不是我要的1，而是一个四位的数字的时候


}
