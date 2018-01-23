//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JediMeditation
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var n = int.Parse(Console.ReadLine());
//            var jediArray = Console.ReadLine().Split().ToArray();

//            var sortedJedi = new LinkedList<string>();
//            var master = new LinkedListNode<string>("M" + "0");
//            var knight = new LinkedListNode<string>("K" + "0");
//            var padawan = new LinkedListNode<string>("P" + "0");
//            var tempMaster = master;
//            var tempKnight = knight;
//            var tempPadawan = padawan;
//            sortedJedi.AddFirst(master);
//            sortedJedi.AddAfter(master, knight);
//            sortedJedi.AddAfter(knight, padawan);


//            foreach (var jedi in jediArray)
//            {
//                if (jedi.StartsWith("M"))
//                {
//                    var newMasterNode = new LinkedListNode<string>(jedi);
//                    sortedJedi.AddAfter(master, newMasterNode);
//                    master = newMasterNode;
//                }
//                else if (jedi.StartsWith("K"))
//                {
//                    var newKnightNode = new LinkedListNode<string>(jedi);
//                    sortedJedi.AddAfter(knight, newKnightNode);
//                    knight = newKnightNode;
//                }
//                else if (jedi.StartsWith("P"))
//                {
//                    var newPadawanNode = new LinkedListNode<string>(jedi);
//                    sortedJedi.AddAfter(padawan, newPadawanNode);
//                    padawan = newPadawanNode;
//                }
//            }

//            sortedJedi.Remove(tempMaster);
//            sortedJedi.Remove(tempKnight);
//            sortedJedi.Remove(tempPadawan);
//            Console.WriteLine(string.Join(" ", sortedJedi));
//            //foreach (var jedi in jediList)
//            //{
//            //    if (jedi.StartsWith("M"))
//            //    {
//            //        if(string.Compare(jedi, master.Value) < 0)
//            //        {
//            //            var newMasterNode = new LinkedListNode<string>(jedi);
//            //            sortedJedi.AddBefore(master, newMasterNode);
//            //            master = newMasterNode;
//            //        }
//            //        else
//            //        {
//            //            sortedJedi.AddAfter(master, jedi);
//            //        }
//            //    }
//            //    else if (jedi.StartsWith("K"))
//            //    {
//            //        if(string.Compare(jedi, knight.Value) < 0)
//            //        {
//            //            var newKnightNode = new LinkedListNode<string>(jedi);
//            //            sortedJedi.AddBefore(knight, newKnightNode);
//            //            knight = newKnightNode;
//            //        }
//            //        else
//            //        {
//            //            sortedJedi.AddAfter(knight, jedi);
//            //        }
//            //    }
//            //    else if (jedi.StartsWith("P"))
//            //    {
//            //        if(string.Compare(jedi, padawan.Value) < 0)
//            //        {
//            //            var newPadanNode = new LinkedListNode<string>(jedi);
//            //            sortedJedi.AddBefore(padawan, newPadanNode);
//            //            padawan = newPadanNode;
//            //        }
//            //        else
//            //        {
//            //            sortedJedi.AddAfter(knight, jedi);
//            //        }
//            //    }
//            //}
//            //Console.WriteLine(string.Join(" ", sortedJedi));


//        }
//    }
//}
