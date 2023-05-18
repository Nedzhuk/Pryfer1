namespace Pryffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Tree = new("Tree.txt");
            string[] mas = new string [Tree.Length];
            mas = File.ReadAllLines(Tree);
            string[,] fileTree = new string[mas.Length, mas.Length];
            int chet = 0;
            for(int i = 0; i < mas.Length; i++)
            {
                string[] tmp = mas[i].Split(";");
                for(int j = 0; j < tmp.Length; j++)
                {
                    fileTree[i,j] = tmp[j];
                    chet++;
                }
                for (int j = 0; j < mas.Length; j++)
                {
                    if(fileTree[i, j] == null) fileTree[i, j]="0";
                }
            }
            for(int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length; j++) Console.Write($"{fileTree[i, j]} ");
                Console.WriteLine();
            }
            string codePryfer = $"";
            

            while(codePryfer.Length <= chet-2)
            {
                int[] num = new int[mas.Length];
                int indexNumI = 0;
                int indexNumJ = 0;
                int minNum = int.MaxValue;
                int newPryfer = 0;

                for (int i = 0; i < mas.Length; i++)
                {
                    for(int j = mas.Length-1; j >= 1; j--)
                    {
                    if (Convert.ToInt32(fileTree[i, j]) != 0)
                    {
                        num[i] = Convert.ToInt32(fileTree[i, j]);
                        if (num[i] < minNum)
                        {
                            minNum = num[i];
                            indexNumI = i;
                            indexNumJ = j;
                            newPryfer = Convert.ToInt32(fileTree[i, j - 1]);
                        }
                        break;
                    }
                    }
                    //Console.Write($"{num[i]} ");
                }
            
            fileTree[indexNumI, indexNumJ] = "0";

                for (int i = 1; i < mas.Length; i++)
                    for (int j = 0; j < mas.Length; j++)
                    {
                        if (fileTree[i, j] == fileTree[i - 1, j] && fileTree[i, j] != "0")
                            if (fileTree[i, j + 1] == fileTree[i - 1, j + 1] && ((fileTree[i, j + 2] != "0" && fileTree[i - 1, j + 2] == "0")||(fileTree[i, j + 2] == "0" && fileTree[i - 1, j + 2] != "0")))
                            {
                                for (int ik = 0; ik < mas.Length; ik++)
                                    for (int jk = 0; jk < mas.Length; jk++) fileTree[i, jk] = "0";
                            }
                    }
                Console.WriteLine($"\nМинимум: {minNum}, его родитель {newPryfer}");
            codePryfer += $"{newPryfer} ";

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length; j++) Console.Write($"{fileTree[i, j]} ");
                Console.WriteLine();
            }
                Console.WriteLine($"\nКод Прюфера: {codePryfer}");
            }
            string result = "Result.txt";
            File.WriteAllText(result, codePryfer);
        }
    }
}