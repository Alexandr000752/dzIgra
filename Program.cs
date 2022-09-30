string[,] menu = {{" ", " Начать игру ", " " }, 
                 {" ", " Выбор уровня", " " }, 
                 {" ", " Выход", " " }};

string[,] lvl = {{" ", "1", " " }, 
                 {" ", "2", " " }, 
                 {" ", "3", " " }, 
                 {" ", "4", " " }};                 
                   

string[,] matrix = {{" ", " ", " ", " ", "|", " " }, 
                    {" ", " ", " ", " ", "|", " " }, 
                    {" ", " ", "|", " ", " ", " " }, 
                    {" ", " ", "|", "@", "|", " " }, 
                    {" ", " ", " ", " ", "|", "$", }, 
                    {" ", " ", " ", " ", " ", " ", }};
                    
Dictionary<int, string[,]> Lvls =  new Dictionary<int, string[,]>{{1, 
new string[,]{{" "," "," "," "," "},
              {" ","|"," "," "," "},
              {" ","|","@"," "," "},
              {" ","|"," "," "," "},
              {" ","|"," ","$"," "},
              {" "," "," "," "," "}}},{2,  
new string[,]{{" "," "," "," "," "},
              {" ","|"," ","|"," "},
              {" ","|","@","|"," "},
              {" ","|"," ","|"," "},
              {" "," "," ","$"," "},
              {" "," "," "," "," "}}}, {3,  
new string[,]{{" "," "," "," "," "},
              {" ","|"," ","|"," "},
              {" ","|","@","|"," "},
              {" "," "," "," "," "},
              {" ","|"," ","$","|"},
              {" ","|"," "," ","|"}}}, {4,  
new string[,]{{"|","|","|","|","|"},
              {"|"," "," "," ","|"},
              {"|"," ","@"," ","|"},
              {"|"," "," "," ","|"},
              {"|"," "," ","$","|"},
              {"|","|","|","|","|"}}}};


    int coins = 0;
    int MenuX = 0;
    int MenuY = 0;
    int LvlX = 0;
    int LvlY = 0;



    int SelecLvlGame()
 /*   {
        Console.Clear();
        Console.WriteLine("Введите какой уровент вы хотите");
        foreach (var item in Lvls)
        {
            Console.Write(item.Key+ " ");
        }
        Console.WriteLine();
        return int.Parse(Console.ReadLine());
    }
*/
 
    {
        int indexLvl = 0;
        MatrixWrite(lvl);
        ConsoleKeyInfo User_keyTab = Console.ReadKey();
        while (User_keyTab.Key != ConsoleKey.Enter)
        {
            Console.Clear();
            lvl[LvlY, LvlX] = " ";
            if (User_keyTab.Key == ConsoleKey.W && indexLvl >0)
            {
                indexLvl--;
                LvlY--;
            }
            if (User_keyTab.Key == ConsoleKey.S && indexLvl < 3)
            {
                indexLvl++;
                LvlY++;
            }
            lvl[LvlY, LvlX] = "@";
            MatrixWrite(lvl);
            User_keyTab = Console.ReadKey();
        }
return indexLvl;
    }

int SelectMenuPlayer()
{
    int indexMenu = 0;
    MatrixWrite(menu);
    ConsoleKeyInfo User_keyTab = Console.ReadKey();
    while (User_keyTab.Key != ConsoleKey.Enter)
    {
        Console.Clear();
        menu[MenuY, MenuX] = " ";
        if (User_keyTab.Key == ConsoleKey.W && indexMenu > 0)
        {
            indexMenu--;
            MenuY--;
        }
        if (User_keyTab.Key == ConsoleKey.S && indexMenu < 2)
        {
            indexMenu++;
            MenuY++;
        }
        menu[MenuY, MenuX] = "@";
        MatrixWrite(menu);
        User_keyTab = Console.ReadKey();
    }
    return indexMenu;
}

 void MatrixWrite(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
    Console.WriteLine();
    }
Console.WriteLine("Количество очков " + coins);
}


string[,] ItemFoodMatrix(int x, int y, string[,] array)
{
    while(matrix[y,x] == "$")
    {
        matrix[y,x] = " ";
        int matX = new Random().Next(0, array.GetLength(1));
        int matY = new Random().Next(0, array.GetLength(0));
        while (matrix[matY, matX] == "|")
        {
            matX = new Random().Next(0, array.GetLength(1));
            matY = new Random().Next(0, array.GetLength(0));
        }
        array[matY,matX] = "$";
        coins++;
    }
    return array;
}


bool Barrier(int x, int y)
{
    if(matrix[y,x] == "|") return false;
    return true;
}


int x = 3;
int y = 3;


while (true)
{
    switch (SelectMenuPlayer())
    {      
        case 0:
                Console.Clear();
                Game();
                break;
        case 1:
               Console.Clear();
               matrix = Lvls[SelecLvlGame()];
               Game();
               break;
        case 2:
               Console.Clear();
               break;
            default:
             break;
    }
   
   void Game()
   {
    while (true)
    {
         Console.Clear();
    MatrixWrite(matrix);
    matrix[y,x] = " ";
    ConsoleKeyInfo User_keyTab = Console.ReadKey();

    if(User_keyTab.Key == ConsoleKey.W) if(Barrier(x,y-1)) y--;
    if(User_keyTab.Key == ConsoleKey.S) if(Barrier(x,y+1)) y++;

    if(User_keyTab.Key == ConsoleKey.A) if(Barrier(x-1,y)) x--;
    if(User_keyTab.Key == ConsoleKey.D) if(Barrier(x+1,y)) x++;

    if(y>matrix.GetLength(0)) y = 0;
    if(y<=0) y = matrix.GetLength(0);

    if(x>matrix.GetLength(1)) x = 0;
    if(x<=0) x = matrix.GetLength(1);
    
    matrix = ItemFoodMatrix(x,y,matrix);

    matrix[y,x] = "@";
    }
    }
   }