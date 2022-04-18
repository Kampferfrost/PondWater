namespace PondWater
{
    class Program
    {
        static void Main(string[] args )
        {
            string dirIn = "In\\"; // папка входящих файлов
            DirectoryInfo directoryIn = new DirectoryInfo(dirIn);
            if (directoryIn.Exists)
            {
                Console.WriteLine("Каталог существует\n");

                FileInfo[] dirs = directoryIn.GetFiles("*.txt");
                foreach (FileInfo dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            else
            {
                Console.WriteLine("Каталог не найден");
            }    
        }
    }
}
