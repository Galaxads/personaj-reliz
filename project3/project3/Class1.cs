using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    internal class personaj
    {
        private string namepers;
        private int x;
        private int y;
        private bool lagery;
        private int maxlife;
        private int life;
        private int hilki;
        //private bool drugiepers;
        private int uron;
        public void Gamepley()
        {

            Console.WriteLine("Для начала игры введите количество персонажей");
            int colvopersonaj = Convert.ToInt32(Console.ReadLine());
            //personaj pers = new personaj();
            personaj[] pers = new personaj[colvopersonaj + 1];
            personaj[] evil = new personaj[colvopersonaj + 1];
            personaj[] dobro = new personaj[colvopersonaj + 1];


            for (int i = 1; i < pers.Length; i++)
            {
                pers[i] = new personaj();
                pers[i].info();
                pers[i].prints();
                if (pers[i].lagery == true)
                {

                    dobro[i] = new personaj();
                    dobro[i].namepers = pers[i].namepers;
                    dobro[i].maxlife = pers[i].maxlife;
                    dobro[i].x = pers[i].x;
                    dobro[i].y = pers[i].y;
                    dobro[i].uron = pers[i].uron;

                }
                else
                {
                    dobro[i] = new personaj();
                    dobro[i].x = 6;
                    dobro[i].y = 6;
                }
                if (pers[i].lagery == false)
                {
                    evil[i] = new personaj();
                    evil[i].namepers = pers[i].namepers;
                    evil[i].maxlife = pers[i].maxlife;
                    evil[i].x = pers[i].x;
                    evil[i].y = pers[i].y;
                    evil[i].uron = pers[i].uron;

                }
                else
                {
                    evil[i] = new personaj();
                    evil[i].x = 6;
                    evil[i].y = 6;
                }
            }

            Console.WriteLine("Введите номер игрового персонажа");
            int nomerpers = Convert.ToInt32(Console.ReadLine());
            
            pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);


        }
        private void viborgemley(personaj[] pers, personaj[] evil, personaj[] dobro, int nomerpers)
        {
          for(int j=0; ;) 
           {
                if (pers[nomerpers].life > 0)
                {
                    Console.WriteLine("Добро пожаловать в игру.Ваша цель победить всех врагов\nВозможные действия:\n1)Начать движение по карте\n2)Вывести информацию о персонаже\n3)Сменить команду\n4)Использовать лечение\n5)Сменить персонажа");
                    int otvetgeml = Convert.ToInt32(Console.ReadLine());

                    switch (otvetgeml)
                    {
                        case 1:
                            Console.WriteLine("В какое направление пойти(Х/У)");
                            string otvetnaprav = Console.ReadLine();
                            switch (otvetnaprav)
                            {
                                case "X":
                                    pers[nomerpers].movex(this.x); pers[nomerpers].provlagery(pers, evil, dobro, nomerpers); pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);
                                    break;
                                case "Y":
                                    pers[nomerpers].movey(this.y); ; pers[nomerpers].provlagery(pers, evil, dobro, nomerpers); pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);
                                    break;
                            }
                            break;
                        case 2:
                            pers[nomerpers].prints(); pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers); break;
                        case 3:
                            pers[nomerpers].lagery = !pers[nomerpers].lagery;
                            Console.WriteLine($"{pers[nomerpers].lagery}");
                            break;
                        case 4: pers[nomerpers].othill(pers, nomerpers); break;
                        case 5:
                            Console.WriteLine($"Введите номер персонажа за которого хотите играть (Доступно в диапозоне от 1 до {pers.Length - 1})");
                            int nomerpers2 = Convert.ToInt32(Console.ReadLine());
                            if (pers[nomerpers2].life > 0 && pers[nomerpers2].x < 6)
                            {
                                nomerpers = nomerpers2;
                                pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);
                            }
                            else { Console.WriteLine("Персонаж которого вы выбрали недоступен "); }
                            break;
                    }
                    int ostpersdobro = 0;
                    int ostperszlo = 0;
                    for (int i = 1; i <= nomerpers; i++)
                    {
                        if (5 < evil[i].x)
                        {
                            ostperszlo += 1;
                        }
                        if (5 < dobro[i].x)
                        {
                            ostpersdobro += 1;
                        }
                        else if (pers[nomerpers].lagery=true &&ostperszlo==0)
                        { Console.WriteLine("Игра закончена");return; }
                        else if (pers[nomerpers].lagery = false && ostpersdobro == 0)
                        { Console.WriteLine("Игра закончена"); return; }
                    }
                    Console.WriteLine($"На данный момент в игре персонажей из лагеря зло:{ostperszlo} Лагерь добро:{ostpersdobro}");
          }     }
        }

        private void info()
        {
            string nazvanielagera;
            int x1;//для проверки х
            int y1;//для проверки у

            Console.WriteLine("Введите имя персонажа");
            this.namepers = Console.ReadLine();
            Console.WriteLine("Введите ваш лагерь (добро/зло)");
            nazvanielagera = Console.ReadLine();
            switch (nazvanielagera)
            {
                case "Добро":
                case "добро":
                    lagery = true;
                    this.lagery = lagery; break;
                case "Зло":
                case "зло":
                    lagery = false;
                    this.lagery = lagery;
                    break;
            }
            Console.WriteLine("Введите ваши координаты по Х(от -5 до 5)");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ваши координаты по Y(от -5 до 5)");
            y1 = Convert.ToInt32(Console.ReadLine());
            if (-5 <= x1 && x1 <= 5 && -5 <= y1 && y1 <= 5)
            {
                Console.WriteLine("Координаты приняты");
                x = x1;
                y = y1;
                this.x = x;
                this.y = y;
            }
            else
            {
                Console.WriteLine("Координаты которые вы указали выходят за указанные границы и были приравнены к х0 у0");
                this.x = 0; this.y = 0;
            }
            Random xp = new Random();
            maxlife = xp.Next(50, 180);
            life = maxlife;
            Random urons = new Random();
            uron = urons.Next(10, maxlife);
            hilki = 0;
            this.maxlife = maxlife;
        }
        private void prints()
        {
            string nazvanielag;
            if (lagery == true)
            {
                nazvanielag = "Добро";
            }
            else
            {
                nazvanielag = "зло";
            }
            Console.WriteLine($"\nИмя персонажа:{namepers}\nМаксимально возможное количество здоровья:{maxlife}\nВаш лагерь:{nazvanielag}\nКоординаты по х:{x}\nКоординаты по у:{y}");
        }
        private void movex(int x)
        {
            Console.WriteLine($"На данный момент ваши координаты по х:{this.x}\n Куда пойдем?(Влево/вправо)");
            string otvetx = Console.ReadLine();
            switch (otvetx)
            {
                case "Влево":
                case "влево":
                case "Налево":
                case "налево":
                    if (-5 <= this.x && this.x <= 5)
                    {
                        this.x -= 1;
                        Console.WriteLine($"Ваши новые координаты по Х {this.x} и по У {this.y}");
                        break;
                    }
                    else { Console.WriteLine("Вы достиглы границы карты"); break; }
                case "Вправо":
                case "вправо":
                case "Направо":
                case "направо":
                    if (-5 <= this.x && this.x <= 5)
                    {
                        this.x += 1;
                        Console.WriteLine($"Ваши новые координаты по Х {this.x} и по У {this.y}");
                        break;
                    }
                    else { Console.WriteLine("Вы достиглы границы карты"); break; }
            }
        }
        private void movey(int y)
        {
            Console.WriteLine($"На данный момент ваши координаты по У:{this.y}\n Куда пойдем?(Прямо/назад)");
            string otvetx = Console.ReadLine();
            switch (otvetx)
            {
                case "Прямо":
                case "прямо":
                    if (-5 <= this.y && this.y <= 5)
                    {
                        this.y += 1;
                        Console.WriteLine($"Ваши новые координаты по Х {this.x} и по У {this.y}");
                        break;
                    }
                    else { Console.WriteLine("Вы достиглы границы карты"); break; }
                case "Назад":
                case "назад":
                    if (-5 <= this.y && this.y <= 5)
                    {
                        this.y -= 1;
                        Console.WriteLine($"Ваши новые координаты по Х {this.x} и по У {this.y}");
                        break;
                    }
                    else { Console.WriteLine("Вы достиглы границы карты"); break; }
            }

        }
        private bool provlagery(personaj[] pers, personaj[] evil, personaj[] dobro, int nomerpers)
        {
            bool provcoordevilx;
            bool provcoorddobrox;
            bool provcoordevily;
            bool provcoorddobroy;
            bool provlager;
            for (int i = 1; i < pers.Length; i++)
            {
                provcoordevilx = pers[nomerpers].x == evil[i].x;
                provcoordevily = pers[nomerpers].y == evil[i].y;
                provcoorddobrox = pers[nomerpers].x == dobro[i].x;
                provcoorddobroy = pers[nomerpers].y == dobro[i].y;
                switch (pers[nomerpers].lagery)
                {
                    case false:
                        if (provcoorddobrox == true && provcoorddobroy == true)
                        {
                            int nomerpersbattle = i;
                            Console.WriteLine("Вы встретили врага");
                            fight(pers, evil, dobro, nomerpers, nomerpersbattle, lagery);
                        }
                        else if (provcoordevilx == true && provcoordevily == true)
                        {
                            Console.WriteLine("Вы встретили друга");
                            //fight();
                        }

                        break;
                    case true:
                        {
                            if (provcoorddobrox == true && provcoorddobroy == true)
                            {

                                Console.WriteLine("Вы встретили друга");

                            }
                            else if (provcoordevilx == true && provcoordevily == true)
                            {
                                int nomerpersbattle = i;
                                Console.WriteLine("Вы встретили врага");
                                fight(pers, evil, dobro, nomerpers, nomerpersbattle, lagery);
                            }

                            break;

                        }
                }

            }
            return true;

        }
        private void fight(personaj[] pers, personaj[] evil, personaj[] dobro, int nomerpers, int nomerpersbattle, bool lagery)
        {
            
            if (pers[nomerpers].lagery = true)
            {
                evil[nomerpersbattle].life = evil[nomerpersbattle].maxlife;
                Console.WriteLine($"Вы встретили врага {evil[nomerpersbattle].namepers} ");
                Console.WriteLine($"Прямо сейчас начнется бой \nХп вашего персонажа:{pers[nomerpers].maxlife}\nХп вашего врага:{evil[nomerpersbattle].maxlife}");
                while (pers[nomerpers].life > 0 && evil[nomerpersbattle].life > 0)
                {
                    evil[nomerpersbattle].life -= pers[nomerpers].uron;
                    Console.WriteLine($"Вы нанесли врагу {pers[nomerpers].uron} урона.Оставшиеся жизни противника:{evil[nomerpersbattle].life}");
                    pers[nomerpers].life -= evil[nomerpersbattle].uron;
                    Console.WriteLine($"Враг нанес вам  {evil[nomerpersbattle].uron} урона.Оставшиеся жизни :{pers[nomerpers].life}");
                }
                if (pers[nomerpers].life > 0)
                {
                    pers[nomerpersbattle].life = evil[nomerpersbattle].life;
                    pers[nomerpersbattle].x=evil[nomerpersbattle].x = 6;
                    pers[nomerpersbattle].y = evil[nomerpersbattle].y = 6;
                    hilki += 1;
                    Console.WriteLine($"Вы победили в этой битве.Ваши оставшиеся Хп:{pers[nomerpers].life} Количество хилок:{pers[nomerpers].hilki}");
                    pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);
                }
                else { Console.WriteLine("Вы проиграли"); }

            }
            if (pers[nomerpers].lagery = false)
            {
                dobro[nomerpersbattle].life = dobro[nomerpersbattle].maxlife;
                Console.WriteLine($"Вы встретили врага {dobro[nomerpersbattle].namepers} ");
                Console.WriteLine($"Прямо сейчас начнется бой \nХп вашего персонажа:{pers[nomerpers].maxlife}\nХп вашего врага:{dobro[nomerpersbattle].maxlife}");
                while (pers[nomerpers].life > 0 && dobro[nomerpersbattle].life > 0)
                {
                    dobro[nomerpersbattle].life -= pers[nomerpers].uron;
                    Console.WriteLine($"Вы нанесли врагу {pers[nomerpers].uron} урона.Оставшиеся жизни противника:{dobro[nomerpersbattle].life}");
                    pers[nomerpers].life -= dobro[nomerpersbattle].uron;
                    Console.WriteLine($"Враг нанес вам  {dobro[nomerpersbattle].uron} урона.Оставшиеся жизни :{pers[nomerpers].life}");
                }
                if (pers[nomerpers].life > 0)
                {
                    pers[nomerpersbattle].life = dobro[nomerpersbattle].life;
                    pers[nomerpersbattle].x = dobro[nomerpersbattle].x = 6;
                    pers[nomerpersbattle].y = dobro[nomerpersbattle].y = 6;
                    hilki += 1;
                    Console.WriteLine($"Вы победили в этой битве.Ваши оставшиеся Хп:{pers[nomerpers].life} Количество хилок:{pers[nomerpers].hilki}");
                    pers[nomerpers].viborgemley(pers, evil, dobro, nomerpers);
                }
                else { Console.WriteLine("Вы проиграли"); }
            }

        }
        private void  othill(personaj[] pers, int nomerpers)
        {
            Console.WriteLine($"Вы хотите 1)Полность восполнить хп(для этого надо 5 побед из них у вас {hilki})\n2)Потратить 1 частичное лечение (на данный момент можно сделать {hilki} раз");
           int otvet=Convert.ToInt32(Console.ReadLine());
            switch (otvet)
            {
                case 1:
                    if (5<=hilki)
                    {
                        pers[nomerpers].life = maxlife;
                    }
                    else {Console.WriteLine("Недостаточно побед"); }
                    break;
                case 2:
                    if (1 <= hilki)
                    {
                        pers[nomerpers].life +=30 ;
                        hilki -=1;
                    }
                    else { Console.WriteLine("Недостаточно побед"); }
                    break;
            }
        }
    }
}
