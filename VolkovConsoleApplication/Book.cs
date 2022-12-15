using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    class Book
    {
        // 1. Внутренние поля класса
        string title; // название (заголовок) книги
        string author; // фамилия и имя автора
        double price; // стоимость книги

        // 2. Конструктор с 3 параметрами
        public Book(string _title, string _author, double _price)
        {
            title = _title;
            author = _author;

            // корректировка стоимости книги
            if (price < 0) price = 0.0;
            else price = _price;
        }

        // 3. Свойства типа get/set для доступа к полям класса
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (price < 0) price = 0.0;
                else price = value;
            }
        }

        // 4. Метод Print() - вывести поля класса
        public void Print()
        {
            Console.WriteLine("title = {0}, author = {1}, price = {2:f2}", title, author, price);
        }
    }

    // Класс, который наследует класс Book - добавляет жанр к книге.
    class BookGenre : Book
    {
        // 1. Внутреннее поле - жанр, к которому относится книга
        string genre;

        // 2. Конструктор с 4 параметрами.
        // Вызывает конструктор базового класса с помощью base(...).
        public BookGenre(string _title, string _author, double _price, string _genre) :
        base(_title, _author, _price)
        {
            genre = _genre;
        }

        // 3. Свойство доступа к полю genre
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        // 4. Метод Print() - вызывает метод базового класса
        // В заголовке метода используется ключевое слово new. Это
        // есть рекомендация компилятора - подчеркнуть, что данный метод
        // прячет одноименный метод базового класса.
        public new void Print()
        {
            base.Print(); // вызвать метод Print() базового класса Book
            Console.WriteLine("genre = {0}", genre);
        }
    }

    // Класс, который наследует класс BookGenre - добавляет к иерархии классов
    // поле издателя.
    // Перед классом используется ключевое слово sealed - это означает,
    // что данный класс не может быть унаследован другими классами.
    sealed class BookGenrePubl : BookGenre
    {
        // 1. Внутреннее поле - информация об издателе
        private string publisher;

        // 2. Конструктор с 5 параметрами - Вызывает конструктор базового
        // класса BookGenre() с помощью ключевого слова base.
        public BookGenrePubl(string _title, string _author, double _price,
            string _genre, string _publisher) : base(_title, _author, _price, _genre)
        {
            publisher = _publisher;
        }

        // 3. Свойство доступа к полю publisher
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        // 4. Метод Print() - вызывает метод базового класса.
        // В объявлении метода рекомендуется использовать
        // ключевое слово new, так как данный метод "прячет" метод базового класса.
        public new void Print()
        {
            base.Print();
            Console.WriteLine("publisher = {0}", publisher);
        }
    }
    }

