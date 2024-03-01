using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Вы – маг и у вас в арсенале есть несколько заклинаний, которые вы можете использовать против теневого Босса. Вы должны уничтожить босса и только после этого будет вам покой."); Console.ReadKey();

            int playerHP = 500, bossHP = 800;
            //boss attack
            int Rashamon = 100, shadowCloning = 150;
            int healingPotion = 3;
            //player attack
            int Huganzakura = 220, magicalAttack = 180;
            int healingPotion2 = 3;
            int assign = 0;
            int rasha = 0;

            if (playerHP <= 0 && bossHP <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nНичья, победила дружба");
            }
            else if (bossHP <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nВы победили босса");
            }
            else if (playerHP <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nВы проиграли боссу");
            }

            while (playerHP > +0 && bossHP > +0)
            {
                Random chaoticAttack = new Random();
                int ca = chaoticAttack.Next(80, 250);
                Random heal = new Random();
                int hp = heal.Next(25, 50);
                Random bossInput = new Random();
                int bi = bossInput.Next(1, 4);



                //boss
                switch (bi)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Босс нанес вам 100 урона, ударом рашамон");
                        playerHP = playerHP - Rashamon;
                        Console.Write($"\nУ вас осталось {playerHP} хп"); Console.ReadKey(); Console.Clear();
                        assign = rasha;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Босс нанес вам 150 урона, ударом теневого клонирования");
                        playerHP = playerHP - shadowCloning;
                        Console.Write($"У вас осталось {playerHP} хп"); Console.ReadKey(); Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Босс отхилился на {hp} хп");
                        bossHP = bossHP + hp;
                        Console.Write($"У босса осталось {--healingPotion} зелий"); Console.ReadKey(); Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Неивестная команда");
                        break;
                }
                
                //player
                Console.WriteLine("Ваша очередь");
                Console.Write("'1' - чтобы ударить магией (100 урона), '2' - чтобы ударить атакой хуганзакура (только после удара рашамон, 100 урона), '3' чтобы отхилиться (от 25 до 50хп): ");
                int userInput = Convert.ToInt32(Console.ReadLine());

                
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("\nВы нанесли 100 урона теневому боссу");
                        bossHP = bossHP - magicalAttack;
                        Console.Write($"У босса осталось {bossHP} хп"); Console.ReadKey(); Console.Clear();
                        break;

                    case 2:

                        if (assign == rasha)
                        {
                            Console.WriteLine("\nВы нанесли 200 урона теневому боссу");
                            bossHP = bossHP - Huganzakura;
                            Console.Write($"У босса осталось {bossHP} хп"); Console.ReadKey(); Console.Clear();
                        }
                        else if (assign != rasha)
                        {
                            Console.Write("\nБосс не нанес удар Рашамон, поэтому удар хуганзакура не может быть выполнен."); Console.ReadKey(); Console.Clear();
                        }
                        break;

                    case 3:
                        Console.WriteLine($"\nВы отхилились на {hp} хп");
                        playerHP = playerHP + hp;
                        Console.Write($"У вас осталось {--healingPotion2} зелий"); Console.ReadKey(); Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Неивестная команда");
                        break;
                }
                if (playerHP <= 100)
                {
                    Console.WriteLine("\nКритическое значение здоровья");
                    Console.WriteLine("Выпускается секретная атака хаотичная сфера");
                    Console.WriteLine("Врагу наносится " + ca + " урона");
                    bossHP = bossHP - ca;
                }
            }
        }
    }
}
