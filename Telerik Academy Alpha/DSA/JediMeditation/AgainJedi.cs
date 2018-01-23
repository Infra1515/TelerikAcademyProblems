using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    public class AgainJedi
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var jediInput = Console.ReadLine().Split();

            var jediLinkedList = new LinkedList<string>();
            var master = new LinkedListNode<string>("M");
            var knight = new LinkedListNode<string>("K");
            var padawan = new LinkedListNode<string>("P");

            var tempMaster = master;
            var tempKnight = knight;
            var tempPadawan = padawan;

            jediLinkedList.AddFirst(master);
            jediLinkedList.AddAfter(master, knight);
            jediLinkedList.AddAfter(knight, padawan);

            foreach (var jedi in jediInput)
            {
                if (jedi.StartsWith("M"))
                {
                    var newMaster = new LinkedListNode<string>(jedi);
                    jediLinkedList.AddAfter(master, newMaster);
                    master = newMaster;
                }
                else if (jedi.StartsWith("K"))
                {
                    var newKnight = new LinkedListNode<string>(jedi);
                    jediLinkedList.AddAfter(knight, newKnight);
                    knight = newKnight;
                }
                else if (jedi.StartsWith("P"))
                {
                    var newPadawan = new LinkedListNode<string>(jedi);
                    jediLinkedList.AddAfter(padawan, newPadawan);
                    padawan = newPadawan;
                }
            }

            jediLinkedList.Remove(tempMaster);
            jediLinkedList.Remove(tempKnight);
            jediLinkedList.Remove(tempPadawan);

            Console.WriteLine(string.Join(" ", jediLinkedList));
        }
    }
}
