namespace PondWater
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadFiles readFiles = new ReadFiles();
            readFiles.CheckDirAndFiles();    

        }
    }


}


//Todo: 1) Создать проверку папки
//Todo: 2) Создать проверку на файлы, есть ли они в папке
//Todo: 3) Прочитать txt. в папке In и вывести в консоль
//Todo: 4) Сделать проверку имени файлов txt. чтобы читал только .txt формата "1-4-20220128150030.txt"
