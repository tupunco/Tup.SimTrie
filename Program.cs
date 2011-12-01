using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tup.SimTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            //var trieTree = new TrieTree();
            //var lines = File.ReadAllLines("testdata.txt");
            //trieTree.Build(lines);
            //bool res = false;
            //foreach (var item in lines)
            //{
            //    res = trieTree.Find(item);
            //    if (!res)
            //        throw new ArgumentNullException(item);

            //    res = trieTree.Find(item, true);
            //    if (!res)
            //        throw new ArgumentNullException(item);
            //}

            var trieTree = new TrieTree();
            trieTree.Build(new string[]{"tupunco","tup","nihao","nihaihaoma","xiaobai","小良"
                                        });
            Console.WriteLine("{0}", trieTree.Find("tupunco"));
            Console.WriteLine("{0}", trieTree.Find("tup"));
            Console.WriteLine("{0}", trieTree.Find("nihao"));
            Console.WriteLine("{0}", trieTree.Find("nihaihaoma"));
            Console.WriteLine("{0}", trieTree.Find("小良"));
            Console.WriteLine("{0}", trieTree.Find("xiaobai"));
            Console.WriteLine("----");
            Console.WriteLine("{0}", trieTree.Find("tux"));
            Console.WriteLine("{0}", trieTree.Find("helloworld"));
            Console.WriteLine("{0}", trieTree.Find("hao"));
            Console.WriteLine("{0}", trieTree.Find("bai"));
            Console.WriteLine("{0}", trieTree.Find("haihaoma"));
            Console.WriteLine("{0}", trieTree.Find("unco"));
            Console.WriteLine("{0}", trieTree);
            Console.WriteLine("--f1--");
            Console.WriteLine("{0}", trieTree.Find("tupunco", true));
            Console.WriteLine("{0}", trieTree.Find("tup", true));
            Console.WriteLine("{0}", trieTree.Find("nihao", true));
            Console.WriteLine("{0}", trieTree.Find("nihaihaoma", true));
            Console.WriteLine("--f2--");
            Console.WriteLine("{0}", trieTree.Find("tupunc", true));
            Console.WriteLine("{0}", trieTree.Find("tupuncop", true));
            Console.WriteLine("{0}", trieTree.Find("tupu", true));
            Console.WriteLine("{0}", trieTree.Find("nihaom", true));
            Console.WriteLine("{0}", trieTree.Find("nihaihaomaya", true));
            Console.WriteLine("--f2--");
            Console.WriteLine("{0}", trieTree.Find("tupunc"));
            Console.WriteLine("{0}", trieTree.Find("tupuncom"));
            Console.WriteLine("{0}", trieTree.Find("tupu"));
            Console.WriteLine("{0}", trieTree.Find("nihaom"));
            Console.WriteLine("{0}", trieTree.Find("nihaihaomaya"));
            Console.Read();
        }
    }
}
